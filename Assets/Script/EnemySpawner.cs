using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;//적 기체 프리팹 설계도
    public GameObject BossPrefab;//적 기체 프리팹 설계도
    
    int coolTime;
    public int enemyCount;
    int spawnSeed;
    Vector3 tempPosition;

    bool isBossTrun;
    bool isBossCreat;


    // Start is called before the first frame update
    void Start()
    {
        isBossTrun = false;
        isBossCreat = false;    

        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            isBossCreat = true;
            isBossTrun = true;
        }

        coolTime = 0;
        spawnSeed = 300;
        tempPosition = Vector3.zero;
        enemyCount = 0;
    }

    

    // Update is called once per frame
    void Update()
    {

        coolTime++;

        if (coolTime > spawnSeed && isBossTrun == false)
        {


            tempPosition = transform.position;

            tempPosition.x = Random.Range(-2, 2.0f);

            Instantiate(enemyPrefab, tempPosition, transform.rotation);

            //enemyPrefab.GetComponent<EnemyController>().SetSpawner(gameObject);
            coolTime = 0;

            if (GameManager.Instance.GetScore() > 3000f)
            {
                //isBossCreat = true;
                //isBossTrun = true;
                GameManager.Instance.SceneChange(3);

            }
        }

        if (isBossTrun && isBossCreat)
        {
            Instantiate(BossPrefab, transform.position, transform.rotation);
            GameManager.Instance.Init();
            isBossCreat = false;    
        }

        
    }




}
