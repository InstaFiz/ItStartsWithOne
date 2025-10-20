using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInfo : MonoBehaviour
{
    public Text shopText;
    public int thisInfo;

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
        switch (thisInfo)
        {
            case 0:
                shopText.text = "Lesser Tree\nCost: 100\nCurrently have: " + treeArrayScript.lesserSeeds;
                break;
            case 1:
                shopText.text = "Greater Tree\nCost: 200\nCurrently have: " + treeArrayScript.greaterSeeds;
                break;
            case 2:
                shopText.text = "Water\nCost: 50\nCurrently have: " + treeArrayScript.waterSupply;
                break;
        }
    }
}
