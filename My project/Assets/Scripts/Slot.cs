using UnityEngine;
[System.Serializable]
public class Slot
{
    public ItemSO item;
    public int amount;

    public Slot(ItemSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    ~Slot()
    {
        item = null;
        amount = 0;
    }
    
}
