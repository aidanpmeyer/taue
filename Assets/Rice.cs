using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Rice : MonoBehaviour
{
    public float growthPercentage = 0f;
    public GameObject seedModel;
    public GameObject saplingModel;
    public GameObject fullyGrownModel;
    private GameObject currentModel;
    public float growthRate = 1f;
    public Vector3 minScale = Vector3.one * 0.5f; // Initial size
    public Vector3 maxScale = Vector3.one;       // Fully grown size

    void Start()
    {
        // Initialize with seed model
        currentModel = Instantiate(seedModel, transform.position, transform.rotation, transform);
        UpdateModel();
        // Initialize with seed model
        seedModel.SetActive(true);
        saplingModel.SetActive(false);
        fullyGrownModel.SetActive(false);
        currentModel = seedModel;
    }

   
    void Update()
    {
        // Only grow if not fully grown
        if (growthPercentage < 200)
        {
            // Calculate growth increment
            float growthIncrement = CalculateGrowth();

            // Increment growth percentage
            growthPercentage += growthIncrement * Time.deltaTime;

         

            // Update the model based on growth
            
            UpdateModel();
        } else
        {
            Destroy(gameObject);
        }
    }
    
    float CalculateGrowth()
    {

        float environmentalFactor =  1;
        return growthRate * environmentalFactor;
    }


    void UpdateModel()
    {
        if(growthPercentage < 140)
        {
            float scaleFactor = growthPercentage / 100f;
            currentModel.transform.localScale = Vector3.Lerp(minScale, maxScale, scaleFactor);

        }
        
        
        if (growthPercentage >= 100f)
        {
            SetModel(fullyGrownModel);
        }
        else if (growthPercentage >= 50f)
        {
            SetModel(saplingModel);
        }
        else
        {
            SetModel(seedModel);
        }

    }

    void SetModel(GameObject newModel)
    {
        if (currentModel != newModel)
        {
            currentModel.SetActive(false);
            newModel.SetActive(true);
            currentModel = newModel;
        }
    }

    public bool IsHarvestable()
    {
        return growthPercentage >= 100f;
    }

    void OnMouseDown()
    {
        if (IsHarvestable())
        {
            Harvest();
        }
    }

    void Harvest()
    {
        // Handle harvesting logic, e.g., give resources to the player
        Destroy(gameObject); // Or disable it, depending on your game design
    }
}
