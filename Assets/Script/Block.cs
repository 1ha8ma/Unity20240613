using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{
    public int score = 10;
    private BrockGenerator blockgenerator;

    private void Start()
    {
        blockgenerator = FindObjectOfType<BrockGenerator>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScrerManager(score);   
        //スコアをScoreScriptに追加
        //インスタンスがある状態だったら
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("インスタンスがありません。");
        }
        GetComponent<AudioSource>().Play();
        //トータルブロックの削除メソッド
        blockgenerator.BlockDestroyed();
        //ゲームオブジェクトを削除
        Destroy(gameObject);
    }
}
