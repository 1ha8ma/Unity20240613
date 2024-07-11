using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //�{�[���̈ړ��̑������w��
    public float speed = 5.0f;
    Rigidbody myRigidBody;
    //�����̍ŏ��l
    public float minSpeed = 5.0f;
    //�����̍ő�l
    public float maxSpeed = 10.0f;
    Transform myTransForm;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�ɃA�N�Z�X���ĕϐ��ɕێ����Ă���
        myRigidBody = GetComponent<Rigidbody>();
        //�E�΂�45�x�ɐi��
        myRigidBody.velocity = new Vector3(speed, speed, 0.0f);
        myTransForm = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̑������擾
        Vector3 velocity=myRigidBody.velocity;
        //�����v�Z
        float clampspeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        //���x�̕ύX
        myRigidBody.velocity = velocity.normalized*clampspeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bar"))
        {
            //Bar�̈ʒu���擾
            Vector3 barPos = collision.transform.position;
            //Ball�̈ʒu���擾
            Vector3 ballPos=myTransForm.position;
            //Bar���猩��ball�̕������v�Z
            Vector3 direction=(ballPos-barPos).normalized;
            //�����̎擾
            float speed=myRigidBody.velocity.magnitude;
            //���x��ύX
            myRigidBody.velocity = direction * speed;
        }
    }
}
