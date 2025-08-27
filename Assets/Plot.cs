using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Plot : MonoBehaviour
{
    // Public variable to hold the current plant prefab (assigned at runtime)
    public GameObject currentPlant;

    // A boolean to track whether the plot is empty

    // Reference to the player's inventory or seed-holding system (implement separately)
    public GameObject playerInventory;

    // Optional: Position offset for planting (to ensure plant is placed correctly on the plot)
    public Vector3 plantingOffset = Vector3.zero;

    public GameObject[] plants;
    void Start()
    {
        // Initialize the plot state (you can expand this later)
    }

    void Update()
    {
        // Optional: Add hover or highlight effects here to indicate the plot can be clicked
    }

    // Called when the player clicks on the plot
   /* void OnMouseDown()
    {
        Debug.Log("ok clicked");
        // TODO: Check if the player is holding a seed (you'll need to implement this in your inventory system)
        if (!isEmpty)
        {
            Debug.Log("Plot is already occupied!");
        }
        else
        {
            Vector3 spawnPosition = transform.position + plantingOffset;
            currentPlant = Instantiate(plants[0], spawnPosition, Quaternion.identity);
            Debug.Log("You need a seed to plant!");
            isEmpty= false;
        }
    }*/


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isEmpty())
            {
                Debug.Log("Plot is already occupied!");
            }
            else
            {
                Vector3 spawnPosition = transform.position + plantingOffset;
                currentPlant = Instantiate(plants[0], spawnPosition, Quaternion.identity);
                currentPlant.transform.parent = transform;
                Debug.Log("You need a seed to plant!");
            
            }
        }
    }

    private bool isEmpty()
    {
        return transform.childCount == 0;
    }
    // Example placeholder method for checking if the player is holding a seed
    // TODO: Replace this with your actual inventory or seed-holding logic
    bool PlayerIsHoldingSeed()
    {
        // Hint: You might want to check the player's inventory or a currently selected item
        // return playerInventory != null; // Placeholder condition
        return true;
    }

    // Optional: Add a method to reset the plot to an empty state (e.g., after harvesting)
    public void ResetPlot()
    {
        // Destroy the current plant (if any)
        if (currentPlant != null)
        {
            Destroy(currentPlant);
            currentPlant = null;
        }

        // Mark the plot as empty
    

        // Debug or visual feedback
        Debug.Log("Plot has been reset.");
    }
}