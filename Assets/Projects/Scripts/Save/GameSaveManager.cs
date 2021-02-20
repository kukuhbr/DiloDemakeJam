using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//using Firefighter.Level;

namespace Firefighter.Save
{
	public class GameSaveManager : Singleton<GameSaveManager>
	{
		private const string fileName = "/saveData.dat";
		
		public delegate void SaveEvent();
		public static event SaveEvent OnSave;
		public static event SaveEvent OnLoad;

		private void CallSaveEvent()
		{
			if (OnSave != null)
			{
				OnSave();
			}
		}
		private void CallLoadEvent()
		{
			if (OnLoad != null)
			{
				OnLoad();
			}
		}

		public void SaveGame()
		{
			//Windows Store Apps: Application.persistentDataPath points to %userprofile%\AppData\Local\Packages\<productname>\LocalState.
			//Mac : ~/Library/Application Support/company name/product name (Unity recent version)
			//Mac : ~/Library/Caches or ~/Library/Application Support/unity.company name.product name (Unity old version)
			using (FileStream file = File.Create(Application.persistentDataPath + fileName))
			{
				BinaryFormatter fileFormat;
				fileFormat = new BinaryFormatter();

				GameSaveData saveData = new GameSaveData();
				//saveData.levelsStatus = LevelManager.Instance.GetLevelsStatus();
				//saveData.currentLevel = LevelManager.Instance.GetCurrentLevel();

				fileFormat.Serialize(file, saveData);
				file.Close();
				CallSaveEvent();
			}
		}
		public void LoadGame()
		{
			if (File.Exists(Application.persistentDataPath + fileName))
			{
				using (FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open))
				{
					BinaryFormatter fileFormat;
					fileFormat = new BinaryFormatter();
					
					GameSaveData saveData = (GameSaveData) fileFormat.Deserialize(file);
					file.Close();

					//LevelManager.Instance.SetLevelsStatus(saveData.levelsStatus);
					//LevelManager.Instance.SetCurrentLevel(saveData.currentLevel);
					CallLoadEvent();
				}
			}
		}
	}
}