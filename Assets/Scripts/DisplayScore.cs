using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;
    public GameObject treeArray;
    public TreeManager treeArrayScript;
    public GameObject daTutorial;
    public Tutorial daTutorialScript;

    public float curTime = 300f;
    string timer;

    int minutes;
    int seconds;

    void Start()
    {
        curTime = 300f;
        treeArrayScript = treeArray.GetComponent<TreeManager>();
        daTutorialScript = daTutorial.GetComponent<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        minutes = Mathf.FloorToInt(curTime / 60);
        seconds = Mathf.FloorToInt(curTime % 60);
        timer = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (curTime > 0f && daTutorialScript.finished)
        {
            curTime -= Time.deltaTime;
        }
        
        if (curTime <= 0f && daTutorialScript.finished) {
            curTime = 0f;
            daTutorialScript.won = false;
            daTutorialScript.Increment();
        }

        scoreText.text = "Reputation:\n" + ScoreManager.Instance.repText + "\nWater supply: " + treeArrayScript.waterSupply + "\nTime left: " + timer;
    }

    public void TimePenalty()
    {
        if (daTutorialScript.finished)
        {
            curTime -= 30f;
            treeArrayScript.waterSupply += 3;
        }
    }
}
