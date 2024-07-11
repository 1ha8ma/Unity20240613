using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{
    public int score = 10;
    private BrockGenerator blockgenerator;

    private void Start()
    {
        blockgenerator = FindObjectOfType<BrockGenerator>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScrerManager(score);   
        //�X�R�A��ScoreScript�ɒǉ�
        //�C���X�^���X�������Ԃ�������
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("�C���X�^���X������܂���B");
        }
        GetComponent<AudioSource>().Play();
        //�g�[�^���u���b�N�̍폜���\�b�h
        blockgenerator.BlockDestroyed();
        //�Q�[���I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
