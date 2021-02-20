using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Firefighter.Scenes
{
	public class SceneLoaderData : Singleton<SceneLoaderData>
	{
		private string nextScene;

		protected SceneLoaderData() { }
		
		public string GetNextScene()
		{
			return nextScene;
		}
		public void SetNextScene(string inputScene)
		{
			nextScene = inputScene;
		}
		public bool IsLoadingScene()
		{
			return (SceneManager.GetActiveScene().name == "Loading Scene");	
		}
	}
}