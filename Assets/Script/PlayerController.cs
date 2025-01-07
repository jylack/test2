using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;//게임 오브젝트를 담을 수 있는 껍데기.
    public GameObject scendBulletPrefab;//둘쨰 총알 담을 게임 오브젝트
    public GameObject thirdBulletPrefab;//셋쨰 총알 담을 게임 오브젝트

    //Transform playerTr; //트랜스폼 껍데기.
    Rigidbody2D playerRb;
    
    AudioSource playerAudio;//오디오 소스

    public AudioClip[] ShotSoundClip;//오디오클립

    public ParticleSystem explodeParticlePrefab;


    Vector2 pushPower; //미는 힘 선언

    Vector3 tempPos;//임시 포지션값
    Quaternion tempRot;//임시 회전값

    public float moveSpeed;//이동속도
    public float maxSpeed ;//최대속도

    int healthPoint; //플레이어 현재 체력
    int maxHealthPoint;//플레이어 최대체력

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
        //playerTr = GetComponent<Transform>();//이 스크립트가 붙어있는 오브젝트에서 컴포넌트 가져오기    
        playerRb = GetComponent<Rigidbody2D>();//리지드 바디 담아두기.
        playerAudio = GetComponent<AudioSource>();
        playerAudio.volume = 0.1f;


        pushPower = Vector2.zero;//시작과 동시에 0으로 초기화
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
                //아래 넷다 같은 코드
                //playerTr.position = playerTr.position + new Vector3 (-0.01f, 0, 0);//좌측 -0.01f
                //playerTr.Translate(new Vector3(-0.01f, 0, 0));
                //playerTr.Translate(-0.01f, 0, 0);//명시적으로 우리가 만든 이 PlayerTr 내용 조작
                //transform.Translate(-0.01f, 0, 0); //내장된 transform 

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

        //'플레이 모드'중  L키가 눌린다면?
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            tempRot = transform.rotation; //L키가 눌리면 현재 플레이어 회전 담기.

            tempPos = transform.position; //L키가 눌리면 현재 플레이어 위치 담기.
            //tempPos.y += 0.5f;//플레이어보다 살짝앞에.
            tempPos.x -= 0.5f;
            //bulletPrefab.transform.position = playerTr.position;
            //인스턴스화를 해라(이 프리팹을, 이위치에서 , 이 회전률로)
            Instantiate(bulletPrefab,tempPos,tempRot);//인스턴스화 시킨다 ,총알프리팹을

            //if (isDoubleFire)
            //{
                tempPos = transform.position; //L키가 눌리면 현재 플레이어 위치 담기.
                                              //tempPos.y += 0.5f;//플레이어보다 살짝앞에.
                tempPos.x += 0.5f;

                Instantiate(bulletPrefab, tempPos, tempRot);//인스턴스화 시킨다 ,총알프리팹을
            //}
            playerAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            tempPos = transform.position;
            

            Instantiate(thirdBulletPrefab, tempPos, transform.rotation);
            playerAudio.PlayOneShot(ShotSoundClip[1]);

        }

        //Bullet라는 게임 오브젝트가 하이어라키에 추가되었으면 좋겠따.
        //생성된 bullet엔 bulletController 스크립트도 있었으면 좋겠다.
        //그 총알이 스크립트대로 움직였으면 좋겠따.



        //이동 벡터 정규화 및 속도 조정, Normalize는 사용한 객체를 변화시킴.normalized는 읽기전용 객체변화 x
        //pushPower.Normalize();//정규화 시킴
        pushPower = pushPower.normalized * moveSpeed;

        playerRb.AddForce(pushPower);//정규화된 수치를 AddForce시킴

        //velocity는 속도(속력 + 방향 ) , magnitude는 그냥 퓨어(현재?) 속도 그자체.
        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
    }
}
