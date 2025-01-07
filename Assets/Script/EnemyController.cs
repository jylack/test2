using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //이동이 완료되면 플레이어를 향해 일정한 주기로 총알을 발사한다.

    Rigidbody2D enemyRb;
    Vector2 moveForce;
    public GameObject enemyBulletPrefab; //적 총알 꽂아넣을 프리팹슬롯
    public ParticleSystem explodeParticlePrefab;

    //public GameObject spawner;

    int coolTime;
    bool isPlayerDead;

    int healthPoint = 2;
    public void DecreaseHp()
    {
        healthPoint--;

        if (healthPoint < 0)
        {
            healthPoint = 0;
            Die();
        }
    }

    void Die()
    {
        //GameManager.Instance.SetIsGameOver(true);
        Instantiate(explodeParticlePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();//담아주기
        moveForce = new Vector2(0, -1);//초기 미는 힘 설정
        coolTime = 0;
        isPlayerDead = false;


    }

    //public void SetSpawner(GameObject obj)
    //{
    //    spawner = obj;
    //}

    //public void IsDead()
    //{
    //    //int count = spawner.GetComponent<EnemySpawner>().enemyCount--;
    //    //Debug.Log(count);
    //    Destroy(gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        //플레이어가 죽었으면 안움직임.
        //이런부분 최적화 하고싶다. = 옵저버 패턴.
        isPlayerDead = GameManager.Instance.GetGameOver();

        if (isPlayerDead == false)
        {

            //맵의 위쪽에서  y좌표가 3이 될때까지 힘을 받아이동한다.
            if (transform.position.y > 3)
            {
                enemyRb.AddForce(moveForce);
            }
            else
            {
                coolTime++;

                if (coolTime >= 200)
                {
                    Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
                    coolTime = 0;
                }
            }
        }
    }
}
