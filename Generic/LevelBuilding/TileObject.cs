using UnityEngine;

public class TileObject : MonoBehaviour
{
    [SerializeField]
    private float width = 1;
    [HideInInspector]
    private float previousWidth = 0;
    [SerializeField]
    private float height = 1;
    [HideInInspector]
    private float previousHeight = 0;

#if UNITY_EDITOR
    private void OnValidate() => UnityEditor.EditorApplication.delayCall += _OnValidate;

    private void _OnValidate()
    {
        UnityEditor.EditorApplication.delayCall -= _OnValidate;
        if (this == null) return;
        ApplyTileProperties();
    }
#endif
    private void ApplyTileProperties()
    {
        if (previousWidth == 0 || previousHeight == 0)
        {
            previousHeight = height;
            previousWidth = width;
        }
        if (height > 0 && width > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            BoxCollider2D collider2D = spriteRenderer.GetComponent<BoxCollider2D>();
            if (spriteRenderer != null)
            {
                spriteRenderer.drawMode = SpriteDrawMode.Tiled;
                spriteRenderer.size = new Vector2(width, height);
            }
            if (collider2D != null)
            {
                collider2D.size = new Vector2(collider2D.size.x / previousWidth * width, collider2D.size.y / previousHeight * height);
                collider2D.offset = new Vector2(collider2D.offset.x / previousWidth * width, collider2D.offset.y / previousHeight * height);
            }
            previousHeight = height;
            previousWidth = width;
        }
        else
        {
            Debug.LogWarning("width and height must be more than 0");
        }

    }
}
