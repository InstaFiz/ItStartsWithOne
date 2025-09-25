using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    private int currentProgression = -1;
    public int timeBetweenGrowths;
    public int maxGrowth;

    // private bool hasFinishedGrowth = false;

    void Start()
    {
        // Calls growth function after timeBetweenGrowths
        // InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
    }
    
    void Update()
    {
        for (int i = 0; i <= maxGrowth; i++)
        {
            if (i == currentProgression)
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            else
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (currentProgression == -1)
        {
            currentProgression = 0;
            InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
        }
    }

    void clicked()
    {
        if (currentProgression == -1)
        {
            currentProgression = 0;
            InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
        }
    }

    // Grows untils maxGrowth stage
    public void Growth()
    {
        /*
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
        */

        if (currentProgression < maxGrowth)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.growClip);
            currentProgression++;
        }
        else
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip);
        }

        /*
        if (currentProgression == maxGrowth && !hasFinishedGrowth)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip); // Play sound from AudioManager
            hasFinishedGrowth = true; // Prevent replay
        }
        */
    }
}
