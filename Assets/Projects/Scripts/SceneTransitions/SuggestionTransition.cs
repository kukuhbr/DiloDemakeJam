using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Firefighter.UserInterface
{
	public class SuggestionTransition : MonoBehaviour
	{
		public Animator sceneAnimator;
		public bool boolValue;
		public string boolParameter;
		public string nextScene;
		public float showTime;
		
		private void Start()
		{
			StartCoroutine(ShowSuggestion());
		}

		private IEnumerator ShowSuggestion()
		{
			yield return new WaitForSeconds(showTime);
			sceneAnimator.SetBool(boolParameter, boolValue);
			yield return new WaitForSeconds(2f);
			SceneManager.LoadScene(nextScene);
		}
	}
}