using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Block : MonoBehaviour
{
    public string[] items;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        int index = Random.Range(0, items.Length + 3);
        Vector2 position = transform.position;
        position.y = position.y + 0.5f;
        if (index < items.Length)
        {
            PhotonNetwork.Instantiate(items[index], position, Quaternion.identity);
        }
    }
}
