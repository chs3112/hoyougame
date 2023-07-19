using UnityEngine;
using UnityEngine.UI;

public class PlayerS3 : PlayerMove_original
{
    int jump;
    Text jumpcount;
    int jumpmon;

    protected override void Awake()
    {
        base.Awake();
        jump = 1;
        jumpcount = GameObject.Find("UI").transform.GetChild(5).GetComponent<Text>();
    }

    protected override void Start()
    {
        base.Start();
        
        jumpcount.gameObject.SetActive(true);
        jump = 1;
        jumpcount.text = "Jump:" + jump.ToString();
    }

    protected override void Jump()
    {
        if(jump > 0){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            jump -= 1;
            popo(400 * jumpmon);
            jumpmon += 1;
            jumpcount.text = "Jump:" + jump.ToString();
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
            jump += 1;
            jumpmon = 0;
            jumpcount.text = "Jump:" + jump.ToString();
        }
    }
}
