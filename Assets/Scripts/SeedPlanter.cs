using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedPlanter : MonoBehaviour
{
    public Text seedText;
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
                seedText.text = "Currently have: " + treeArrayScript.lesserSeeds;
                break;
            case 1:
                seedText.text = "Currently have: " + treeArrayScript.greaterSeeds;
                break;
        }
    }
}
