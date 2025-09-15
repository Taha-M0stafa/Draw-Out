using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{   public string itemName; // assign in prefab (e.g. "Potion")
      [SerializeField] private ItemDataBase itemdatabase;
     ItemSO item;
   // reference to the ItemSO scriptable object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

                item = itemdatabase.GetItemByName(itemName);

                    
            Inventory.instance.AddItem(item);
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
