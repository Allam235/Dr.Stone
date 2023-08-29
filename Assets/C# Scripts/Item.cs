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
    public BoxCollider2D player;
    public BoxCollider2D nitricAcid;

    public virtual void Use(bool hotbar)
    {
        if(name.Equals("bottle") && player.IsTouching(nitricAcid)){
            Debug.Log("Aquired Nitric Acid");
        }
        Debug.Log("Using " + name);
        if(player.IsTouching(nitricAcid)){
            Debug.Log("Touching v2");
        } 
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