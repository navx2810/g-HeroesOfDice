using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntityPanel : MonoBehaviour
{
		public Text heroName;
		public Slider heroHealth;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Init (string heroName)
		{
				this.heroName.text = heroName;
		}
}
