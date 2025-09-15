using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
     public string Itemname;
     public Sprite Itemicon;
     public string Itemdescription;
     public string Itemtype; //weapon,consumable,relic
     public int Itemprice;
     public GameObject Itemprefab;
     public bool IsrogueItem;
     
     public void printItem()
     {
          Debug.Log("Item name: " + Itemname + "\n" +
                    "Item description: " + Itemdescription + "\n" +
                    "Item type: " + Itemtype + "\n" +
                    "Item price: " + Itemprice + "\n" +
                    "Is rogue item: " + IsrogueItem);
     } 
}
