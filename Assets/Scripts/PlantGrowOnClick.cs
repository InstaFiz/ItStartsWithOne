using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowOnClick : MonoBehaviour
{
    // Set in the inspector
    private int currentProgression = 0;

    [Header("Growth Settings")]
    public int timeBetweenGrowths;
    public int maxGrowth;

    private bool hasFinishedGrowth = false; // Checks if final stage reached
    private bool isGrowing = false; // Prevents mulitple invokes

    private void OnMouseDown()
    {
        // Starts growth when object clicked
        if (!isGrowing)
        {
            isGrowing = true;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.plantSeedClip); // Play sound from AudioManager

            // Calls growth function after timeBetweenGrowths
            InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
        }
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

            ScoreManager.Instance.AddReputation(1); // Increase reputation when fully grown

            CancelInvoke("Growth"); // Stops repeating when hasFinishedGrowth is true
        }
    }
}