using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    float Bubbletimer = 3.0f;
    Collider2D collider2D;

    PlayerControl owner;

    int strength;

    public GameObject Center;
    public GameObject Up_Ex;
    public GameObject Up;
    public GameObject Down_Ex;
    public GameObject Down;
    public GameObject Right;
    public GameObject Right_Ex;
    public GameObject Left;
    public GameObject Left_Ex;

    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Bubbletimer -= Time.deltaTime;
        if(Bubbletimer < 1){
            // animator.SetTrigger("Pop");
        }
        if(Bubbletimer < 0){
            Pop();
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        PlayerControl control = other.GetComponent<PlayerControl>();
        if(control != null){
            collider2D.isTrigger = false;
        }
    }

    public void GetOwner(PlayerControl player){
        owner = player;
        strength = owner.bubble_strength;
    }

    void Pop(){
        owner.bubble_count += 1;
        Vector2 center_position = transform.position;
        Destroy(gameObject);
        GameObject center_obj = Instantiate(Center, center_position, Quaternion.identity);
        for(int i=0;i<strength;i++){
            Vector2 center = transform.position;
            center.x = center.x + i + 1;        
            Collider2D other = Physics2D.OverlapBox(center,new Vector2(0.5f,0.5f),0);
            if(other != null){
                if(other.GetComponent<Bubble>() != null){
                other.GetComponent<Bubble>().Pop();
                Destroy(other.gameObject);
                }
                else if(other.GetComponent<Block>() != null){
                    Destroy(other.gameObject);
                    break;
                }
                else{
                    Destroy(other.gameObject);
                    if(i < strength - 1){
                        GameObject right_ex = Instantiate(Right_Ex, center, Quaternion.identity);
                    }
                    else{
                        GameObject right = Instantiate(Right, center, Quaternion.identity);
                    }
                }
            }
            else{
                if(i < strength - 1){
                    GameObject right_ex = Instantiate(Right_Ex, center, Quaternion.identity);
                }
                else{
                    GameObject right = Instantiate(Right, center, Quaternion.identity);
                }
            }
            
        }
        for(int i=0;i<strength;i++){
            Vector2 center = transform.position;
            center.x = center.x - i - 1;
            Collider2D other = Physics2D.OverlapBox(center,new Vector2(0.5f,0.5f),0);
            if(other != null){
                if(other.GetComponent<Bubble>() != null){
                other.GetComponent<Bubble>().Pop();
                Destroy(other.gameObject);
                }
                else if(other.GetComponent<Block>() != null){
                    Destroy(other.gameObject);
                    break;
                }
                else{
                    Destroy(other.gameObject);
                    if(i < strength - 1){
                        GameObject left_ex = Instantiate(Left_Ex, center, Quaternion.identity);
                    }
                    else{
                        GameObject left = Instantiate(Left, center, Quaternion.identity);
                    }
                }
            }
            else{
                if(i < strength - 1){
                    GameObject left_ex = Instantiate(Left_Ex, center, Quaternion.identity);
                }
                else{
                    GameObject left = Instantiate(Left, center, Quaternion.identity);
                }
            }
        }
        for(int i=0;i<strength;i++){
            Vector2 center = transform.position;
            center.y = center.y + i + 1;        
            Collider2D other = Physics2D.OverlapBox(center,new Vector2(0.5f,0.5f),0);
            if(other != null){
                if(other.GetComponent<Bubble>() != null){
                other.GetComponent<Bubble>().Pop();
                Destroy(other.gameObject);
                }
                else if(other.GetComponent<Block>() != null){
                    Destroy(other.gameObject);
                    break;
                }
                else{
                    Destroy(other.gameObject);
                    if(i < strength - 1){
                        GameObject up_ex = Instantiate(Up_Ex, center, Quaternion.identity);
                    }
                    else{
                        GameObject up = Instantiate(Up, center, Quaternion.identity);
                    }
                }
            }
            else{
                if(i < strength - 1){
                    GameObject up_ex = Instantiate(Up_Ex, center, Quaternion.identity);
                }
                else{
                    GameObject up = Instantiate(Up, center, Quaternion.identity);
                }
            } 
        }
        for(int i=0;i<strength;i++){
            Vector2 center = transform.position;
            center.y = center.y - i - 1;        
            Collider2D other = Physics2D.OverlapBox(center,new Vector2(0.5f,0.5f),0);
            if(other != null){
                if(other.GetComponent<Bubble>() != null){
                other.GetComponent<Bubble>().Pop();
                Destroy(other.gameObject);
                }
                else if(other.GetComponent<Block>() != null){
                    Destroy(other.gameObject);
                    break;
                }
                else{
                    Destroy(other.gameObject);
                    if(i < strength - 1){
                        GameObject down_ex = Instantiate(Down_Ex, center, Quaternion.identity);
                    }
                    else{
                        GameObject down = Instantiate(Down, center, Quaternion.identity);
                    }
                }
            }
            else{
                if(i < strength - 1){
                    GameObject down_ex = Instantiate(Down_Ex, center, Quaternion.identity);
                }
                else{
                    GameObject down = Instantiate(Down, center, Quaternion.identity);
                }
            }
        }
    }
}
