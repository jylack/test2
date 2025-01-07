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

    public void UpdateScore()
    {

    }

    void Update()
    {
        float tempScore = GameManager.Instance.GetScore();
        string toShow = "Score : " + tempScore.ToString("0000");
        scoreTextGameObject.text = toShow;


    }
}
