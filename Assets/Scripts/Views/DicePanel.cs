using UnityEngine;
using System.Collections;

public class DicePanel : MonoBehaviour
{

		public EntityPanel[] entityPanel;

		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Init (DiceModel[] diceModel)
		{
				for (int x = 0; x < diceModel.Length; x++)
						entityPanel [x].Init (diceModel [x].name);
				// This makes the assumption there's always an equal amount of panels to models
		}
}
