using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{

		public Dice[] partyDice, enemyDice;
		public Dice selectedDice;

		public DicePanel heroPanel, enemyPanel;
		public AbilityPanel abilityPanel;

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
				Init ();
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

		public void Init ()
		{
				DiceModel[] models = new DiceModel[3];
				for (int x = 0; x < 3; x++)
						models [x] = partyDice [x].diceModel;

				heroPanel.Init (models);
				for (int x = 0; x < 3; x++)
						models [x] = enemyDice [x].diceModel;
				enemyPanel.Init (models);
		}


		public void DisplaySelection (SelectionFilter filter)
		{
				// Enable the Catch Events Panel
				// Add the children of the buttons to the catch events panel
				// Toggle all selection buttons on items that match filter
				// Check for a click
				// Get object from click
				// Disable selections
		}
}
