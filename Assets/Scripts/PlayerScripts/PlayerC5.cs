using UnityEngine;

public class PlayerC5 : PlayerMove_original
{
    protected override void Jump()
    {
        if (isswing)
        {
            joint.connectedBody = null;
            joint.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Invoke("sww", 0.2f);
        }
        if (!anim.GetBool("isJumping"))
        {
            popo(150);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }


}
