using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{
    public int score = 10;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //ScoreScript.instance.ScrerManager(score);   
        //�X�R�A��ScoreScript�ɒǉ�
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("�C���X�^���X������܂���B");
        }
        //�Q�[���I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
