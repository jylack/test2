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
        //이건 사운드 매니저 찾아서 거기있는 오디오 소스 컴포넌트 담기
        soundManagerAudioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        
        //만약 사운드 기능을 게임매니져가 들고 있게 한사람들은 이런식
        //GameManager.Instance.GetComponent<AudioSource>();

        //2.2초후에 사라지게 만듬
        //Destroy(gameObject,2);
        moveSpeed = 0.1f;

        if (gameObject.name == "Boom")
        {
            moveSpeed = 0.01f;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌이 발생하면 여기 코드들이 실행됩니다.
        /*
        //    collision //충돌한 상대 컴포넌트
        //collision.gameObject //충돌한 상대 컴포넌트가 붙어있는 게임오브젝트
        //collision.gameObject.transform //충돌한 상대 컴포넌트가 붙어있는 게임 오브젝트의 트랜스폼

        //if (collision.gameObject.name  == "Enemy")
        //{
        //    Destroy(gameObject);
        //    Debug.Log("플레이어이름.");
        //}
        //▼기존 방식
        //if(collision.gameObject.name =="Square")
        //{
        //    Destroy(gameObject);
        //}
        */
        //▼Tag 방식
        if (collision.gameObject.tag == "Wall") //벽 충돌시 삭제
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        //혹은 더 짧게
        if (collision.gameObject.tag == "Enemy") //플레이어 충돌시 삭제
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
            //위와 같은코드
            GameManager.Instance.AddScore();
            

            //GameManager.Instance.AddKillCount();
        }
        if (collision.gameObject.tag == "Boss") //플레이어 충돌시 삭제
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

        //무한생성 제거 3가지 방법
        //1. 좌표넘어갈떄 제거
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }



    }
}
