using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    Rigidbody2D enemyBulletRb;//����������Ʈ
    Vector2 moveDirection;//�̵�����
    GameObject playerInfo; //�÷��̾� ������ ���� �� ������Ʈ
    //��PlayerController plCr;

    // Start is called before the first frame update
    private void Awake()
    {
        
    
    
        enemyBulletRb = GetComponent<Rigidbody2D>();
        playerInfo = GameObject.Find("Player");
        //plCr = playerInfo.GetComponent<PlayerController>();

        //�÷��̾� ��ǥ - ���� �Ѿ��� ��ǥ.
        moveDirection = playerInfo.transform.position - transform.position;

        moveDirection.Normalize();//��������̶� 1�� �̵��ϰԲ� 

        enemyBulletRb.AddForce(moveDirection * 10,ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹�� �߻��ϸ� ���� �ڵ���� ����˴ϴ�.

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

        //��Tag ���
        //if (collision.gameObject.tag == "Wall") //�� �浹�� ����
        //{
        //    Destroy(gameObject);
        //}

        //Ȥ�� �� ª��
        if (collision.gameObject.tag == "Player") //�÷��̾� �浹�� ����
        {
            collision.gameObject.GetComponent<PlayerController>().DecreaseHp();
            
            //���� ����
            //plCr.DecreaseHp();
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }



}
