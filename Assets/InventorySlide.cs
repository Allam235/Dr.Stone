using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventorySlide : MonoBehaviour
{

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

    public int x = 0;
    public int y = 0;
    public void SlideOut()
    {
        transform.LeanMoveLocal(new Vector2(280, 20), 1); // in position is 580, 20
    }
    public void SlideIn()
    {
        transform.LeanMoveLocal(new Vector2(580, 20), 1); // in position is 280, 20
    }
}
