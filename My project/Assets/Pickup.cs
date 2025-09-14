using UnityEngine;

public class Pickup : MonoBehaviour
{   public string itemName; // assign in prefab (e.g. "Potion")

    ItemDataBase ItemDataBase;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var item = ItemDataBase.GetItemByName(itemName);

            if (item != null)
            {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
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
