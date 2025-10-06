using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int treesPlanted = 0;
    public int repValue = 0;
    public string repText = "Unremarkable";

    public GameObject townArray;
    public GameObject treeArray;
    public TreeManager treeArrayScript;
    public GameObject daTutorial;
    public Tutorial daTutorialScript;

    void Start()
    {
        treesPlanted = 0;
        repValue = 0;
        treeArrayScript = treeArray.GetComponent<TreeManager>();
        daTutorialScript = daTutorial.GetComponent<Tutorial>();
    }

    private void Awake()
    {
        // Only one ScoreManager can exist
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddTree(int amount)
    {
        treesPlanted += amount;

        if (treesPlanted == 3)
        {
            repValue = 1;
            treeArrayScript.waterSupply += 9;
        }

        if (treesPlanted == 6)
        {
            repValue = 2;
            treeArrayScript.waterSupply += 12;
        }

        if (treesPlanted == 10)
        {
            repValue = 3;
            daTutorialScript.won = true;
            daTutorialScript.Increment();
        }
    }

    void Update()
    {
        if (repValue <= 0)
            repText = "Unremarkable";
        if (repValue == 1)
            repText = "Modest";
        if (repValue == 2)
            repText = "Impressive";
        if (repValue == 3)
            repText = "Amazing!";

        for (int i = 0; i <= 3; i++)
        {
            if (i == repValue)
                townArray.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            else
                townArray.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
