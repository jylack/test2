using UnityEngine;
using UnityEngine.SceneManagement;//씬관리자 기능 사용 예정
public enum SceneName
{
    TitleScene, Stage1Scene, CreditScene, BossScene
}

public class SceneChanger : MonoBehaviour
{

 

    public void SceneChange(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
        SceneManager.sceneLoaded += SceneInit;
    }

    public void SceneInit(Scene scene, LoadSceneMode mode)
    {
        switch ((SceneName)scene.buildIndex)
        {
            case SceneName.TitleScene:

                break;
            case SceneName.Stage1Scene:
                GameManager.Instance.Init();

                break;
            case SceneName.CreditScene:

                break;
            case SceneName.BossScene:
                GameManager.Instance.Init();
                break;

        }

    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {


        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Stage1Scene
                //SceneManager.LoadScene(1);
                SceneChange(1);

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                //CreditScene
                //SceneManager.LoadScene(2);
                SceneChange(2);

            }


        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.anyKeyDown == true)
            {
                //TitleScene
                //SceneManager.LoadScene(0);
                SceneChange(0);

            }

        }
    }
}
