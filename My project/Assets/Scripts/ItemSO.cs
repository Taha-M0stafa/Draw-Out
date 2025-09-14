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
     
     
}
