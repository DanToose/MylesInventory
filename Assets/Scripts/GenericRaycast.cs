using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class IntEvent : UnityEvent<int> { }

public class GenericRaycast : MonoBehaviour
{
    private Ray g_ray = new Ray(); // Ray is a type in Unity
    private RaycastHit g_hitObject; // RaycastHit is also a type, specifically for identifying objects rays hit
    private bool g_isHit = false;
    public LayerMask g_layerToHit; // Defining a layer that will be detected with our raycast
    public float g_rayLength = 10f; // Length of the ray
    public KeyCode g_boundKey; // store the key that executes raycast
    public IntEvent g_onObjectClicked; // store a callback event to some other function

    public KeyCode g_drop1Key; // store the key that removes item 1
    public KeyCode g_drop2Key;
    public KeyCode g_drop3Key;

    public Inventory myInventory;

    private void Start()
    {
        myInventory = Camera.main.transform.GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(g_boundKey))
            CastRay();
        else if (Input.GetKeyUp(g_boundKey))
            g_isHit = false;

        if (Input.GetKeyUp(g_drop1Key))
        {
            DropItem(0);
        }
        if (Input.GetKeyUp(g_drop2Key))
        {
            DropItem(1);
        }
        if (Input.GetKeyUp(g_drop3Key))
        {
            DropItem(2);
        }
    }

    private void CastRay()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Creates a ray from the camera at the X & Y point of the mouse position
        // Only really gets the direction of the ray - 'point to' <thing>

        // Raycast function returns a boolean - returns an object hit to g_hitObject
        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, g_layerToHit))
        {
            if (g_isHit == false)
            {
                // If not not - run function the event is pointing to
                g_onObjectClicked?.Invoke(g_hitObject.transform.GetComponent<WorldItem>().ID); 
                g_isHit = true;
            }
        }
    }

    private void DropItem(int itemToDrop)
    {
        myInventory.RemoveItem(itemToDrop);
    }
}
