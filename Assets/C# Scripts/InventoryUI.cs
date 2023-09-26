using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{

    #region singleton

    public static InventoryUi instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion


    private bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject inventoryParent;
    public GameObject inventoryTab;
    public GameObject craftingTab;
    public GameObject inventory;


    public List<ItemSlot> itemSlotList = new List<ItemSlot>();

    public GameObject inventorySlotPrefab;
    public GameObject craftingSlotPrefab;

    public Transform invetoryItemTransform;
    public Transform craftingItemTranform;
    

    private void Start()
    {
        Inventory.instance.onItemChange += UpdateInventoryUI;
        SetUpCraftingRecipes();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F pressed");
            int i = 0;
            foreach(ItemSlot slot in itemSlotList)
            {
                Debug.Log(slot.item.name + ": " + i);
                i++;
            }
        }
    }

    private void SetUpCraftingRecipes()
    {
        List<Item> craftingRecipes = GameManager.instance.craftingRecipes;

        foreach(Item recipe in craftingRecipes)
        {
            GameObject Go = Instantiate(craftingSlotPrefab, craftingItemTranform);
            ItemSlot slot = Go.GetComponent<ItemSlot>();
            slot.AddItem(recipe);
        }
    }

    private void UpdateInventoryUI()
    {
        int currentItemCount = Inventory.instance.inventoryItemList.Count;

        while(currentItemCount > itemSlotList.Count)
        {
            //Add more item slots
            AddItemSlots(currentItemCount);
        }
/*
        for(int i = 0; i < itemslotList.Count; ++i){
            if(Inventory.instance.inventoryItemList[i].name.Equals(itemslotList.item.name)){
                itemSlotList[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
        }
        for(int i = 0; ++i){
            if(!Inventory.instance.inventoryItemList[i].name.Equals(itemslotList.item.name)){
                itemSlotList[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
        }
*/ 




        for(int i = 0; i < itemSlotList.Count; ++i)
        {
            Debug.Log(i);
            if(i < currentItemCount)
            {
                //update the current item in the slot
                itemSlotList[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
            else
            {
                itemSlotList[i].DestroySlot();
                itemSlotList.RemoveAt(i);
            }
        }

    }

    private void AddItemSlots(int currentItemCount)
    {
        int amount = currentItemCount - itemSlotList.Count;

        for(int i = 0; i < amount; ++i)
        {
            GameObject GO = Instantiate(inventorySlotPrefab, invetoryItemTransform);
            ItemSlot newSlot = GO.GetComponent<ItemSlot>();
            itemSlotList.Add(newSlot);
        }
    }

    public void OnClickInventory()
    {
        Debug.Log(transform.position.x + ", " + transform.position.y);
        if (inventoryOpen == true)
        {
            inventory.transform.LeanMoveLocal(new Vector2(-642, 35), 1);
            inventoryOpen = false;
            Debug.Log("Slided out");
        }
        else if (inventoryOpen == false)
        {
            inventory.transform.LeanMoveLocal(new Vector2(-240, 35), 1);
            inventoryOpen = true;
            Debug.Log("Slided in");
        }
        else
        {
            Debug.Log("sliding failed");
        }
    }


    public void OnCraftingTabClicked()
    {
        
        craftingTab.SetActive(true);
        inventoryTab.SetActive(false);
    }

    public void OnInventoryTabClicked()
    {
        craftingTab.SetActive(false);
        inventoryTab.SetActive(true);
    }

  

}