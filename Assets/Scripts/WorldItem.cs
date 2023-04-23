using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public InventoryItem g_item;
    [SerializeField]
    private int g_id;
    public int ID { get { return g_id; } }

    private void Start()
    {
        Camera.main.GetComponent<GenericRaycast>().g_onObjectClicked.AddListener(PickUpItem);
     
        // Event explained - onObjectClicked function from the raycast is the PUBLISHER
        // Then a LISTENER is created to call PickUpItem method.
     }

    private void PickUpItem(int idToCheck) 
    {
        if(g_id == idToCheck)
        Camera.main.GetComponent<Inventory>().AddItem(g_item);
    }
}
