using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> Items = new List<InventoryItem>(); // Gens a list of Inventory Items, called Items

    public Transform g_inventoryPanel;  // Reference to InventoryUI graphic (panel)
    public List<SlotUI> g_slots = new List<SlotUI>();
    public List<SlotUI> c_slots = new List<SlotUI>();

    void Awake()
    {
        foreach (Transform slotGraphic in g_inventoryPanel)
        {
            g_slots.Add(slotGraphic.GetComponent<SlotUI>());
        }
    }

    public void AddItem(InventoryItem item)
    {
        if (Items.Count < g_slots.Count) // checks there are free  slots
            Items.Add(item);

        foreach (SlotUI slot in g_slots)
        {
            if (slot.Item == null)
            {
                slot.SetItem(item);
                return;
            }
        }
    }

    public void RemoveItem(int itemToDrop)
    {
        Items.Remove(Items[itemToDrop]);
        g_slots[itemToDrop].ClearItem();
        RefreshUISlots();
        
        // This successfully removes the item from the ITEMS LIST in Inventory.
        // Now how to refresh the UI?
    }

    public void RefreshUISlots()
    {
        c_slots = new List<SlotUI>();

        foreach (SlotUI gslot in g_slots)
        {
            if (gslot.g_item != null)
            {
                c_slots.Add(gslot);
            }
            g_slots.Remove(gslot);

        }

        g_slots = new List<SlotUI>();

        foreach (SlotUI cslot in c_slots)
        {
            g_slots.Add(cslot);
        }



    }

}
