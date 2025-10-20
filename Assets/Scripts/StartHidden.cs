using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHidden : MonoBehaviour
{
    public Canvas treeOptions;
    public Canvas daShop;
    public Canvas daSeeds;

    // Start is called before the first frame update
    void Start()
    {
        treeOptions.enabled = false;
        daShop.enabled = false;
        daSeeds.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
