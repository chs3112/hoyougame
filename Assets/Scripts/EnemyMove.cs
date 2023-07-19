using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator ainm;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;
    GameManager gm;
    HHHhh hhh;
    PlayerMove_original py;
    public int nextMove;
    public int speed;
    public bool red;
    public GameObject exp;
    public bool green;
    int hihih;
    bool huah;
    int stop;
    int stopp;
    public Action explain;

    void Awake()
    {
        py = FindObjectOfType<PlayerMove_original>().GetComponent<PlayerMove_original>();
        rigid = GetComponent<Rigidbody2D>();
        ainm = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        hhh = GameObject.Find("Num").GetComponent<HHHhh>();
        Think();


    }

    private void Start()
    {
        if (red)
        {
            exp.SetActive(false);
        }
        huah = true;
        stop = 1;
        stopp = 1;
        if(py.GetType() == typeof(PlayerB7) && hhh.infinite > 100)
        {
            gameObject.name = "Enemy";
            speed = 1;
            red = false;
        }
        if(py.GetType() == typeof(PlayerB4) && hhh.infinite > 100)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove*speed*stop*stopp, rigid.velocity.y);
        if (py.GetType() == typeof(PlayerX7))
        {
            PlayerX7 playX7 = (PlayerX7)py;
            float diss = Vector2.Distance(transform.position, py.transform.position);
            if (diss < 3)
            {
                playX7.exxpl();
            }
        }

        if (red)
        {
            float dis = Vector2.Distance(transform.position, py.transform.position);
            if(dis < 2 && huah && capsulecollider.enabled)
            {
                CancelInvoke();
                nextMove = 0;
                huah = false;
                exp.SetActive(true);
                exp.transform.localScale = new Vector3(1, 1, 1);
                hihih = 1;
                Invoke("ess", 0.02f);
            }
            else if(dis > 10)
            {
                stopp = 0;
            }
            else
            {
                stopp = 1;
            }
        }
        else if (green)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 1.2f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down*3, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 3, LayerMask.GetMask("Platform"));
            if (rayHit.collider == null)
                Turn();
        }
        else
        {
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.4f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider == null)
                Turn();
        }
    }
    public void ess()
    {
        hihih += 1;
        exp.transform.localScale = new Vector3(hihih, hihih, 1);
        if(hihih < 25)
        {
            Invoke("ess", 0.02f);
        }
        else
        {
            DeActive();
        }
    }

    void Think()
    {
        if (red)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.4f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider == null)
            {
                stop = 0;
                ainm.SetInteger("walkSpeed", nextMove);
                Invoke("Think", 0.1f);
            }
            else
            {
                stop = 1;
                if (gm.player.transform.position.x - transform.position.x > 0)
                {
                    nextMove = 1;
                    spriteRenderer.flipX = true;
                }
                else
                {
                    nextMove = -1;
                    spriteRenderer.flipX = false;
                }
                ainm.SetInteger("walkSpeed", nextMove);
                Invoke("Think", 0.1f);
            }
            
        }
        else
        {
            nextMove = UnityEngine.Random.Range(-1, 2);
            float nextThinkTime = UnityEngine.Random.Range(2f, 5f);
            ainm.SetInteger("walkSpeed", nextMove);
            if (nextMove != 0)
                spriteRenderer.flipX = nextMove == 1;
            Invoke("Think", nextThinkTime / speed);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            Damm(2000);
        }
        if(collision.gameObject.tag == "buu")
        {
            Damm(1000);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "expp")
        {
            Damm(1000);
        }
    }

    void Damm(int i)
    {
        py.popo(i);
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        capsulecollider.enabled = false;
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        CancelInvoke();
        nextMove = 0;
        ainm.SetInteger("walkSpeed", nextMove);
        Invoke("DeActive", 5f);
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke();
        float nextThinkTime = UnityEngine.Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    public void OnDamaged(bool namal)
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        capsulecollider.enabled = false;
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        CancelInvoke();
        nextMove = 0;
        ainm.SetInteger("walkSpeed", nextMove);
        Invoke("DeActive", 3f);
        if (namal)
        {
            if (name.Substring(0, 2) == "BB")
            {
                py.bla();
            }
            else if (name.Substring(0, 2) == "GG" && !(py.GetType() == typeof(PlayerA1) && hhh.infinite > 100))
                py.OnDamaged();
        }
    }



    public void DeActive()
    {
        gameObject.SetActive(false);
    }
}
