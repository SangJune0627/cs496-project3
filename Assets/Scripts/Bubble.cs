using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bubble : MonoBehaviourPun
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
        if (Bubbletimer > 0)
        {
            Bubbletimer -= Time.deltaTime;
        }
        if (Bubbletimer < 0)
        {
            Pop();
            Bubbletimer = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerControl control = other.GetComponent<PlayerControl>();
        if (control != null)
        {
            collider2D.isTrigger = false;
        }
    }

    public void GetOwner(PlayerControl player)
    {
        owner = player;
        strength = owner.bubble_strength;
    }

    void Pop()
    {
        // Debug.Log(owner);
        owner.bubble_count += 1;
        Vector2 center_position = transform.position;
        PhotonNetwork.Destroy(gameObject);
        GameObject center_obj = PhotonNetwork.Instantiate("Center", center_position, Quaternion.identity);
        for (int i = 0; i < strength; i++)
        {
            Vector2 center = transform.position;
            center.x = center.x + i + 1;
            Collider2D other = Physics2D.OverlapBox(center, new Vector2(0.5f, 0.5f), 0);
            if (other != null)
            {
                if (other.GetComponent<Bubble>() != null)
                {
                    other.GetComponent<Bubble>().Pop();
                    PhotonNetwork.Destroy(other.gameObject);

                }
                else if (other.GetComponent<Block>() != null)
                {
                    PhotonNetwork.Destroy(other.gameObject);
                    break;
                }
                else if (other.GetComponent<Wall>() != null)
                {
                    break;
                }
                else
                {
                    if (other.GetComponent<PlayerControl>() != null)
                    {
                        other.GetComponent<PlayerControl>().Die();
                    }
                    PhotonNetwork.Destroy(other.gameObject);
                    if (i < strength - 1)
                    {
                        GameObject right_ex = PhotonNetwork.Instantiate("Right_Ex", center, Quaternion.identity);
                    }
                    else
                    {
                        GameObject right = PhotonNetwork.Instantiate("Right", center, Quaternion.identity);
                    }
                }
            }
            else
            {
                if (i < strength - 1)
                {
                    GameObject right_ex = PhotonNetwork.Instantiate("Right_Ex", center, Quaternion.identity);
                }
                else
                {
                    GameObject right = PhotonNetwork.Instantiate("Right", center, Quaternion.identity);
                }
            }

        }
        for (int i = 0; i < strength; i++)
        {
            Vector2 center = transform.position;
            center.x = center.x - i - 1;
            Collider2D other = Physics2D.OverlapBox(center, new Vector2(0.5f, 0.5f), 0);
            if (other != null)
            {
                if (other.GetComponent<Bubble>() != null)
                {
                    other.GetComponent<Bubble>().Pop();
                    PhotonNetwork.Destroy(other.gameObject);
                }
                else if (other.GetComponent<Block>() != null)
                {
                    PhotonNetwork.Destroy(other.gameObject);
                    break;
                }
                else if (other.GetComponent<Wall>() != null)
                {
                    break;
                }
                else
                {
                    if (other.GetComponent<PlayerControl>() != null)
                    {
                        other.GetComponent<PlayerControl>().Die();
                    }
                    PhotonNetwork.Destroy(other.gameObject);
                    if (i < strength - 1)
                    {
                        GameObject left_ex = PhotonNetwork.Instantiate("Left_Ex", center, Quaternion.identity);
                    }
                    else
                    {
                        GameObject left = PhotonNetwork.Instantiate("Left", center, Quaternion.identity);
                    }
                }
            }
            else
            {
                if (i < strength - 1)
                {
                    GameObject left_ex = PhotonNetwork.Instantiate("Left_Ex", center, Quaternion.identity);
                }
                else
                {
                    GameObject left = PhotonNetwork.Instantiate("Left", center, Quaternion.identity);
                }
            }
        }
        for (int i = 0; i < strength; i++)
        {
            Vector2 center = transform.position;
            center.y = center.y + i + 1;
            Collider2D other = Physics2D.OverlapBox(center, new Vector2(0.5f, 0.5f), 0);
            if (other != null)
            {
                if (other.GetComponent<Bubble>() != null)
                {
                    other.GetComponent<Bubble>().Pop();
                    PhotonNetwork.Destroy(other.gameObject);
                }
                else if (other.GetComponent<Block>() != null)
                {
                    PhotonNetwork.Destroy(other.gameObject);
                    break;
                }
                else if (other.GetComponent<Wall>() != null)
                {
                    break;
                }
                else
                {
                    if (other.GetComponent<PlayerControl>() != null)
                    {
                        other.GetComponent<PlayerControl>().Die();
                    }
                    PhotonNetwork.Destroy(other.gameObject);
                    if (i < strength - 1)
                    {
                        GameObject up_ex = PhotonNetwork.Instantiate("Up_Ex", center, Quaternion.identity);
                    }
                    else
                    {
                        GameObject up = PhotonNetwork.Instantiate("Up", center, Quaternion.identity);
                    }
                }
            }
            else
            {
                if (i < strength - 1)
                {
                    GameObject up_ex = PhotonNetwork.Instantiate("Up_Ex", center, Quaternion.identity);
                }
                else
                {
                    GameObject up = PhotonNetwork.Instantiate("Up", center, Quaternion.identity);
                }
            }
        }
        for (int i = 0; i < strength; i++)
        {
            Vector2 center = transform.position;
            center.y = center.y - i - 1;
            Collider2D other = Physics2D.OverlapBox(center, new Vector2(0.5f, 0.5f), 0);
            if (other != null)
            {
                if (other.GetComponent<Bubble>() != null)
                {
                    other.GetComponent<Bubble>().Pop();
                    PhotonNetwork.Destroy(other.gameObject);
                }
                else if (other.GetComponent<Block>() != null)
                {
                    PhotonNetwork.Destroy(other.gameObject);
                    break;
                }
                else if (other.GetComponent<Wall>() != null)
                {
                    break;
                }
                else
                {
                    if (other.GetComponent<PlayerControl>() != null)
                    {
                        other.GetComponent<PlayerControl>().Die();
                    }
                    PhotonNetwork.Destroy(other.gameObject);
                    if (i < strength - 1)
                    {
                        GameObject down_ex = PhotonNetwork.Instantiate("Down_Ex", center, Quaternion.identity);
                    }
                    else
                    {
                        GameObject down = PhotonNetwork.Instantiate("Down", center, Quaternion.identity);
                    }
                }
            }
            else
            {
                if (i < strength - 1)
                {
                    GameObject down_ex = PhotonNetwork.Instantiate("Down_Ex", center, Quaternion.identity);
                }
                else
                {
                    GameObject down = PhotonNetwork.Instantiate("Down", center, Quaternion.identity);
                }
            }
        }
    }
}
