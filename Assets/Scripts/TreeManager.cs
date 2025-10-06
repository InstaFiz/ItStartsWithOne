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

    public int waterSupply;

    // Start is called before the first frame update
    void Start()
    {
        waterSupply = 9;
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

        if (waterSupply <= 0)
        {
            treeUIText.text = "You have no\nwater left!";
            yes.gameObject.SetActive(false);
            no.gameObject.SetActive(false);
            okay.gameObject.SetActive(true);
        }
        else if (daTreeScript.currentProgression == -1)
        {
            treeUIText.text = "There is no tree here.\nWould you like to plant one?";
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
            okay.gameObject.SetActive(false);
        }
        else if (daTreeScript.currentProgression < daTreeScript.maxGrowth)
        {
            if (daTreeScript.waterProgression < daTreeScript.maxGrowth)
            {
                yes.gameObject.SetActive(true);
                no.gameObject.SetActive(true);
                okay.gameObject.SetActive(false);

                if (daTreeScript.halted)
                {
                    treeUIText.text = "This tree has stopped growing!\nIt needs more water. Give it more?";
                }
                else
                {
                    treeUIText.text = "This tree will reach the next stage in " + daTreeScript.curTime + "...\nAdd water?";
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

    public void growthDirectory()
    {
        daTree.GetComponent<PlantGrowth>().StartGrowth();
    }

    public void notViewingTree()
    {
        viewingTree = false;
    }
}
