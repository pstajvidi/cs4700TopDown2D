using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> itemsPrefab;
    private Dictionary<int, GameObject> itemDictionary;
    private void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();
        for(int i=0; i< itemsPrefab.Count; i++)
        {
            if(itemsPrefab[i]!= null)
            {
                itemsPrefab[i].id = i+1;
            }
        
        }
        foreach (Item item in itemsPrefab)
        {
            itemDictionary[item.id] = item.gameObject;
        }
    }

    public GameObject GetItemPrefab(int id)
    {
        itemDictionary.TryGetValue(id, out GameObject prefab);
        if(prefab==null )
        {
            Debug.LogError("Item with ID " + id + " not found in the dictionary.");
            
        }
        return prefab;
        
    }
}
