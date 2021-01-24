using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool empty;
    private bool hovered;

    public GameObject item;
    public RawImage itemIcon;

    private void Awake() {
        hovered = false;
        empty = true;
    }

    private void Start() {
        itemIcon = GetComponent<RawImage>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovered = false;
    }
}
