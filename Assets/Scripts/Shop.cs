using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int coins;
    public int[] prices;

    public GameObject treeArray;
    public TreeManager treeArrayScript;

    public Text welcomeText;

    // Start is called before the first frame update
    void Start()
    {
        treeArrayScript = treeArray.GetComponent<TreeManager>();
        coins = 300;
        prices = new int[3];

        prices[0] = 100;
        prices[1] = 200;
        prices[2] = 50;
    }

    // Update is called once per frame
    void Update()
    {
        welcomeText.text = "Welcome to the shop!\nCoins: " + coins;
    }

    public void Purchase(int thisItem)
    {
        if (prices[thisItem] <= coins)
        {
            coins -= prices[thisItem];

            switch (thisItem)
            {
                case 0:
                    treeArrayScript.lesserSeeds += 1;
                    break;
                case 1:
                    treeArrayScript.greaterSeeds += 1;
                    break;
                case 2:
                    treeArrayScript.waterSupply += 5;
                    break;
            }
        }
    }
}
