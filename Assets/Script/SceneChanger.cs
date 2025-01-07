using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬관리자 기능 사용 예정

public class SceneChanger : MonoBehaviour
{

    //public string currentSceneName;

    private void Start() 
    {
        //currentSceneName = SceneManager.GetActiveScene().name;

    }



    void Update()
    {


        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Stage1Scene
                SceneManager.LoadScene(1);

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                //CreditScene
                SceneManager.LoadScene(2);
            }

            
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.anyKeyDown == true)
            {
                //TitleScene
                SceneManager.LoadScene(0);
            }

        }
    }
}
