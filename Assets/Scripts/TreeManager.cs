using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    public int curTree = 0;
    public bool viewingTree = false;
    public GameObject daSquare;
    GameObject daTree;
    PlantGrowth daTreeScript;

    public Text treeUIText;
    public Button yes;
    public Button no;
    public Button okay;

    public int thisTreeProgress;
    public int thisWaterProgress;

    public int lesserSeeds;
    public int greaterSeeds;
    public int waterSupply;

    public Canvas treeOptions;
    public Canvas seedOptions;

    // Start is called before the first frame update
    void Start()
    {
        lesserSeeds = 0;
        greaterSeeds = 0;
        waterSupply = 6;
    }

    // Update is called once per frame
    void Update()
    {
        daTree = gameObject.transform.GetChild(curTree).gameObject;
        daTreeScript = daTree.GetComponent<PlantGrowth>();

        if (viewingTree)
            daSquare.gameObject.SetActive(true);
        else
            daSquare.gameObject.SetActive(false);

        daSquare.transform.position = new Vector3(daTree.transform.position.x, daTree.transform.position.y, daTree.transform.position.z);

        if (daTreeScript.currentProgression < daTreeScript.maxGrowth)
        {
            if (daTreeScript.waterProgression < daTreeScript.maxGrowth)
            {
                yes.gameObject.SetActive(true);
                no.gameObject.SetActive(true);
                okay.gameObject.SetActive(false);

                if (daTreeScript.halted)
                {
                    treeUIText.text = "This tree has stopped growing!\nAdd water? (" + waterSupply + " left)";
                }
                else
                {
                    treeUIText.text = "This tree will reach the next stage in " + daTreeScript.curTime + "...\nAdd water? (" + waterSupply + " left)";
                }
            }
            else
            {
                treeUIText.text = "This tree will reach the next stage in " + daTreeScript.curTime + "\nIt doesn't need more water.";
                yes.gameObject.SetActive(false);
                no.gameObject.SetActive(false);
                okay.gameObject.SetActive(true);
            }
        }
        else
        {
            treeUIText.text = "This tree has\nfinished planting!";
            yes.gameObject.SetActive(false);
            no.gameObject.SetActive(false);
            okay.gameObject.SetActive(true);
        }

        thisTreeProgress = daTreeScript.currentProgression;
        thisWaterProgress = daTreeScript.waterProgression;
    }

    public void SetTreeType(int daType)
    {
        daTree.GetComponent<PlantGrowth>().treeType = daType;
    }

    public void seedDirectory(int daType)
    {
        if (daType == 0)
            if (lesserSeeds > 0 && waterSupply > 0)
            {
                lesserSeeds--;
                daTree.GetComponent<PlantGrowth>().StartGrowth();
                seedOptions.enabled = false;
                treeOptions.enabled = true;
            }
        if (daType == 1)
            if (greaterSeeds > 0 && waterSupply > 0)
            {
                greaterSeeds--;
                daTree.GetComponent<PlantGrowth>().StartGrowth();
                seedOptions.enabled = false;
                treeOptions.enabled = true;
            }
    }

    public void growthDirectory()
    {
        if (waterSupply > 0)
            daTree.GetComponent<PlantGrowth>().StartGrowth();
    }

    public void notViewingTree()
    {
        viewingTree = false;
    }
}
