﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        PlayerControl player = other.GetComponent<PlayerControl>();
        if(player != null){
            if(player.bubble_strength < 8){
                player.bubble_strength += 1;
            }
            Destroy(gameObject);
        }
    }
}
