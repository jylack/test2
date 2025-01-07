using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Image hpImage;
    Image bossHpImage;  

    GameObject playerGameObject;//플레이어담기
    GameObject BossGameObject;

    float playerMaxHP;
    float playerCurrHP;
    
    float bossMaxHP;
    float bossCurrHP;

    // Start is called before the first frame update
    void Start()
    {
        //hpImage = GameObject.Find("HealthPointImg")?.GetComponent<Image>();// GetComponent<Image>();
        //playerGameObject = GameObject.FindWithTag("Player");
        //playerMaxHP = playerGameObject.GetComponent<PlayerController>() .GetMaxHP();
        //playerCurrHP = playerMaxHP;
        
    }

    public void Init()
    {
        hpImage = GameObject.Find("PlayerHealthPointImg").GetComponent<Image>();// GetComponent<Image>();
        playerGameObject = GameObject.FindWithTag("Player");
        playerMaxHP = playerGameObject.GetComponent<PlayerController>().GetMaxHP();
        playerCurrHP = playerGameObject.GetComponent<PlayerController>().GetCurrentHP();

        if(GameManager.Instance.GetSceneIndex() == (int)SceneName.BossScene)
        {
            bossHpImage = GameObject.Find("BossHealthPointImg").GetComponent<Image>();// GetComponent<Image>();
            BossGameObject = GameObject.FindWithTag("Boss");
            bossMaxHP = BossGameObject.GetComponent<BossEnemyController>().GetMaxHP();
            bossCurrHP = bossMaxHP;
        }
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

    public void IsBossHit()
    {
        if (GameManager.Instance.GetGameOver() == false)
        {
            bossCurrHP = BossGameObject.GetComponent<BossEnemyController>().GetCurrentHP();
        }
        else
        {
            bossCurrHP = 0;
        }

        float toFill = (float)bossCurrHP / (float)bossMaxHP;
        Color tempColor = new Color(1 - toFill, toFill, 0, 1);
        //Debug.Log(toFill);
        bossHpImage.color = tempColor;
        bossHpImage.fillAmount = toFill;//이미지 컴포넌트의 fillamount 수치 대입 가능
    }


}
