using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    //プレイヤーの移動速度
    public float speed = 10.0f;
    Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右のキーを入力すると速度を変更して移動
        myRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, 0.0f);//GetAxisで入力をとっている"Horizontal"は水平方向の入力を受け取るという意味。"Vertical"を入れたら垂直方向の入力を受け取るという意味になる
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ボールが衝突したら効果音を鳴らす
        if (collision.gameObject.CompareTag("Ball"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
