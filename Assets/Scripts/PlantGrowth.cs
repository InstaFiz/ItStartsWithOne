using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    public int currentProgression = -1;
    public int waterProgression = 0;
    public int timeBetweenGrowths;
    public int maxGrowth;

    public GameObject treeArray;
    public TreeManager treeArrayScript;
    public Canvas treeOptions;

    // private bool hasFinishedGrowth = false;

    void Start()
    {
        treeArrayScript = treeArray.GetComponent<TreeManager>();
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
        treeOptions.enabled = true;
        treeArrayScript.curTree = gameObject.transform.GetSiblingIndex();
    }

    public void StartGrowth()
    {
        InvokeRepeating("Growth", 0, timeBetweenGrowths);
    }

    // Grows untils maxGrowth stage
    public void Growth()
    {
        if (currentProgression < waterProgression)
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
                ScoreManager.Instance.AddTree(1);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip);
                CancelInvoke();
            }
        }
        else
        {
            CancelInvoke();
        }
    }
}
