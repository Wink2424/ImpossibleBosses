using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    // public GameObject inventoryUI;
    //    Un-comment the above code to allow opening and closing of menu 
    // 1/2

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory"))
        {
            //    inventoryUI.SetActive(!inventoryUI.activeSelf);
            //    Un-comment the above code to allow opening and closing of menu 
            //      2 /2
            // after, link inventory object in Canvas Parent for inventory
        }
	}

    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
