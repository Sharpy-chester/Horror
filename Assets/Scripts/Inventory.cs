using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] inventory = new Item[7];
    private static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddToInventory(HoldableItem item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item.item;
                break;
            }
        }
    }

    public void RemoveFromInventory(HoldableItem item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item.item)
            {
                inventory[i] = null;
                break;
            }
        }
    }

    public void RemoveFromInventory(int index)
    {
        inventory[index] = null;
    }
    
    void UpdateInventoryUI()
    {

    }
}
