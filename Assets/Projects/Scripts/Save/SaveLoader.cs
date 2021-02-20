using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Firefighter.Save
{
	public class SaveLoader : MonoBehaviour {
		private void Awake()
		{
			//OptionSaveManager.Instance.LoadData();
			GameSaveManager.Instance.LoadGame();
		}
	}
}