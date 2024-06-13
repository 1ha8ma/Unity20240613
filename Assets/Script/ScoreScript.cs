using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    GameObject score;
    GameObject block;
    static int totalScore = 0;
    public static ScoreScript a;
    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score");
        this.block = GameObject.Find("BlockPrefab");
    }

    // Update is called once per frame
    public void ScrerManager(int score)
    {
        totalScore += score;
        
    }
}
