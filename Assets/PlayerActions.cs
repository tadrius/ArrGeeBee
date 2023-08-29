using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    bool pointed;
    bool clicked;

    public bool Pointed { get { return pointed; } set { pointed = value; } }
    public bool Clicked { get { return clicked; } set { clicked = value; } }

    void OnPoint()
    {
        if (!pointed) { pointed = true; }
    }

    void OnClick()
    {
        if (!clicked) { clicked = true; }
    }

    public RaycastHit2D RaycastFromPointer()
    {
        Vector2 pointerPos = Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue());
        return Physics2D.Raycast(pointerPos, Vector2.zero);
    }
}
