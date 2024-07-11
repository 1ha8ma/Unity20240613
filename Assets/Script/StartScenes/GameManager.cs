using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�B��̃C���X�^���X�Ƃ��ĐÓI�ϐ��𐶐�
    public static GameManager instance;

    //�V���O���g���ɂ��邽�߂Ɍ����炠����������āA�Ȃ�������C���X�^���X������Awake
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //�X�^�[�g���\�b�h
    public void StartGame()
    {
        SceneData.score = 0;
        SceneManager.LoadScene("Game");
    }

    //�G���h���\�b�h
    public void EndGame(int Blocks)
    {
        //�l�������X�R�A�ƃ��U���g��ʂֈړ�
        SceneData.score = ScoreScript.instance.GetCurrentScore();
        SceneData.totalBlocks = Blocks;
        SceneManager.LoadScene("Result");
    }
    //���X�^�[�g���\�b�h
    public void ReturnToStart()
    {
        SceneManager.LoadScene("Start");
    }

    //���X�^�[�g���������\�b�h
    public void ResetGame()
    {
        SceneData.score = 0;
        SceneData.totalBlocks = 0;

        //�S�Ẵu���b�N���폜
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Blocks");

        foreach(GameObject block in blocks)
        {
            Destroy(block);
        }

        //�X�R�A�̏�����
        if(ScoreScript.instance!=null)
        {
            ScoreScript.instance.ScoreManager(-ScoreScript.instance.GetCurrentScore());
        }
    }
}
