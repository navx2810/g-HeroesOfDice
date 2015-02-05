using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{

		public Dice[] partyDice, enemyDice;
		public Dice selectedDice;

		public enum SelectionFilter
		{
				PARTY,
				SELF,
				ENEMIES,
				ALL }
		;

		// Use this for initialization
		void Start ()
		{
				selectedDice = null;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Init (Dice[] partyDice, Dice[] enemyDice)
		{
				this.partyDice = partyDice;
				this.enemyDice = enemyDice;
		}

		public void DisplaySelection (SelectionFilter filter)
		{
				// Toggle all selection buttons on items that match filter
				// Check for a click
				// Get object from click
				// Disable selections
		}
}
