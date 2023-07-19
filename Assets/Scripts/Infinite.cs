using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Infinite : MonoBehaviour
{
    HHHhh hhh;
    public float speed = 0.6f;
    public float jengga = 0.03f;
    public float maxspeed = 9f;
    Rigidbody2D rigid;
    public GameManager gm;
    public TMP_Text metor;
    public GameObject imim;


    void Awake()
    {
        speed = 0.6f;
        jengga = 0.03f;
        maxspeed = 9f;

        rigid = GetComponent<Rigidbody2D>();
        hhh = GameObject.Find("Num").GetComponent<HHHhh>();
    }

    private void Start()
    {
        if (hhh.infinite < 10)
            imim.SetActive(false);
        else imim.SetActive(false);

    }

    void Update()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        speed += Time.deltaTime * jengga;
        if (speed >= 9)
            speed = maxspeed;
        if (hhh.infinite > 100)
        {
            float geori = gm.player.transform.position.x - 15.49f - transform.position.x;
            if (geori < 0)
            {
                imim.SetActive(false);
            }
            else
            {
                imim.SetActive(true);
                metor.text = "<-" + geori.ToString("F");
            }
        }
        

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.transform.parent.gameObject)
        {
            GameObject parentt = collision.transform.parent.gameObject;
            Debug.Log(parentt);
            if (parentt.transform.parent.gameObject)
            {
                GameObject parenttt = parentt.transform.parent.gameObject;
                if (collision.tag == "Platform")
                {
                    Destroy(parenttt);
                    hhh.tyty -= 1;
                }
            }
        }*/
        if (collision.tag == "Platform")
        {
            Destroy(collision.transform.parent.parent.gameObject);
            hhh.tyty -= 1;
        }
    }



}
