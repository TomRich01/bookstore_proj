using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggler : MonoBehaviour
{

    [SerializeField] private GameObject item;
    private bool isItemSelected;
    public void ToggleUIItem()
    { 
        isItemSelected = !isItemSelected;
        Toggler();
        
    }

    private void Toggler()
    {
        if (isItemSelected)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
    }
}
