using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //クラスの唯一のインスタンスを保持するための静的な変数
    public static ScoreScript instance;
    //スコアの表示するためのTextコンポーネントとトータルスコア
    public  TextMeshProUGUI scoreText;
    private int totalScore = 0;
    //プライベートコンストラクタ

    void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;//シーンがロードされた時に呼び出されるイベントを登録
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
        Initialize();
    }

    //スコアを更新して、Textコンポーネントに反映する
    public void ScoreManager(int score)
    {
        totalScore += score;
        //コンポーネントを表示する
        UpdateScoreText();
    }

    //スコアをTextコンポーネントに表示するメソッド
    private void UpdateScoreText()
    {
        //this.scoreText.GetComponent<TextMeshProUGUI>().text ="Score : "+ totalScore.ToString();
        if(scoreText!=null)
        {
            scoreText.text="Score:"+totalScore.ToString();
        }
    }

    //トータルのスコア
    public int GetCurrentScore()
    {
        return totalScore;
    }

    //初期化
    public void Initialize()
    {
        //スコアのタグを取得し、スコアを初期化させる
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");

        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }

        //スコア初期化
        totalScore = 0;
    }

    //シーンが呼び出された時にイベントを登録
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //シーンがロードされた後初期化
        StartCoroutine(InitializeAfterFlame());
    }

    private IEnumerator InitializeAfterFlame()
    {
        //フレームが終わるまでまつ
        yield return null;
        Initialize();
    }

    //イベントの解除
    private void OnDestroy()
    {
        //解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
