using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverImgController : MonoBehaviour
{
    Image gameOverImg;
    Color toChange;

    // Start is called before the first frame update
    void Start()
    {
        gameOverImg = GetComponent<Image>();
        toChange = new Color(0.5f, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameOver() == true)
        {
            toChange.a += 0.01f;
            gameOverImg.color = toChange;
        }
    }
}
