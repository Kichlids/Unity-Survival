using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject slotHolder;

    public int numSlots;
    private Slot[] slots;

    private GameObject itemPickedUp;

    private bool itemAdded;

    private void Start() {
        numSlots = slotHolder.transform.childCount;
        slots = new Slot[numSlots];
        InitSlots();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            print("Colliding");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Item") {
            print("Exiting");
            itemAdded = false;
        }
    }

    private void InitSlots() {
        for (int i = 0; i < numSlots; i++) {
            slots[i] = slotHolder.transform.GetChild(i).GetComponent<Slot>();
        }
    }

    public void AddItem(GameObject item) {
        for (int i = 0; i < numSlots; i++) {
            if (slots[i].empty && !itemAdded) {
                slots[i].empty = false;
                slots[i].item = item;
                slots[i].itemIcon.texture = item.GetComponent<Item>().icon;

                itemAdded = true;
            }
        }
    }
}
