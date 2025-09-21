using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Upgradedatabase", menuName = "Scriptable Objects/Upgradedatabase")]
public class Upgradedatabase : ScriptableObject
{


     public UpgradeSO [] Upgrade;

    private Dictionary<string,  UpgradeSO > Upgradelookup;

    private void OnEnable()
    {
        Upgradelookup = new Dictionary<string, UpgradeSO>();
        foreach (UpgradeSO upgrade  in Upgrade)
        {
            if (!Upgradelookup.ContainsKey(upgrade.Upgradename))
                Upgradelookup.Add(upgrade.Upgradename, upgrade);
        }
        
    }

    public UpgradeSO GetUgradeByName(string name)
    {
        if (Upgradelookup.TryGetValue(name, out UpgradeSO upgrade))
            return upgrade;

        return null;
    }
    
}


   