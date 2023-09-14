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
    //public BoxCollider2D player;
    //public BoxCollider2D nitricAcid;

    public virtual void Use(bool hotbar)
    {
        Debug.Log("Using " + name);
        if(name.Equals("Bottle"))
        {
            GameManager.instance.useBottle();
            

        }
        else if (name.Equals("Axe"))
        {
            GameManager.instance.useAxe();
            

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
        return itemDescription;
    }

    public virtual string GetName()
    {
        return name;
    }
}
