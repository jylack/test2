using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text scoreTextGameObject;
    
    void Start()
    {
        scoreTextGameObject = GetComponent<Text>();        
    }

    public void Init()
    {
        scoreTextGameObject = GetComponent<Text>();
        float tempScore = GameManager.Instance.GetScore();
        string toShow = "Score : " + tempScore.ToString("0000");
        scoreTextGameObject.text = toShow;
    }

    public void UpdateScore()
    {
        float tempScore = GameManager.Instance.GetScore();
        string toShow = "Score : " + tempScore.ToString("0000");
        scoreTextGameObject.text = toShow;
    }


}
