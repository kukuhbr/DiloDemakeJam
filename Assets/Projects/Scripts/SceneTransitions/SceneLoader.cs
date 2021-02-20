using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Firefighter.UserInterface;

namespace Firefighter.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        private AsyncOperation asyncLoad;
        private bool isLoading = false;

        public SceneTransitionUI transitionUI;
        public bool isShowProgress;
        public SceneLoaderUI loaderUI;
		public delegate void SceneLoaderEvent();
		public event SceneLoaderEvent OnSceneLoadingStart;

        private IEnumerator ActivateLoadedScene(string inputScene)
        {
            transitionUI.Show();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(inputScene);
        }
        private IEnumerator AsynchronousLoad(string inputScene)
        {
            if (!isLoading)
            {
                isLoading = true;
                asyncLoad = SceneManager.LoadSceneAsync(inputScene);
                asyncLoad.allowSceneActivation = false;
                yield return asyncLoad;
            }
        }
        private IEnumerator CheckLoadingProgress()
        {
            if (isLoading && asyncLoad != null)
            {
                float progress = 0;
                do
                {
                    progress = asyncLoad.progress / 0.9f;
                    UpdateProgress(progress);
                }
                while (progress < 1);
                transitionUI.Show();
                yield return new WaitForSeconds(2f);
                asyncLoad.allowSceneActivation = true;
            }
        }
        private IEnumerator WaitTransition()
        {
            yield return new WaitForSeconds(0.1f);
            if (SceneLoaderData.Instance.IsLoadingScene())
            {
                LoadSpecificScene(SceneLoaderData.Instance.GetNextScene());
                StartCoroutine(CheckLoadingProgress());
            }
        }
        private void Load(string inputScene)
        {
            if (SceneLoaderData.Instance.IsLoadingScene())
            {
                StartCoroutine(AsynchronousLoad(inputScene));
            }
            else
            {
                StartCoroutine(ActivateLoadedScene(inputScene));
            }
        }
        private void Start()
        {
            StartCoroutine(WaitTransition());
        }
        private void UpdateProgress(float progress)
        {
            if (isShowProgress)
            {
                loaderUI.UpdateFill(progress);
            }
        }

        public void LoadCurrentScene()
        {
            LoadSpecificScene(SceneManager.GetActiveScene().name);
        }
        public void LoadSpecificScene(string inputScene)
        {
            if (OnSceneLoadingStart != null)
            {
				OnSceneLoadingStart();
            }
            if (!SceneLoaderData.Instance.IsLoadingScene())
            {
                SceneLoaderData.Instance.SetNextScene(inputScene);
                inputScene = "Loading Scene";
            }
            else
            {
                SceneLoaderData.Instance.SetNextScene("");
            }
            Load(inputScene);
        }
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
