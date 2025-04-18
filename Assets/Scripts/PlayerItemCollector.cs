using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    // Start is called before the first frame update
    void Start()
    {
        inventoryController= FindObjectOfType<InventoryController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();
            if (item != null)
            {
                bool itemAdded = inventoryController.addItem(other.gameObject);
                if(itemAdded){
                    Debug.Log("Item added to inventory: " + item.name);
                    Destroy(other.gameObject); // Destroy the item after adding it to the inventory
                }
                else{
                    Debug.Log("Inventory full, cannot add item: " + item.name);
                }
            }
        }
    }
}
