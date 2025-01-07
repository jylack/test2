using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //static GameManager instance;//스태틱 빈 껍데기 만듬.
    float score; //점수
    bool isGameOver;//게임오버여부

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

        if (Instance == null)//맨 처음 호출이라 instance가 텅비었을떈?
        {
            Instance = this;//이 스크립트 컴포넌트를 instrance 껍데기에 담아라.
            DontDestroyOnLoad(gameObject);//그리고 이 오브젝트 파괴하지 말아주세요
        }
        else if (Instance != this) //안전망
        {
            Destroy(gameObject);//그렇지 않으면 파괴
        }

    }



    private void Start()
    {

        score = 0;
    }


}
