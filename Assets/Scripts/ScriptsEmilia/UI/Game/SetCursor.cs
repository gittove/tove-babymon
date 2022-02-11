using UnityEngine;

public class SetCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    //[SerializeField] private Texture2D cursorOverBabyTexture;
    //Remember inspector texture type cursor

    private void Start()
    {
        //Custom cursor
        Cursor.SetCursor(cursorTexture,Vector2.zero, CursorMode.Auto);
    }

    //Make prefab for a change cursor with the script and methods and attach to baby prefab
    // private void OnMouseEnter()
    // {
    //     
    // }
    //
    // private void OnMouseExit()
    // {
    //     
    // }
}
