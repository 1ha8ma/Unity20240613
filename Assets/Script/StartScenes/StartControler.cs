using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartControler : MonoBehaviour
{
    //�X�^�[�g�{�^���������ꂽ��C���X�^���X�𐶐�
    public void OnStartButtonPressed()
    {
        GameManager.instance.StartGame();
    }
}
