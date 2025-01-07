using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;//�� ��ü ������ ���赵

    Vector3 tempPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        tempPosition = Vector3.zero;
        SpawnePlayer();
    }

    public void SpawnePlayer()
    {
        tempPosition = transform.position;

        Instantiate(playerPrefab, tempPosition, transform.rotation);
       playerPrefab.transform.Translate(new Vector3(0.06f, -4f, 0));

    }
}
