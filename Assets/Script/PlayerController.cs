using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;//���� ������Ʈ�� ���� �� �ִ� ������.
    public GameObject scendBulletPrefab;//�Ѥ� �Ѿ� ���� ���� ������Ʈ
    public GameObject thirdBulletPrefab;//�¤� �Ѿ� ���� ���� ������Ʈ

    //Transform playerTr; //Ʈ������ ������.
    Rigidbody2D playerRb;
    
    AudioSource playerAudio;//����� �ҽ�

    public AudioClip[] ShotSoundClip;//�����Ŭ��

    public ParticleSystem explodeParticlePrefab;


    Vector2 pushPower; //�̴� �� ����

    Vector3 tempPos;//�ӽ� �����ǰ�
    Quaternion tempRot;//�ӽ� ȸ����

    public float moveSpeed;//�̵��ӵ�
    public float maxSpeed ;//�ִ�ӵ�

    int healthPoint; //�÷��̾� ���� ü��
    int maxHealthPoint;//�÷��̾� �ִ�ü��

    public bool isDoubleFire;

    bool isMove;

    public int GetCurrentHP()
    {
        return healthPoint;
    }
    public int GetMaxHP()
    {
        return maxHealthPoint;
    }

    public void DecreaseHp()
    {
        GameManager.Instance.IsHit();

        healthPoint--;

        if (healthPoint < 0)
        {
            healthPoint = 0;
            Die();
        }

    }

    void Die()
    {
        GameManager.Instance.SetIsGameOver(true);
        Instantiate(explodeParticlePrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    private void Awake()
    {
        maxHealthPoint = 5;

    }

    void Start()
    {
        //playerTr = GetComponent<Transform>();//�� ��ũ��Ʈ�� �پ��ִ� ������Ʈ���� ������Ʈ ��������    
        playerRb = GetComponent<Rigidbody2D>();//������ �ٵ� ��Ƶα�.
        playerAudio = GetComponent<AudioSource>();
        playerAudio.volume = 0.1f;


        pushPower = Vector2.zero;//���۰� ���ÿ� 0���� �ʱ�ȭ
        isDoubleFire = false;
        moveSpeed = 5f;
        maxSpeed = 10f;
        isMove = true;

        //maxHealthPoint = 5;
        healthPoint = maxHealthPoint;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        isMove = true;

        if (collision.tag == "Wall")
        {
            isMove = false;
        }

    }
    public void IsDead()
    {
        Destroy(gameObject);
    }


    void Update()
    {

        pushPower = Vector2.zero;

        if (transform.position.x > 2.2f)
        {
            playerRb.velocity = Vector2.zero;
            transform.position = new Vector2(2.2f, transform.position.y);           
            //isMove = false;
            return;
        }
        if (transform.position.x < -2.2f)
        {
            playerRb.velocity = Vector2.zero;
            transform.position = new Vector2(-2.2f, transform.position.y);
            //isMove = false;
            return;
        }

        if (isMove)
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                tempRot = transform.rotation;
                tempRot.y = 0;
                transform.rotation = tempRot;
            }

            if (Input.GetKey(KeyCode.A))
            {
                //�Ʒ� �ݴ� ���� �ڵ�
                //playerTr.position = playerTr.position + new Vector3 (-0.01f, 0, 0);//���� -0.01f
                //playerTr.Translate(new Vector3(-0.01f, 0, 0));
                //playerTr.Translate(-0.01f, 0, 0);//��������� �츮�� ���� �� PlayerTr ���� ����
                //transform.Translate(-0.01f, 0, 0); //����� transform 

                //===========
                //playerRb.AddForce(new Vector2(-moveSpeed, 0));
                pushPower.x = -1;
                tempRot = transform.rotation;
                if (tempRot.y > -0.25f)
                {
                    tempRot.y -= 0.05f;
                }

                transform.rotation = tempRot;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                //playerTr.Translate(0.01f, 0, 0);
                //playerRb.AddForce(new Vector2(moveSpeed, 0));
                pushPower.x = 1;
                tempRot = transform.rotation;
                
                if (tempRot.y < 0.25f)
                {
                    tempRot.y += 0.05f;
                }


                transform.rotation = tempRot;
            }

            if (Input.GetKey(KeyCode.W))
            {
                //playerRb.AddForce(new Vector2(0, moveSpeed));
                pushPower.y = 1;

            }
            else if (Input.GetKey(KeyCode.S))
            {
                //playerRb.AddForce(new Vector2(  0,-moveSpeed));
                pushPower.y = -1;

            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            tempPos = transform.position;
            tempPos.y += 1.5f;

            Instantiate(scendBulletPrefab,tempPos,transform.rotation);
            //playerAudio.Play();
            playerAudio.PlayOneShot(ShotSoundClip[0]);
        }

        //'�÷��� ���'��  LŰ�� �����ٸ�?
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            tempRot = transform.rotation; //LŰ�� ������ ���� �÷��̾� ȸ�� ���.

            tempPos = transform.position; //LŰ�� ������ ���� �÷��̾� ��ġ ���.
            //tempPos.y += 0.5f;//�÷��̾�� ��¦�տ�.
            tempPos.x -= 0.5f;
            //bulletPrefab.transform.position = playerTr.position;
            //�ν��Ͻ�ȭ�� �ض�(�� ��������, ����ġ���� , �� ȸ������)
            Instantiate(bulletPrefab,tempPos,tempRot);//�ν��Ͻ�ȭ ��Ų�� ,�Ѿ���������

            //if (isDoubleFire)
            //{
                tempPos = transform.position; //LŰ�� ������ ���� �÷��̾� ��ġ ���.
                                              //tempPos.y += 0.5f;//�÷��̾�� ��¦�տ�.
                tempPos.x += 0.5f;

                Instantiate(bulletPrefab, tempPos, tempRot);//�ν��Ͻ�ȭ ��Ų�� ,�Ѿ���������
            //}
            playerAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            tempPos = transform.position;
            

            Instantiate(thirdBulletPrefab, tempPos, transform.rotation);
            playerAudio.PlayOneShot(ShotSoundClip[1]);

        }

        //Bullet��� ���� ������Ʈ�� ���̾��Ű�� �߰��Ǿ����� ���ڵ�.
        //������ bullet�� bulletController ��ũ��Ʈ�� �־����� ���ڴ�.
        //�� �Ѿ��� ��ũ��Ʈ��� ���������� ���ڵ�.



        //�̵� ���� ����ȭ �� �ӵ� ����, Normalize�� ����� ��ü�� ��ȭ��Ŵ.normalized�� �б����� ��ü��ȭ x
        //pushPower.Normalize();//����ȭ ��Ŵ
        pushPower = pushPower.normalized * moveSpeed;

        playerRb.AddForce(pushPower);//����ȭ�� ��ġ�� AddForce��Ŵ

        //velocity�� �ӵ�(�ӷ� + ���� ) , magnitude�� �׳� ǻ��(����?) �ӵ� ����ü.
        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
    }
}
