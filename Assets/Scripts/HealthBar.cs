using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{

		public Slider slider;

		// Use this for initialization
		void Start ()
		{
				slider.value = .5f;
		}
	
		// Update is called once per frame
		void Update ()
		{
				slider.value = 1f;
		}
}
