using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventorySlide : MonoBehaviour
{
    //scriptable???
    #region singleton

    public static InventorySlide instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    public int xIn;
    public int yIn;
    public int xOut;
    public int yOut;
    private bool inventory = false; //if false, inventory is out, if true, inventory is in 

    public void OnClick()
    {
        Debug.Log(transform.position.x + ", " + transform.position.y);
        if (inventory == true)
        {
            SlideOut();
            inventory = false;
            Debug.Log("Slided out");
        }
        else if (inventory == false)
        {
            SlideIn();
            inventory = true;
            Debug.Log("Slided in");
        }
        else
        {
            Debug.Log("sliding failed");
        }
    }
    public void SlideOut()
    {
        transform.LeanMoveLocal(new Vector2(xOut, yOut), 1);
        //transform.LeanMoveLocal(new Vector2(-400, 5), 1);
    }
    public void SlideIn()
    {
        transform.LeanMoveLocal(new Vector2(xIn, yIn), 1);
        //transform.LeanMoveLocal(new Vector2(190., 278), 1);
    }
}
