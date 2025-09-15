using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ItemDataBase ItemDataBase;
    void Discard(ItemSO item)
    {
        Slot slot = slots.FirstOrDefault(s => s.item == item);
        if (slot != null)
        {
            slots.Remove(slot);
        }
        
    }
    
     public   void AddItem(ItemSO item)
    {
        Slot slot = slots.FirstOrDefault(s => s.item == item);
        if (slot != null)
        {
            slot.amount++;
        }
        else
        {
            slots.Add(new Slot(item, 1));
        }
    }

   public void UseOnce(ItemSO item)
    {
        Slot slot = slots.FirstOrDefault(s => s.item == item);
        if (slot != null)
        {
            slot.amount--;
            if (slot.amount <= 0)
            {
                Discard(item);
            }
        }
    }

    static public Inventory instance;
    public List<Slot> slots = new List<Slot>();
    private void Awake()
    { 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }




    }

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
