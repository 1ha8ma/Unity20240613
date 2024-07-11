using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    //�v���C���[�̈ړ����x
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
        //���E�̃L�[����͂���Ƒ��x��ύX���Ĉړ�
        myRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, 0.0f);//GetAxis�œ��͂��Ƃ��Ă���"Horizontal"�͐��������̓��͂��󂯎��Ƃ����Ӗ��B"Vertical"����ꂽ�琂�������̓��͂��󂯎��Ƃ����Ӗ��ɂȂ�
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�{�[�����Փ˂�������ʉ���炷
        if (collision.gameObject.CompareTag("Ball"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
