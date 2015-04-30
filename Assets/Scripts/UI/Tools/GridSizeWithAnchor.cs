using UnityEngine;
using UnityEngine.UI;

public class GridSizeWithAnchor : MonoBehaviour
{
    public RectTransform rT;
    public GridLayoutGroup gLG;
    public float width;

    public void Start()
    {
        rT = GetComponent<RectTransform>();
        gLG = GetComponent<GridLayoutGroup>();
        gLG.cellSize = new Vector2(rT.rect.width, gLG.cellSize.y);

    }

    public void OnRectTransformDimensionsChange()
    {
        if (rT != null && gLG != null)
            gLG.cellSize = new Vector2(rT.rect.width, gLG.cellSize.y);
    }

}
