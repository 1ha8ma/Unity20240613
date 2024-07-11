using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenController : MonoBehaviour
{
    //各種オブジェクトの生成
    public GameObject scoreTextObject;//スコア
    public GameObject gameResultObject;//ゲームオーバーかゲームクリア

    //テキスト
    //private Text scoreText;
    //private Text gameResult;

    // Start is called before the first frame update
    void Start()
    {
        //各種結果をオブジェクトに渡す
        this.scoreTextObject.GetComponent<TextMeshProUGUI>().text = "SCORE : " + SceneData.score;

        //ゲームクリア
        if (SceneData.totalBlocks == 0)
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text = "GAME CLEAR";
            this.gameResultObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        //ゲームオーバー
        else
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text = "GAME OVER";
            this.gameResultObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    public void OnStartButtonPressed()
    {
        GameManager.instance.ReturnToStart();
    }
}
