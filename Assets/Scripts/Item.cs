using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite iconImage;
    public GameObject itemPrefab;
}
