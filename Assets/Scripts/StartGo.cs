using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGo : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    CapsuleCollider2D capsulecollider;
    public float maxSpeed;
    public float jumpPower;

    void Start()
    {
        Time.timeScale = 1;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        transform.position = new Vector2(-10, -3.5f);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!anim.GetBool("isJumping"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);

            }
        }

    }

    void FixedUpdate()
    {
        rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        if (transform.position.x >= 13)
        {
            transform.position = new Vector2(-13, -3.5f);
        }
        if (rigid.velocity.y < 0)
        {
            Vector3 vec = new Vector3(rigid.position.x - 0.28f, rigid.position.y - 0.55f, 0);
            Debug.DrawRay(vec, Vector3.right * 0.6f, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit)
                {
                    anim.SetBool("isJumping", false);
                }
            }

        }

    }
}
