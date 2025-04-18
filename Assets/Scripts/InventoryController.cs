using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public ItemDictionary itemDictionary;
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount; 
    public GameObject[] itemPrefabs; // Array to hold the slot game objects

    
    // Start is called before the first frame update
    void Start()
    {
        itemDictionary = FindObjectOfType<ItemDictionary>();



       /*  for (int i=0; i<slotCount; i++){
            Slot newSlot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            if(i<itemPrefabs.Length){
                GameObject item = Instantiate(itemPrefabs[i], newSlot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                newSlot.currentItem = item; // Assign the item to the slot
            }
        } */
        
    }

    public bool addItem(GameObject itemPrefab){
        
        foreach(Transform slotTransform in inventoryPanel.transform){
            
            Slot slot = slotTransform.GetComponent<Slot>();
            
            if(slot != null && slot.currentItem == null){
                GameObject newitem = Instantiate(itemPrefab, slotTransform);
                newitem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                slot.currentItem = newitem; // Assign the item to the slot
                return true;

            }
            
        }
        Debug.Log("No empty slot available");
        return false;
    }

    public List<InventorySaveData> GetInventoryItems(){
        List<InventorySaveData> invdata = new List<InventorySaveData>();
        foreach(Transform slotTransform in inventoryPanel.transform){
            Slot slot = slotTransform.GetComponent<Slot>();
            if(slot.currentItem != null){
                Item item = slot.currentItem.GetComponent<Item>();
                invdata.Add(new InventorySaveData{ItemID=item.id, SlotIndex=slotTransform.GetSiblingIndex()});

            }

        }
        return invdata;
    }

    public void SetInventoryItems(List<InventorySaveData> invdata){
        foreach(Transform child in inventoryPanel.transform){
            Destroy(child.gameObject);
        }

        for(int i=0; i<slotCount; i++){
            Instantiate(slotPrefab, inventoryPanel.transform);
        }

        foreach(InventorySaveData data in invdata){
            if(data.SlotIndex< slotCount){
                Slot slot =inventoryPanel.transform.GetChild(data.SlotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.ItemID);
                if(itemPrefab != null){
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                    slot.currentItem = item; // Assign the item to the slot
                }
                
            }
        }
    }
    public void AddItemToInventory(GameObject item)
    {
        // Find an empty slot in the inventory
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentItem == null)
            {
                // Assign the item to the empty slot
                GameObject newItem = Instantiate(item, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                slot.currentItem = newItem; // Assign the item to the slot
                break;
            }
        }
    }




}
