using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    AudioSource soundManagerAudioSource;
    public AudioClip explodeSFX;
    public ParticleSystem explodeParticlePrefab;

    float moveSpeed;

    void Start()
    {        
        //�̰� ���� �Ŵ��� ã�Ƽ� �ű��ִ� ����� �ҽ� ������Ʈ ���
        soundManagerAudioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        
        //���� ���� ����� ���ӸŴ����� ��� �ְ� �ѻ������ �̷���
        //GameManager.Instance.GetComponent<AudioSource>();

        //2.2���Ŀ� ������� ����
        //Destroy(gameObject,2);
        moveSpeed = 0.1f;

        if (gameObject.name == "Boom")
        {
            moveSpeed = 0.01f;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹�� �߻��ϸ� ���� �ڵ���� ����˴ϴ�.
        /*
        //    collision //�浹�� ��� ������Ʈ
        //collision.gameObject //�浹�� ��� ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
        //collision.gameObject.transform //�浹�� ��� ������Ʈ�� �پ��ִ� ���� ������Ʈ�� Ʈ������

        //if (collision.gameObject.name  == "Enemy")
        //{
        //    Destroy(gameObject);
        //    Debug.Log("�÷��̾��̸�.");
        //}
        //����� ���
        //if(collision.gameObject.name =="Square")
        //{
        //    Destroy(gameObject);
        //}
        */
        //��Tag ���
        if (collision.gameObject.tag == "Wall") //�� �浹�� ����
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        //Ȥ�� �� ª��
        if (collision.gameObject.tag == "Enemy") //�÷��̾� �浹�� ����
        {
            //GameManager.Instance.killCount++;
            //Debug.Log(GameManager.Instance.killCount);

            soundManagerAudioSource.PlayOneShot(explodeSFX);
                        //gameObject.GetComponent<BoxCollider2D>().edgeRadius += 10f;
            //collision.gameObject.GetComponent<EnemyController>().IsDead();

            Destroy(gameObject);
            //Instantiate(explodeParticlePrefab,transform.position,transform.rotation);
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<EnemyController>().DecreaseHp();

            //GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
            //���� �����ڵ�
            GameManager.Instance.AddScore();
            

            //GameManager.Instance.AddKillCount();
        }
        if (collision.gameObject.tag == "Boss") //�÷��̾� �浹�� ����
        {
            soundManagerAudioSource.PlayOneShot(explodeSFX);
            Destroy(gameObject);

            collision.gameObject.GetComponent<BossEnemyController>().DecreaseHp();
            
            GameManager.Instance.AddScore();
            GameManager.Instance.AddScore();
            GameManager.Instance.AddScore();
            GameManager.Instance.AddScore();
            GameManager.Instance.AddScore();
        }



    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed, 0);

        //���ѻ��� ���� 3���� ���
        //1. ��ǥ�Ѿ�� ����
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }



    }
}
