using UnityEngine;

public class PlayerC6 : PlayerMove_original
{

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            anim.SetBool("isJumping", false);
        }

        base.OnCollisionEnter2D(collision);

    }





}
