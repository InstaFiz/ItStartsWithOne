using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Set in the inspector
    public int treeType;
    public int currentProgression = -1;
    public int waterProgression = -1;
    public int timeBetweenGrowths = 10;
    public int maxGrowth;
    public int curTime = 10;
    public bool halted = true;

    public GameObject treeArray;
    public TreeManager treeArrayScript;
    public GameObject daTutorial;
    public Tutorial daTutorialScript;
    public Canvas treeOptions;
    public Canvas seedOptions;

    // private bool hasFinishedGrowth = false;

    void Start()
    {
        treeArrayScript = treeArray.GetComponent<TreeManager>();
        daTutorialScript = daTutorial.GetComponent <Tutorial>();
        maxGrowth = 5;
    }
    
    void Update()
    {
        for (int i = 0; i <= maxGrowth; i++)
        {
            if (i == currentProgression)
                gameObject.transform.GetChild(i - treeType).gameObject.SetActive(true);
            else
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (daTutorialScript.finished)
        {
            treeArrayScript.viewingTree = true;
            treeArrayScript.curTree = gameObject.transform.GetSiblingIndex();
            if (currentProgression > -1)
                treeOptions.enabled = true;
            else
                seedOptions.enabled = true;
        }
    }

    public void StartGrowth()
    {
        waterProgression += 2;
        treeArrayScript.waterSupply--;

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
                currentProgression += 2;
            }

            if (currentProgression < maxGrowth)
            {
                curTime = timeBetweenGrowths;
                InvokeRepeating("CountDown", 1, 1);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.growClip);
            }
            else
            {
                ScoreManager.Instance.AddTree(1 + treeType);
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
