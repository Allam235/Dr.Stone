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
    public void SlideOut()
    {
        transform.LeanMoveLocal(new Vector2(xOut, yOut), 1); // in position is 580, 20
    }
    public void SlideIn()
    {
        transform.LeanMoveLocal(new Vector2(xIn, yIn), 1); // in position is 280, 20
    }
}
