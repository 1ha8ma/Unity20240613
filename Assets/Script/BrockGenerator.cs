using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrockGenerator : MonoBehaviour
{
    //GameObject�̒ǉ�
    public GameObject blockPrefab;
    //�X�p��
    float span = 0.2f;
    int row = 3;
    int col = 5;
    int BlockScaleX = 2;
    int BlockScaleY = 1;
    int scoreDef = 0;
    int totalBlocks = 0;//�u���b�N�̑���

    // Start is called before the first frame update
    void Start()
    {
        //�u���b�N�̃|�W�V����
        float bx, by;
        bx = -5;
        by = 5;
        totalBlocks = row * col;
        //�u���b�N�̔z�u
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //�Q�[���I�u�W�F�N�g�̐���
                GameObject go = Instantiate(blockPrefab);
                go.transform.position = new Vector3(bx + (j * (span + BlockScaleX)), by + i * (span + BlockScaleY), 0);
                go.tag = "Blocks";
            }
        }

        ScoreScript.instance.ScoreManager(scoreDef);
    }

    //�Q�[���N���A
    public void BlockDestroyed()
    {
        //�u���b�N�ɓ�����x��totalBlocks���}�C�i�X����Ă���
        totalBlocks--;
        SceneData.totalBlocks = totalBlocks;
        //�����u���b�N�����������烊�U���g��ʂɈڍs
        if(totalBlocks <= 0)
        {
            GameManager.instance.EndGame(totalBlocks);
        }
    }
}
