using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrockGenerator : MonoBehaviour
{
    //GameObjectの追加
    public GameObject blockPrefab;
    //スパン
    float span = 0.2f;
    int row = 3;
    int col = 5;
    int BlockScaleX = 2;
    int BlockScaleY = 1;
    int scoreDef = 0;
    int totalBlocks = 0;//ブロックの総数

    // Start is called before the first frame update
    void Start()
    {
        //ブロックのポジション
        float bx, by;
        bx = -5;
        by = 5;
        totalBlocks = row * col;
        //ブロックの配置
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //ゲームオブジェクトの生成
                GameObject go = Instantiate(blockPrefab);
                go.transform.position = new Vector3(bx + (j * (span + BlockScaleX)), by + i * (span + BlockScaleY), 0);
                go.tag = "Blocks";
            }
        }

        ScoreScript.instance.ScoreManager(scoreDef);
    }

    //ゲームクリア
    public void BlockDestroyed()
    {
        //ブロックに当たる度にtotalBlocksがマイナスされていく
        totalBlocks--;
        SceneData.totalBlocks = totalBlocks;
        //もしブロックが無かったらリザルト画面に移行
        if(totalBlocks <= 0)
        {
            GameManager.instance.EndGame(totalBlocks);
        }
    }
}
