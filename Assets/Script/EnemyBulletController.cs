using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    Rigidbody2D enemyBulletRb;//물리컴포넌트
    Vector2 moveDirection;//이동방향
    GameObject playerInfo; //플레이어 정보를 담을 빈 오브젝트
    //ㄷPlayerController plCr;

    // Start is called before the first frame update
    private void Awake()
    {
        
    
    
        enemyBulletRb = GetComponent<Rigidbody2D>();
        playerInfo = GameObject.Find("Player");
        //plCr = playerInfo.GetComponent<PlayerController>();

        //플레이어 좌표 - 현재 총알의 좌표.
        moveDirection = playerInfo.transform.position - transform.position;

        moveDirection.Normalize();//어느방향이라도 1로 이동하게끔 

        enemyBulletRb.AddForce(moveDirection * 10,ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌이 발생하면 여기 코드들이 실행됩니다.

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

        //▼Tag 방식
        //if (collision.gameObject.tag == "Wall") //벽 충돌시 삭제
        //{
        //    Destroy(gameObject);
        //}

        //혹은 더 짧게
        if (collision.gameObject.tag == "Player") //플레이어 충돌시 삭제
        {
            collision.gameObject.GetComponent<PlayerController>().DecreaseHp();
            
            //위와 같음
            //plCr.DecreaseHp();
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }



}
