using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartControler : MonoBehaviour
{
    //スタートボタンが押されたらインスタンスを生成
    public void OnStartButtonPressed()
    {
        GameManager.instance.StartGame();
    }
}
