using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    [Header("Sky Rotation Settings")]
    public GameObject sky; // Drag your sky object here
    public float dayLengthInSeconds = 120f; // Length of a full day-night cycle in seconds
    private float timeOfDay = 0f; // Tracks the current time of day (0-1 for normalized time)

    [Header("Debug Settings")]
    public bool pauseTime = false; // Toggle to pause time progression

    void Start()
    {
        // Optional: Initialize time or sky position
        timeOfDay = 0f; // Start at the beginning of the day
    }

    void Update()
    {
        if (!pauseTime)
        {
            UpdateTime();
            RotateSky();
        }
    }

    /// <summary>
    /// Updates the time of day based on the day length.
    /// </summary>
    void UpdateTime()
    {
        // Increment time based on real-time seconds
        timeOfDay += Time.deltaTime / dayLengthInSeconds;
        timeText.text = Mathf.Round(timeOfDay * 24).ToString();
        // Reset timeOfDay to loop the cycle (0-1 range)
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
            Debug.Log("A new day has started!");
        }
    }

    /// <summary>
    /// Rotates the sky object based on the current time of day.
    /// </summary>
    void RotateSky()
    {
        // Map timeOfDay (0-1) to rotation angle (0-360 degrees)
        float rotationAngle = timeOfDay * 360f;

        // Apply rotation to the sky object
        sky.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
    }
}