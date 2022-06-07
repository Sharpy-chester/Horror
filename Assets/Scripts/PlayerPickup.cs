using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    Transform playerCameraTransform;
    [SerializeField] int selectedItem = 0;
    [SerializeField] float dropDist = 2f;
    [SerializeField] float interactDist = 3f;
    Tooltip tooltip;
    RaycastHit hit;

    void Awake()
    {
        playerCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        hit = InteractRaycast.Instance.RayHit();
        Tooltips();
        Interaction();
        ItemSelectInput();
    }

    void Tooltips()
    {
        if(hit.collider != null)
        { 
            if(hit.transform.GetComponent<Tooltip>())
            {
                tooltip = hit.transform.GetComponent<Tooltip>();
                tooltip.ShowText();
            }
            else if (tooltip != null)
            {
                tooltip.HideText();
                tooltip = null;
            }
        }
        else if (tooltip != null)
        {
            tooltip.HideText();
            tooltip = null;
        }
    }

    void Interaction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            bool toggledDoc = false;
            if (UIManager.Instance.showingDocument)
            {
                UIManager.Instance.HideDocument();
                toggledDoc = true;
            }
            if (hit.collider != null)
            {
                if (hit.transform.GetComponent<HoldableItem>())
                {
                    PickupItem(hit.transform);
                }
                else if (hit.transform.GetComponent<Document>() && !toggledDoc)
                {
                    UIManager.Instance.ViewDocument(hit.transform.GetComponent<Document>());
                }
            }
        }
        if (Input.GetButtonDown("Drop") && Inventory.Instance.inventory[selectedItem] != null)
        {
            DropHeldItem();
        }
    }

    public void DropHeldItem()
    {
        if(Inventory.Instance.inventory[selectedItem] != null)
        {
            GameObject item = Instantiate(Inventory.Instance.inventory[selectedItem].itemPrefab, transform.position, Quaternion.identity);
            item.transform.parent = transform;
            //i could do it without making it a parent, but my brains mush at the moment
            item.transform.localPosition = Vector3.forward * dropDist;
            item.transform.parent = null;
            Inventory.Instance.RemoveFromInventory(selectedItem);
            UIManager.Instance.UpdateInv(selectedItem);
        }
    }

    void PickupItem(Transform item)
    {
        Inventory.Instance.AddToInventory(item.GetComponent<HoldableItem>());
        UIManager.Instance.UpdateInv(selectedItem);
        if(tooltip != null)
        {
            tooltip.HideText();
            tooltip = null;
        }
        Destroy(item.gameObject);
    }

    void ItemSelectInput()
    {
        int oldSelectedItem = selectedItem;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedItem = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedItem = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedItem = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selectedItem = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            selectedItem = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            selectedItem = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            selectedItem = 6;

        if(selectedItem != oldSelectedItem)
        {
            UIManager.Instance.UpdateInv(selectedItem);
        }
    }
}
