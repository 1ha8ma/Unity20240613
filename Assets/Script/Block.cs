using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{
    public int score = 10;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScrerManager(score);   
        //スコアをScoreScriptに追加
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("インスタンスがありません。");
        }
        //ゲームオブジェクトを削除
        Destroy(gameObject);
    }
}
