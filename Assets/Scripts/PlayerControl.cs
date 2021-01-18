using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3f;

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;
    bool isMovingHorizontal;
    bool isMovingVertical;
    bool wasMovingVertical;

    public int bubble_count;
    public int bubble_strength;

    public GameObject Dying;

    Animator animator;
    public GameObject bubblePrefab;
    Vector2 lookdirection = new Vector2(0,-1);
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bubble_count = 1;
        bubble_strength = 1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // Debug.Log("H:" + horizontal);
        // Debug.Log("V:" + vertical);
        isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;
        isMovingVertical = Mathf.Abs(vertical) > 0.5f;
        // Vector2 move = new Vector2(horizontal, vertical);
        // if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)){
        //     lookdirection.Set(move.x, move.y);
        //     lookdirection.Normalize();
        // }
        // animator.SetFloat("Look X", lookdirection.x);
        // animator.SetFloat("Look Y", lookdirection.y);

        if(Input.GetKeyDown(KeyCode.Space)){
            // Debug.Log("A");
            MakeBubble();
        }
        
    }

    void FixedUpdate(){
        Vector2 position = rigidbody2D.position;
        // position.x = position.x + speed * horizontal * Time.deltaTime;
        // position.y = position.y + speed * vertical * Time.deltaTime;
        if (isMovingVertical && isMovingHorizontal)
        {
            //moving in both directions, prioritize later
            if (wasMovingVertical)
            {
                position.x = position.x + speed * horizontal * Time.deltaTime;
                lookdirection.Set(horizontal, 0);
                lookdirection.Normalize();
            }
            else
            {
                position.y = position.y + speed * vertical * Time.deltaTime;
                lookdirection.Set(0, vertical);
                lookdirection.Normalize();
            }
        }
        else if (isMovingHorizontal)
        {
            position.x = position.x + speed * horizontal * Time.deltaTime;
            wasMovingVertical = false;
            lookdirection.Set(horizontal, 0);
            lookdirection.Normalize();
        }
        else if (isMovingVertical)
        {
            position.y = position.y + speed * vertical * Time.deltaTime;
            wasMovingVertical = true;
            lookdirection.Set(0, vertical);
            lookdirection.Normalize();
        }
        else
        {

        }
        animator.SetFloat("Look X", lookdirection.x);
        animator.SetFloat("Look Y", lookdirection.y);
        rigidbody2D.MovePosition(position);
    }

    void MakeBubble(){
        if(bubble_count > 0){
            Vector2 temp = rigidbody2D.position;
            temp.x = Mathf.Floor(rigidbody2D.position.x) + 0.5f;
            temp.y = Mathf.Floor(rigidbody2D.position.y) + 0.5f;
            // Debug.Log(Physics2D.OverlapBox(temp, new Vector2(1,1), 0));
            if(Physics2D.OverlapBoxAll(temp, new Vector2(0.5f,0.5f), 0).Length == 1){
                GameObject bubbleobject = Instantiate(bubblePrefab, temp, Quaternion.identity);
                Bubble bubble = bubbleobject.GetComponent<Bubble>();
                bubble.GetOwner(this);
                bubble_count -= 1;
            }
        }
    }

    public void Die(){
        Vector2 position = transform.position;
        position.y = position.y + 0.5f;
        GameObject dying = Instantiate(Dying, position, Quaternion.identity);
    }
}
