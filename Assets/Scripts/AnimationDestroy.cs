using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AnimationDestroy : MonoBehaviourPun
{
    Animator animator;
    float exitTime = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > exitTime)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
