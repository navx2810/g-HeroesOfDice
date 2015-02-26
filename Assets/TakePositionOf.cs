using UnityEngine;
using System.Collections;

public class TakePositionOf : MonoBehaviour
{

		public RectTransform target, self;

		// Use this for initialization
		void Start ()
		{
				self = GetComponent<RectTransform> ();

				self.position = target.position;
				self.sizeDelta = new Vector2 (target.rect.width, target.rect.height);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Clicked ()
		{
				Debug.Log ("I was clicked");
		}
}
