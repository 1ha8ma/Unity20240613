using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenController : MonoBehaviour
{
    //�e��I�u�W�F�N�g�̐���
    public GameObject scoreTextObject;//�X�R�A
    public GameObject gameResultObject;//�Q�[���I�[�o�[���Q�[���N���A

    //�e�L�X�g
    //private Text scoreText;
    //private Text gameResult;

    // Start is called before the first frame update
    void Start()
    {
        //�e�팋�ʂ��I�u�W�F�N�g�ɓn��
        this.scoreTextObject.GetComponent<TextMeshProUGUI>().text = "SCORE : " + SceneData.score;

        //�Q�[���N���A
        if (SceneData.totalBlocks == 0)
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text = "GAME CLEAR";
            this.gameResultObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        //�Q�[���I�[�o�[
        else
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text = "GAME OVER";
            this.gameResultObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    public void OnStartButtonPressed()
    {
        GameManager.instance.ReturnToStart();
    }
}
