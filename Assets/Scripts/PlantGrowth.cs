using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    private int currentProgression = -1;
    public int timeBetweenGrowths;
    public int maxGrowth;

    public Canvas treeOptions;

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
        /*
        if (currentProgression == -1)
        {
            InvokeRepeating("Growth", 0, timeBetweenGrowths);
        }
        */

        treeOptions.enabled = true;
    }

    // Grows untils maxGrowth stage
    public void Growth()
    {
        if (currentProgression < maxGrowth)
        {
            currentProgression++;
        }

        if (currentProgression < maxGrowth)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.growClip);
        }
        else
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip);
            CancelInvoke();
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
