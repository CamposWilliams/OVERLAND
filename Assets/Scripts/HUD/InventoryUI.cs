using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{



    public GameObject Inventory; 

    private bool isInventoryActive = false;

    private void Start()
    {
        
        Inventory.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        isInventoryActive = !isInventoryActive;
        Inventory.SetActive(isInventoryActive);
    }
}


