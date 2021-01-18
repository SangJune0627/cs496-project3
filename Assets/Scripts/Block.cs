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
        int index = Random.Range(0,items.Length + 1);
        if(index < items.Length){
            Instantiate(items[index], transform.position, Quaternion.identity);
        }
    }
}
