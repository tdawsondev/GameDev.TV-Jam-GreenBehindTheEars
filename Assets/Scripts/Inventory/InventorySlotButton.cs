using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotButton : MonoBehaviour
{
    public Item item;
    public Image buttonImage;

    public void SelectItem()
    {
        InventoryUI.instance.SetSelected(item);
    }
    public void UpdateSlotImage()
    {
        if(item != null)
        {
            buttonImage.enabled = true;
            buttonImage.sprite = item.icon;
        }
        else
        {
            buttonImage.enabled = false;
        }    
    }

    private void OnEnable()
    {
       // UpdateSlotImage();
    }
}
