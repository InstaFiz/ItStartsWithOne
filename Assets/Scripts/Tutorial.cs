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
                daText.text = "Welcome to It Starts With One! In this game, you have been tasked with planting trees in a town that could really use some.";
                break;
            case 1:
                daText.text = "Start by visiting the shop via the button on the right. Here, you can buy seeds and water.";
                break;
            case 2:
                daText.text = "Then, click on the brown plots around the town to plant a tree and give it water!";
                break;
            case 3:
                daText.text = "Get more money by planting more trees. Plant enough trees and the town will earn a good reputation!";
                break;
            case 4:
                daText.text = "You have a limited amount of time to pull this off. Good luck!";
                break;
            case 5:
                finished = true;
                daCanvas.enabled = false;
                break;
            case 6:
                finished = false;
                daCanvas.enabled = true;
                if (won)
                    daText.text = "Wonderful job! The town has much more appeal now. Healthier, too! Click the button to play again.";
                else
                    daText.text = "Ah... it seems like you weren't able to plant enough trees within the projected time. You'll have to take your efforts elsewhere. Click the button to try again.";
                break;
            case 7:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    public void Increment()
    {
        curPage++;
    }
}
