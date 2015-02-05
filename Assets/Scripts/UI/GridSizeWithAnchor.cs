using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridSizeWithAnchor : MonoBehaviour
{
		public RectTransform rT;
		public GridLayoutGroup gLG;
		public float width;
		
		
		// Use this for initialization
		void Start ()
		{
				rT = GetComponent<RectTransform> ();
				gLG = GetComponent<GridLayoutGroup> ();
				gLG.cellSize = new Vector2 (rT.rect.width, gLG.cellSize.y);

		}
	
		void OnRectTransformDimensionsChange ()
		{
				try {
						gLG.cellSize = new Vector2 (rT.rect.width, gLG.cellSize.y);
				} catch (UnassignedReferenceException uRE) {
				}
		}

}
