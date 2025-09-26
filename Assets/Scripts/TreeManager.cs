using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    public int curTree = 0;
    GameObject daTree;
    PlantGrowth daTreeScript;

    public Text treeUIText;
    public Button yes;
    public Button no;
    public Button okay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        daTree = gameObject.transform.GetChild(curTree).gameObject;
        daTreeScript = daTree.GetComponent<PlantGrowth>();

        if (daTreeScript.currentProgression == -1)
        {
            treeUIText.text = "There is no tree here.\nWould you like to plant one?";
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
            okay.gameObject.SetActive(false);
        }
        else
        {
            treeUIText.text = "A tree is\nplanted here!";
            yes.gameObject.SetActive(false);
            no.gameObject.SetActive(false);
            okay.gameObject.SetActive(true);
        }
    }

    public void growthDirectory()
    {
        daTree.GetComponent<PlantGrowth>().StartGrowth();
    }
}
