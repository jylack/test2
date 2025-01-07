using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGlitter : MonoBehaviour
{
    //UIGlitter ��ũ��Ʈ��, ��ο����ٰ� ��������� �ݺ��� ��󿡰� �ٰ��̴�.
    //�� ������Ʈ���� ���ڰ� 0 ���� 1���� 0.01�����ϰ� �����.
    //���� , 1�� �ʰ��ϸ� ������ 0���� �����ϰ� �����.
    //�� ������Ʈ���� �� ���ڸ� Text Ŀ ������Ʈ �� Color���� �ݿ��Ѵ�.

    Color tempColor; //RGBA�� ��� ����� �ڷ���
    Text textComponent;//�ؽ�Ʈ ������Ʈ ���� ������

    bool isForward; //�����⿩��
    float glitterSpeed; //��¦�̴� �ӵ�


    //�����
    void Start()
    {
        //�ʱ�ȭ 
        isForward = true;
        tempColor = new Color(1, 0.5962107f, 0, 1);
        textComponent = GetComponent<Text>();//�� ��¥ ������Ʈ ���

        glitterSpeed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        //������Ʈ �κ�
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

        //�ݿ� �κ�
        GetComponent<Text>().color = tempColor;//�ӽ� ���� �ݿ�
    }
}
