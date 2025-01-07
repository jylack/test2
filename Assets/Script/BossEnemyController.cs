using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemyController : MonoBehaviour
{
    Rigidbody2D enemyRb;
    Vector2 moveForce;
    public GameObject enemyBulletPrefab; //�� �Ѿ� �ȾƳ��� �����ս���
    public GameObject player;

    public ParticleSystem explodeParticlePrefab;


    int coolTime;

    int healthPoint = 30;

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
        moveForce = new Vector2(0, -0.1f);//�ʱ� �̴� �� ����
        coolTime = 0;
        player = GameObject.Find("Player");
    }
    public void IsDead()
    {
        //int count = spawner.GetComponent<EnemySpawner>().enemyCount--;
        //Debug.Log(count);
        Destroy(gameObject);
    }

    void BossPatten(int index)
    {
        if (index == 0)
        {
            coolTime++;

            if (coolTime >= 200)
            {
                var tempVPos = transform.position;
                var tempPos = player.transform.position - transform.position;

                Instantiate(enemyBulletPrefab, tempVPos, transform.rotation);
                //enemyBulletPrefab.transform.Translate(tempPos);

                tempPos = player.transform.position - transform.position;
                tempVPos.x = transform.position.x + 1f;
                //enemyBulletPrefab.transform.position += tempVPos;

                Instantiate(enemyBulletPrefab, tempVPos, transform.rotation);
                //enemyBulletPrefab.transform.Translate(tempPos);

                tempPos = player.transform.position - transform.position;
                tempVPos.x = transform.position.x - 1f;
                enemyBulletPrefab.transform.position += tempVPos;

                Instantiate(enemyBulletPrefab, tempVPos, transform.rotation);
                //enemyBulletPrefab.transform.Translate(tempPos);

                coolTime = 0;
            }
        }
        else if (index == 1)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        //���� ���ʿ���  y��ǥ�� 2�� �ɶ����� ���� �޾��̵��Ѵ�.
        if (transform.position.y < 2)
        {
            enemyRb.AddForce(moveForce);
        }
        else
        {
            var isPlayerDead = GameManager.Instance.GetGameOver();

            if (isPlayerDead == false)
            {
                BossPatten(0);
            }
        }
    }
}
