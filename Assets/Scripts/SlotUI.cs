using UnityEngine;
using UnityEngine.UI;
public class SlotUI : MonoBehaviour
{
    public Text g_text; // Holds the item's text
    public Image g_icon; // Holds the item's image
    public Button g_button; // Holds the button component

    public InventoryItem g_item; // local reference to Inventory Item in this script
    public InventoryItem Item { get { return g_item; } set { g_item = value; } }


    // SET ITEM
    public void SetItem(InventoryItem item)
    {
        this.g_item = item;
        this.g_text.text = this.g_item.name; //Sets the text field to this item's name
        this.g_icon.sprite = item.Sprite;
        this.g_button.interactable = true;
    }

    // UNSET ITEM
    public void ClearItem()
    {
        Debug.Log("Setting fields to null for " + this.gameObject.name);
        this.g_item = null;
        this.g_text.text = null;
        this.g_icon.sprite = null;
        this.g_button.interactable = false;
    }
}
