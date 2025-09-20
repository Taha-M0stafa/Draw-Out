using UnityEngine;
[System.Serializable]
public class Slot
{
    public ItemSO item;
    public UpgradeSO upgrade;
    public int amount;

    public Slot(ItemSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public Slot(UpgradeSO upgrade, int amount)
    {
        this.upgrade = upgrade;
        this.amount = amount;
    }
    ~Slot()
    {
        item = null;
        amount = 0;
    }
    
}
