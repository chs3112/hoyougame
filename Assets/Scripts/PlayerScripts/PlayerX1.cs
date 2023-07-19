using UnityEngine;

public class PlayerX1 : PlayerMove_original
{
    int jump;

    protected override void Jump()
    {
        if (jump == 2)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            jump -= 1;
            jumpPower = 11;
        }
        else if (jump == 1)
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            jump -= 1;
            jumpPower = 17;
        }
    }

    protected override void Findground()
    {
        Vector3 vec = new Vector3(rigid.position.x - 0.28f, rigid.position.y - 0.55f, 0);
        Debug.DrawRay(vec, Vector3.right * 0.6f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitt = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Enemy"));
        if (rayHit || rayHitt)
        {
            anim.SetBool("isJumping", false);
            jump = 2;
        }
    }
}
