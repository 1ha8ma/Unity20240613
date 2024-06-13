using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        //�u���b�N�̃|�W�V����
        float bx, by;
        bx = -5;
        by = 5;
        //�u���b�N�̔z�u
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //�Q�[���I�u�W�F�N�g�̐���
                GameObject go = Instantiate(blockPrefab);
                go.transform.position = new Vector3(bx + (j * (span + BlockScaleX)), by + i * (span + BlockScaleY), 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
