
using UnityEngine;
using UnityEngine.EventSystems;

public class Joybutton1 : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }


}