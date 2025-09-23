using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    private int currentProgression = 0;
    public int timeBetweenGrowths;
    public int maxGrowth;

    private bool hasFinishedGrowth = false;

    void Start()
    {
        // Calls growth function after timeBetweenGrowths
        InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
    }
    
    // Grows untils maxGrowth stage
    public void Growth()
    {
        if (currentProgression != maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
        }
        if (currentProgression > 0 && currentProgression < maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression - 1).gameObject.SetActive(false);
        }
        if (currentProgression < maxGrowth) 
        {
            if (currentProgression < maxGrowth - 1) // If not near final stage
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.growClip); // Play sound from AudioManager
            }

            currentProgression++;
        }
        if (currentProgression == maxGrowth && !hasFinishedGrowth)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip); // Play sound from AudioManager
            hasFinishedGrowth = true; // Prevent replay
        }
    }
}
