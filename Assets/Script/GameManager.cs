using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //static GameManager instance;//����ƽ �� ������ ����.
    float score; //����
    bool isGameOver;//���ӿ�������

    public static GameManager Instance { get; private set; }

    HealthUI healthUI;

    SceneChanger changer;

    ScoreUI scoreUI;

    //public int killCount;
    //public int KillCount { get { return killCount; } }
    //public void AddKillCount()
    //{
    //    killCount++;
    //}

    //collision
    
    public int GetSceneIndex()
    {
        return changer.GetSceneIndex();
    }

    public void SceneChange(int SceneNum)
    {
        changer.SceneChange(SceneNum);
    }

    public void IsHit()
    {
        healthUI.IsHit();
    }

    public void IsBossHit()
    {
        healthUI.IsBossHit();
    }

    public void AddScore()
    {
        score += 100;
        scoreUI.UpdateScore();
    }
    public float GetScore()
    {
        return score;
    }
    public void SetIsGameOver(bool isOver)
    {
        isGameOver = isOver;
    }
    public bool GetGameOver()
    {
        return isGameOver;
    }

    public void Init()
    {

        scoreUI = GameObject.Find("ScoreText").GetComponent <ScoreUI>();
        healthUI = GetComponent<HealthUI>();
        healthUI.Init();
        scoreUI.Init();
        scoreUI.UpdateScore();
        isGameOver = false;

    }

    private void Awake()
    {
        changer = GetComponent<SceneChanger>();
        

        //sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
        //killCount = 0;

        if (Instance == null)//�� ó�� ȣ���̶� instance�� �ֺ������?
        {
            Instance = this;//�� ��ũ��Ʈ ������Ʈ�� instrance �����⿡ ��ƶ�.
            DontDestroyOnLoad(gameObject);//�׸��� �� ������Ʈ �ı����� �����ּ���
        }
        else if (Instance != this) //������
        {
            Destroy(gameObject);//�׷��� ������ �ı�
        }

    }



    private void Start()
    {

        score = 0;
    }


}
