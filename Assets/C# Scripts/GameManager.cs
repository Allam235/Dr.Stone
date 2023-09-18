﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public List<Item> itemList = new List<Item>();
    public List<Item> craftingRecipes = new List<Item>();

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public Transform mainCanvas;
    public Transform hotbarTransform;
    public Transform inventoryTransform;
    public BoxCollider2D player;
    public BoxCollider2D nitricAcidPool;
    public Item nitricAcid;
    public BoxCollider2D trees;
    public Item wood;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = itemList[Random.Range(0, itemList.Count)];
            Inventory.instance.AddItem(Instantiate(newItem));
            
        }

        
    }

    public bool useBottle()
    {
        if (player.IsTouching(nitricAcidPool))
        {
            Inventory.instance.AddItem(nitricAcid);
            Debug.Log("Aquired Nitric Acid");
            return true;
        }
        return false;

    }

    public bool useAxe()
    {
        if (player.IsTouching(trees))
        {
            Inventory.instance.AddItem(wood);
            Debug.Log("Aquired Wood");
            return true;
        }
        return false;

    }

    public Item RandomItem(){
        Item newItem = itemList[Random.Range(0, itemList.Count)];
        return Instantiate(newItem);
    }

    public void OnStatItemuUse(StatItemType itemType, int amount)
    {
        Debug.Log("Consuming " + itemType + " Add amount: " + amount);
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }

        buttonPos.x -= 125;
        buttonPos.y += 5;

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

}