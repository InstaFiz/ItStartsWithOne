using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedPlanterHeader : MonoBehaviour
{
    public Text welcomeText;

    public GameObject treeArray;
    public TreeManager treeArrayScript;

    // Start is called before the first frame update
    void Start()
    {
        treeArrayScript = treeArray.GetComponent<TreeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        welcomeText.text = "Plant a tree here!\nWater supply: " + treeArrayScript.waterSupply;
    }
}