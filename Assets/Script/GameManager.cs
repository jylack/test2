using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static GameManager instance;//����ƽ �� ������ ����.
    float score; //����
    bool isGameOver;//���ӿ�������

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

        if (Instance == null)//�� ó�� ȣ���̶� instance�� �ֺ������?
        {
            Instance = this;//�� ��ũ��Ʈ ������Ʈ�� instrance �����⿡ ��ƶ�.
            DontDestroyOnLoad(gameObject);//�׸��� �� ������Ʈ �ı����� �����ּ���
        }
        else if(Instance != this) //������
        {
            Destroy(gameObject);//�׷��� ������ �ı�
        }

    }

   

    private void Start()
    {

        score = 0;
        isGameOver = false;
    }


}
