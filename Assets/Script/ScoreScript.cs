using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //�N���X�̗B��̃C���X�^���X��ێ����邽�߂̐ÓI�ȕϐ�
    public static ScoreScript instance;
    //�X�R�A�̕\�����邽�߂�Text�R���|�[�l���g�ƃg�[�^���X�R�A
    public  TextMeshProUGUI scoreText;
    private int totalScore = 0;
    //�v���C�x�[�g�R���X�g���N�^

    void Awake()
    {
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;//�V�[�������[�h���ꂽ���ɌĂяo�����C�x���g��o�^
        }
        //���ɑ��݂���ꍇ�͐V�����C���X�^���X��j��
        else
        {
            Destroy(gameObject);//���ɃC���X�^���X�����݂���ꍇ�͔j������
        }
    }

    //���f����邽�߂̃��\�b�h���`
    private void Start()
    {
        Initialize();
    }

    //�X�R�A���X�V���āAText�R���|�[�l���g�ɔ��f����
    public void ScoreManager(int score)
    {
        totalScore += score;
        //�R���|�[�l���g��\������
        UpdateScoreText();
    }

    //�X�R�A��Text�R���|�[�l���g�ɕ\�����郁�\�b�h
    private void UpdateScoreText()
    {
        //this.scoreText.GetComponent<TextMeshProUGUI>().text ="Score : "+ totalScore.ToString();
        if(scoreText!=null)
        {
            scoreText.text="Score:"+totalScore.ToString();
        }
    }

    //�g�[�^���̃X�R�A
    public int GetCurrentScore()
    {
        return totalScore;
    }

    //������
    public void Initialize()
    {
        //�X�R�A�̃^�O���擾���A�X�R�A��������������
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");

        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }

        //�X�R�A������
        totalScore = 0;
    }

    //�V�[�����Ăяo���ꂽ���ɃC�x���g��o�^
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //�V�[�������[�h���ꂽ�㏉����
        StartCoroutine(InitializeAfterFlame());
    }

    private IEnumerator InitializeAfterFlame()
    {
        //�t���[�����I���܂ł܂�
        yield return null;
        Initialize();
    }

    //�C�x���g�̉���
    private void OnDestroy()
    {
        //����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
