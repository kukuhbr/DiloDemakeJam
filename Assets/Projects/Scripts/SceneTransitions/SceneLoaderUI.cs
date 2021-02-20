using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Firefighter.Scenes
{
	public class SceneLoaderUI : MonoBehaviour
	{
		public Image fillImage;

		public void UpdateFill(float inputValue)
		{
			fillImage.fillAmount = inputValue + 0.1f;
		}
	}
}