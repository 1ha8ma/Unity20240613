using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int score = 10;
    //何かとぶつかった時、ビルトインメソッド
    
    private void OnCollisionEnter(Collision collision)
    {
        //ゲームオブジェクトを削除
        Destroy(gameObject);
    }
}
