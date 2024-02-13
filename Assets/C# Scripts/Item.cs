using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName ="Item/baseItem")]
public class Item : ScriptableObject
{
    new public string name = "Defulat Item";
    public Sprite icon = null;
    public string itemDescription = "Used for crafting";
    public int durability = -1;
    //public BoxCollider2D player;
    //public BoxCollider2D nitricAcid;
    

    public virtual void Use(bool hotbar)
    {
        Debug.Log("Using " + name);
        if(name.Equals("Bottle"))
        {
            
            if (GameManager.instance.useBottle())
            {
                durability--;
                Inventory.instance.check(); //checks if any items need to be deleted due to durability
            }


        }
        else if (name.Equals("Axe"))
        {
            if (GameManager.instance.useAxe())
            {
                durability--;
                Inventory.instance.check(); //checks if any items need to be deleted due to durability
            }
            

        }
        else if (name.Equals("High"))
        {
            GameManager.instance.speed(30f);
            durability--;
            Inventory.instance.check(); //checks if any items need to be deleted due to durability
           


        }
        /*
        if(name.Equals("bottle") && player.IsTouching(nitricAcid)){
            Debug.Log("Aquired Nitric Acid");
        }
        
        if(player.IsTouching(nitricAcid)){
            Debug.Log("Touching v2");
        } 
        */

    }

    

    public virtual string GetItemDescription()
    {
        Debug.Log(durability);
        if (durability == -1)
        {
            return itemDescription;
        }
        Debug.Log(itemDescription + " Durability: " + durability);
        return itemDescription + " Durability: " + durability;
        
        
    }

    public virtual string GetName()
    {
        return name;
    }
}
