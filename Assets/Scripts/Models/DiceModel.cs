using UnityEngine;
using System.Collections;

[System.Serializable]
public class DiceModel
{
		public AbilityModel[] abilities = new AbilityModel[6];
		public string name;
		public byte maxHealth, currentHealth;
		public byte targetType;
		
}
