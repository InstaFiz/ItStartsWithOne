using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public Canvas daCanvas;
    public Text daText;
    public int curPage = 0;
    public bool finished = false;
    public bool won;

    // Start is called before the first frame update
    void Start()
    {
        curPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curPage)
        {
            case 0:
                daText.text = "Welcome to It Starts With One!";
                break;
            case 1:
                daText.text = "In this game, you have been tasked with planting trees in a town that could really use some.";
                break;
            case 2:
                daText.text = "The brown squares around the town indicate plots where you can plant a tree. Clicking on a plot will bring up options regarding the tree.";
                break;
            case 3:
                daText.text = "From there, you can see how much water the tree has and how close it is to full maturity.";
                break;
            case 4:
                daText.text = "If the plot has no tree, you will have the option to plant one. If there *is* a tree, you will have the option to give it water.";
                break;
            case 5:
                daText.text = "Your trees need a sufficient amount of water in order to keep growing. That being said, you don't have all the water in the world.";
                break;
            case 6:
                daText.text = "Your water supply is indicated in the top right. If you plant enough trees, citizens will take a shine to your cause and give you more water.";
                break;
            case 7:
                daText.text = "If you're dead out of water, you can get more manually with the button on the right. However, this will take 30 seconds off the clock.";
                break;
            case 8:
                daText.text = "You can also see your reputation in the top right. Plant a lot of trees and aim for a high reputation to win the game!";
                break;
            case 9:
                daText.text = "You have a limited amount of time to pull this off. Good luck!";
                break;
            case 10:
                finished = true;
                daCanvas.enabled = false;
                break;
            case 11:
                finished = false;
                daCanvas.enabled = true;
                if (won)
                    daText.text = "Wonderful job! The town has much more appeal now. Healthier, too! Click the button to play again.";
                else
                    daText.text = "Ah... it seems like you weren't able to plant enough trees within the projected time. You'll have to take your efforts elsewhere. Click the button to try again.";
                break;
            case 12:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    public void Increment()
    {
        curPage++;
    }
}
