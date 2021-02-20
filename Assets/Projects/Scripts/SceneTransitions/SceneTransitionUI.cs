using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Firefighter.UserInterface
{
	public class SceneTransitionUI : MonoBehaviour {
		private Animator transitionAnimator;
		
		public string animatorParameterName;

		private void Start()
		{
			transitionAnimator = GetComponent<Animator>();
			Hide();
		}

		public void Hide()
		{
			transitionAnimator.SetBool(animatorParameterName, true);
		}
		public void Show()
		{
			transitionAnimator.SetBool(animatorParameterName, false);
		}
	}
}