using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int reputation = 0;

    private void Awake()
    {
        // Only one ScoreManager can exist
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Carries between scenes
    }

    public void AddReputation(int amount)
    {
        reputation += amount;
    }
}
