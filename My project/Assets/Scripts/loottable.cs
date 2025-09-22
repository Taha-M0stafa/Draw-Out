using UnityEngine;

using System.Collections.Generic;
using System;

[System.Serializable]

public class LootTable
{
    public GameObject itemprefab;
    [Range(0, 100)] public int dropChance;

}
