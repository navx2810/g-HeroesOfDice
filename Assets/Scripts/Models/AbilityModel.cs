using UnityEngine;
using System.Collections;

[System.Serializable]
public class AbilityModel
{
		public string name;
		public Sprite icon;
		public byte baseDamage;
		public byte attackType;
		public float modifier;
		public byte targetType;


		public static string getTargetTypeAsString (byte targetType)
		{
				switch (targetType) {
				case 0: 
						return "Enemy";
				case 1:
						return "Ally";
				case 2:
						return "Any";
				case 3:
						return "Self";
				case 4:
						return "All";
				default:
						return "BROKEN"; 

				}
		}


}
