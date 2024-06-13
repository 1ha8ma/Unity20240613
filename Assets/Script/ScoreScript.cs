using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    //クラスの唯一のインスタンスを保持するための静的な変数
    public static ScoreScript instance;
    //スコアの表示するためのTextコンポーネントとトータルスコア
    public GameObject scoreText;
    private int totalScore = 0;
    //プライベートコンストラクタ

    private void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //既に存在する場合は新しいインスタンスを破棄
        else
        {
            Destroy(gameObject);//既にインスタンスが存在する場合は破棄ｈｈ
        }
    }

    //反映されるためのメソッドを定義
    private void Start()
    {
        
    }

    //スコアを更新して、Textコンポーネントに反映する
    public void ScoreManager(int score)
    {
        totalScore += score;
        //コンポーネントを表示する
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        this.scoreText.GetComponent<TextMeshProUGUI>().text ="Score : "+ totalScore.ToString();
    }
}
