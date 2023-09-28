﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region singleton

    public static Inventory instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate {};

    public List<Item> inventoryItemList = new List<Item>();

    public List<Item> hotbarItemList = new List<Item>();
    public HotbarController hotbarController;


    public void check()
    {
        for (int i = 0; i< inventoryItemList.Count; i++)
        {
            if (inventoryItemList[i].durability == 0)
            {
                inventoryItemList.RemoveAt(i);
                onItemChange.Invoke();
                return;
            }
        }
        for (int i = 0;i< hotbarItemList.Count; i++)
        {
            if (hotbarItemList[i].durability == 0)
            {
                hotbarItemList.RemoveAt(i);
                onItemChange.Invoke();
                return;
            }
        }
    }

    public void SwitchHotbarInventory(Item item, bool hotbar)
    {
        Debug.Log(item.GetName()); ;
        Debug.Log(hotbar);
        if(hotbar){
            foreach(Item i in hotbarItemList)
            {
                if( i == item)
                {
                    hotbarItemList.Remove(item);
                    inventoryItemList.Add(item);
                    onItemChange.Invoke();
                    return;
                }
            }
        }
        else
        {
            foreach(Item i in inventoryItemList)
            {
                if(i == item)
                {
                    if(hotbarItemList.Count >= hotbarController.HotbarSlotSize)
                    {
                        Debug.Log("No more slots available in hotbar");
                    }
                    else
                    {
                        hotbarItemList.Add(item);
                        inventoryItemList.Remove(item);
                        onItemChange.Invoke();
                    }
                    return;
                }
            }
        }

        

    }

     public void AddItem(Item item)
    {
        inventoryItemList.Add(Instantiate(item));
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item)
    {
        if (inventoryItemList.Contains(item))
        {
            inventoryItemList.Remove(item);
        }
        else if (hotbarItemList.Contains(item))
        {
            hotbarItemList.Remove(item);
        }
        onItemChange.Invoke();
    }
    
    public bool ContainsItem(string itemName, int amount)
    {
        int itemCounter = 0;

        foreach(Item i in inventoryItemList)
        {
            if(i.name == itemName)
            {
                itemCounter++;
            }
        }

        foreach (Item i in hotbarItemList)
        {
            if (i.name == itemName)
            {
                itemCounter++;
            }
        }

        if (itemCounter >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItems(string itemName, int amount)
    {
        for(int i = 0; i < amount; ++i)
        {
            RemoveItemType(itemName);
            Debug.Log("Remove Item " + i);
        }
    }

    public void RemoveItemType(string itemName)
    {
        foreach (Item i in inventoryItemList)
        {
            if (i.name == itemName)
            {
                inventoryItemList.Remove(i);
                return;
            }
        }

        foreach (Item i in hotbarItemList)
        {
            if (i.name == itemName)
            {
                hotbarItemList.Remove(i);
                return;
            }
        }
    }
}