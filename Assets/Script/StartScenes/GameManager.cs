using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //唯一のインスタンスとして静的変数を生成
    public static GameManager instance;

    //シングルトンにするために元からあったら消して、なかったらインスタンス化するAwake
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //スタートメソッド
    public void StartGame()
    {
        SceneData.score = 0;
        SceneManager.LoadScene("Game");
    }

    //エンドメソッド
    public void EndGame(int Blocks)
    {
        //獲得したスコアとリザルト画面へ移動
        SceneData.score = ScoreScript.instance.GetCurrentScore();
        SceneData.totalBlocks = Blocks;
        SceneManager.LoadScene("Result");
    }
    //リスタートメソッド
    public void ReturnToStart()
    {
        SceneManager.LoadScene("Start");
    }

    //リスタート初期化メソッド
    public void ResetGame()
    {
        SceneData.score = 0;
        SceneData.totalBlocks = 0;

        //全てのブロックを削除
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Blocks");

        foreach(GameObject block in blocks)
        {
            Destroy(block);
        }

        //スコアの初期化
        if(ScoreScript.instance!=null)
        {
            ScoreScript.instance.ScoreManager(-ScoreScript.instance.GetCurrentScore());
        }
    }
}
