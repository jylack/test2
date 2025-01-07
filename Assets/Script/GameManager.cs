using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static GameManager instance;//스태틱 빈 껍데기 만듬.
    float score; //점수
    bool isGameOver;//게임오버여부

    public static GameManager Instance   { get; private set; }

    public HealthUI healthUI;

    public int killCount;
    public int KillCount {  get { return killCount; } }
    public void AddKillCount()
    {
        killCount++;
    }
    //collision
    public void IsHitCollision(Collision collision)
    {

    }

    public void IsHit()
    {
        healthUI.IsHit();
    }

    public void AddScore()
    {
        score+=100;
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

    private void Awake()
    {
        healthUI = GetComponent<HealthUI>();

        //sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
        killCount = 0;

        if (Instance == null)//맨 처음 호출이라 instance가 텅비었을떈?
        {
            Instance = this;//이 스크립트 컴포넌트를 instrance 껍데기에 담아라.
            DontDestroyOnLoad(gameObject);//그리고 이 오브젝트 파괴하지 말아주세요
        }
        else if(Instance != this) //안전망
        {
            Destroy(gameObject);//그렇지 않으면 파괴
        }

    }

   

    private void Start()
    {

        score = 0;
        isGameOver = false;
    }


}
