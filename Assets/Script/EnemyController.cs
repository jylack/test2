using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //�̵��� �Ϸ�Ǹ� �÷��̾ ���� ������ �ֱ�� �Ѿ��� �߻��Ѵ�.

    Rigidbody2D enemyRb;
    Vector2 moveForce;
    public GameObject enemyBulletPrefab; //�� �Ѿ� �ȾƳ��� �����ս���
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
        enemyRb = GetComponent<Rigidbody2D>();//����ֱ�
        moveForce = new Vector2(0, -1);//�ʱ� �̴� �� ����
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
        //�÷��̾ �׾����� �ȿ�����.
        //�̷��κ� ����ȭ �ϰ�ʹ�. = ������ ����.
        isPlayerDead = GameManager.Instance.GetGameOver();

        if (isPlayerDead == false)
        {

            //���� ���ʿ���  y��ǥ�� 3�� �ɶ����� ���� �޾��̵��Ѵ�.
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
