using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    bool pointed;
    bool clicked;
    bool pointerDown = false;

    public bool Pointed { get { return pointed; } set { pointed = value; } }
    public bool Clicked { get { return clicked; } set { clicked = value; } }
    public bool PointerDown { get { return pointerDown; } }

    void OnPoint()
    {
        if (!pointed) { pointed = true; }
    }

    void OnClick()
    {
        if (!clicked) { 
            clicked = true; 
            pointerDown = !pointerDown; 
        }
    }

    public RaycastHit2D RaycastFromPointer()
    {
        Vector2 pointerPos = Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue());
        return Physics2D.Raycast(pointerPos, Vector2.zero);
    }
}
