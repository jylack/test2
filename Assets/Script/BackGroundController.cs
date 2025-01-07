using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    float moveSpeed;
    Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Init();
        moveSpeed = 0.01f;
        tempPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -moveSpeed, 0);

        if(transform.position.y < -11.0f)
        {
            transform.position = tempPos;
        }
    }
}
