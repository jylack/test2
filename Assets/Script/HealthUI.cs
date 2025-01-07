using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Image hpImage;
    GameObject playerGameObject;//플레이어담기

    float playerMaxHP;
    float playerCurrHP;

    // Start is called before the first frame update
    void Start()
    {
        hpImage = GameObject.Find("HealthPointImg").GetComponent<Image>();// GetComponent<Image>();
        playerGameObject = GameObject.FindWithTag("Player");
        playerMaxHP = playerGameObject.GetComponent<PlayerController>() .GetMaxHP();
        playerCurrHP = playerMaxHP;
        
    }

    public void IsHit()
    {
        if (GameManager.Instance.GetGameOver() == false)
        {
            playerCurrHP = playerGameObject.GetComponent<PlayerController>().GetCurrentHP();
        }
        else
        {
            playerCurrHP = 0;
        }



        float toFill = (float)playerCurrHP / (float)playerMaxHP;
        Color tempColor = new Color(1 - toFill, toFill, 0, 1);
        //Debug.Log(toFill);
        hpImage.color = tempColor;
        hpImage.fillAmount = toFill;//이미지 컴포넌트의 fillamount 수치 대입 가능
    }

    
}
