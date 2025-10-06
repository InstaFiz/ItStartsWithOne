using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    public int currentProgression = -1;
    public int waterProgression = -1;
    public int timeBetweenGrowths = 10;
    public int maxGrowth;
    public int curTime = 10;
    public bool halted = true;

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
        treeArrayScript.viewingTree = true;
        treeOptions.enabled = true;
        treeArrayScript.curTree = gameObject.transform.GetSiblingIndex();
    }

    public void StartGrowth()
    {
        waterProgression++;

        if (halted)
        {
            halted = false;
            curTime = timeBetweenGrowths;
            InvokeRepeating("Growth", 0, timeBetweenGrowths);
        }
    }

    // Grows untils maxGrowth stage
    public void Growth()
    {
        CancelInvoke("CountDown");

        if (currentProgression < waterProgression)
        {
            if (currentProgression < maxGrowth)
            {
                currentProgression++;
            }

            if (currentProgression < maxGrowth)
            {
                curTime = timeBetweenGrowths;
                InvokeRepeating("CountDown", 1, 1);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.growClip);
            }
            else
            {
                ScoreManager.Instance.AddTree(1);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.finalGrowClip);
                CancelInvoke("Growth");
            }
        }
        else
        {
            halted = true;
            CancelInvoke("Growth");
        }
    }

    void CountDown()
    {
        curTime--;
    }
}
