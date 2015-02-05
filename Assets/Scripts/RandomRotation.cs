using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{



		// Use this for initialization
		void Start ()
		{
				float x = Random.Range (0, 360f);
				float y = Random.Range (0, 360f);
				float z = Random.Range (0, 360f);

				transform.rotation = new Quaternion (x, y, z, 1f);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
