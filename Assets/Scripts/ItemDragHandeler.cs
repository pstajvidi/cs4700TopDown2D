using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent= transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; // Make the item semi-transparent
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        // Optionally, you can add logic to snap the item to a grid or other UI elements
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f; // Reset the transparency
        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>();
        if(dropSlot == null)
        {
            GameObject item =eventData.pointerEnter; 
            if(item != null)
            {
                dropSlot = item.GetComponentInParent<Slot>();
            }
        }
        
        Slot originalSlot = originalParent.GetComponent<Slot>();
        
        if(dropSlot!=null){
            if(dropSlot.currentItem!= null){
                // Swap items
                dropSlot.currentItem.transform.SetParent(originalParent);
                originalSlot.currentItem=dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot

            }
            else{
                originalSlot.currentItem = null; // Clear the original slot
            }

            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject; // Assign the item to the new slot
       }
       else
       {
        transform.SetParent(originalParent);
       }

       GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
    }

}
