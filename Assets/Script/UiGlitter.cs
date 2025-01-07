using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGlitter : MonoBehaviour
{
    //UIGlitter 스크립트는, 어두워졋다가 밝아졌따를 반복할 대상에게 줄것이다.
    //매 업데이트마다 숫자가 0 에서 1까지 0.01증가하게 만든다.
    //만약 , 1을 초과하면 역으로 0까지 감소하게 만든다.
    //매 업데이트마다 위 숫자를 Text 커 ㅁ포넌트 속 Color값에 반영한다.

    Color tempColor; //RGBA가 모두 내장된 자료형
    Text textComponent;//텍스트 컴포넌트 담을 껍데기

    bool isForward; //정방향여부
    float glitterSpeed; //반짝이는 속도


    //선언부
    void Start()
    {
        //초기화 
        isForward = true;
        tempColor = new Color(1, 0.5962107f, 0, 1);
        textComponent = GetComponent<Text>();//내 진짜 컴포넌트 담기

        glitterSpeed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        //업데이트 부분
        if (isForward)
        {
            tempColor.a += glitterSpeed;

            if(tempColor.a >= 1)
            {
                isForward = false;
            }
        }
        else
        {
            tempColor.a -= glitterSpeed;

            if(tempColor.a <= 0f)
            {
                isForward = true;
            }
        }




        //tempColor.a -= 0.01f;
        //if(tempColor.a < 0 )
        //    tempColor.a = 1;

        //반영 부분
        GetComponent<Text>().color = tempColor;//임시 색을 반영
    }
}
