using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    #region Singleton

    public static InventoryUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one InventoryUI Object");
        }
        instance = this;
    }
    #endregion

    private Inventory inventory;

    public GameObject inventoryMenuObject;
    public Transform slotsParent;

    public List<InventorySlotButton> slots = new List<InventorySlotButton>();

    public bool invetoryOpen = false;

    public GameObject descriptionTab;
    private Item selectedItem = null;
    public TextMeshProUGUI descriptionText;
    public Image descriptionImage;
    


    void Start()
    {
        inventory = Inventory.instance;
        inventoryMenuObject.SetActive(false);
        SetSlots();
        UpdateDescription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteSelected()
    {
        
        Inventory.instance.RemoveItem(selectedItem);
        selectedItem = null;
        UpdateInventoryUI();
        UpdateDescription();
    }

    public void UpdateInventoryUI()
    {
        AsignItemsToSlots();
        foreach (InventorySlotButton button in slots)
        {
            button.UpdateSlotImage();
        }

    }

    public void SetSelected(Item i)
    {
        selectedItem = i;
        UpdateDescription();
    }
    public void UpdateDescription()
    {
        if(selectedItem != null)
        {
            descriptionTab.SetActive(true);
            descriptionText.text = selectedItem.description;
            descriptionImage.sprite = selectedItem.icon;
        }
        else
        {
            descriptionTab.SetActive(false);
        }
    }

    /// <summary>
    /// Open Inventory
    /// </summary>
    public void ActivateInventory()
    {
        Debug.Log("Inventory");
        UpdateInventoryUI();
        invetoryOpen = true;
        inventoryMenuObject.SetActive(true);
    }

    public void CloseInventory()
    {
        invetoryOpen = false;
        inventoryMenuObject.SetActive(false);
    }

    /// <summary>
    /// Goes Through each item in Inventory and asigns them to a slot.
    /// </summary>
    public void AsignItemsToSlots()
    {
        foreach(InventorySlotButton b in slots)
        {
            b.item = null;
        }
        for (int x = 0; x < inventory.items.Count; x++)
        {
            slots[x].item = inventory.items[x];
        }
    }

    /// <summary>
    /// Fetchs all slots and intializes them
    /// </summary>
    public void SetSlots()
    {
        slots = new List<InventorySlotButton>();
        InventorySlotButton[] temp = slotsParent.GetComponentsInChildren<InventorySlotButton>();
        foreach(InventorySlotButton button in temp)
        {
            slots.Add(button);
        }
        
    }
}
