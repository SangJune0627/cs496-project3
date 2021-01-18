using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        int index = Random.Range(0,items.Length + 3);
        Vector2 position = transform.position;
        position.y = position.y + 0.5f;
        if(index < items.Length){
            Instantiate(items[index], position, Quaternion.identity);
        }
    }
}
