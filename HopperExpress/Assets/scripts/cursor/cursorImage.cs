using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorImage : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(60, 60), CursorMode.Auto);
    }
}
