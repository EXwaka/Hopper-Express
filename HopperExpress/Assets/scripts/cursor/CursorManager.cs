using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D defaultCursorTexture;
    [SerializeField] private List<CursorAnimation> cursorAnimations;
    private CursorAnimation currentCursorAnimation;

    private void Awake()
    {
        Instance = this;
        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (currentCursorAnimation != null)
        {
            Cursor.SetCursor(currentCursorAnimation.GetCurrentTexture(), currentCursorAnimation.offset, CursorMode.Auto);
        }
    }

    public void SetActiveCursorAnimation(CursorType cursorType)
    {
        foreach (CursorAnimation cursorAnimation in cursorAnimations)
        {
            if (cursorAnimation.cursorType == cursorType)
            {
                currentCursorAnimation = cursorAnimation;
                break;
            }
        }
    }

    [System.Serializable]
    public class CursorAnimation
    {
        public CursorType cursorType;
        public Texture2D[] textureArray;
        public Vector2 offset;

        private int currentIndex = 0;

        public Texture2D GetCurrentTexture()
        {
            return textureArray[currentIndex];
        }
    }

    public enum CursorType
    {
        Default,
        Aim,
        Hand
    }
}
