using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Itemdatabase", menuName = "Scriptable Objects/Itemdatabase")]
public class ItemDataBase : ScriptableObject
{
    public ItemSO[] Item;

    private Dictionary<string, ItemSO> itemLookup;

    private void OnEnable()
    {
        itemLookup = new Dictionary<string, ItemSO>();
        foreach (ItemSO item in Item)
        {
            if (!itemLookup.ContainsKey(item.Itemname))
                itemLookup.Add(item.Itemname, item);
        }
    }

    public ItemSO GetItemByName(string name)
    {
        if (itemLookup.TryGetValue(name, out ItemSO item))
            return item;

        return null;
    }
   
}
