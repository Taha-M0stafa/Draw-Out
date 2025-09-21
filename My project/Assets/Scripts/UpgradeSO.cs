using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
   
     public string Upgradename;
     public Sprite Upgradeicon;
     public string UpgradeTypes; //Statboost forn now
     public string Upgradedescription;
      
      public float Upgradeamount;
    

    public int Upgradeprice;
     
     
     public bool IsrogueUpgrade;
     
     public void printUpgrade()
     {
          Debug.Log("Upgrade name: " + Upgradename + "\n" +
                    "Upgrade description: " + Upgradedescription + "\n" +
                    "Upgrade type: " + UpgradeTypes + "\n" +
                    "Upgrade price: " + Upgradeprice + "\n" +
                    "Is rogue Upgrade: " + IsrogueUpgrade);
     } 
    
}
