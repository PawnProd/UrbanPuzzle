using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorATH : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject cursor;

	public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter !");
        cursor.transform.position = transform.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit !");
        cursor.transform.position = Vector3.zero;
    }
}
