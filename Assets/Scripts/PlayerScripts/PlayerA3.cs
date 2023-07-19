using UnityEngine;
using UnityEngine.UI;

public class PlayerA3 : PlayerMove_original
{
    bool firstjump;
    bool isJumpDown;
    bool revolve;
    float jetgo;
    Image Jet;

    protected override void Awake()
    {
        base.Awake();
        firstjump = false;
        isJumpDown = false;
        revolve = true;
        jetgo = 10;
        Jet = GameObject.Find("Canvas").transform.GetChild(7).GetChild(0).GetChild(0).GetComponent<Image>();
        GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(true);
    }

    protected override void Jump()
    {
        if (!anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            firstjump = true;
        }
        else
        {
            isJumpDown = true;
            revolve = false;
            if (jetgo > 0)
            {
                rigid.velocity = Vector2.zero;
            }
        }
        anim.SetBool("isJumping", true);
    }

    
    protected override void JumpUp()
    {
        isJumpDown = false;
        if (firstjump) firstjump = false;
    }

    protected override void Update()
    {
        base.Update();
        
        if (isJumpDown && jetgo > 0 && !firstjump)
        {
            rigid.AddForce(Vector2.up * 2500 *Time.deltaTime, ForceMode2D.Force);
            jetgo -= 10 * Time.deltaTime;

            Jet.GetComponent<Image>().fillAmount = jetgo/10;
        }
        else if (jetgo < 10 && revolve)
        {
            jetgo += 1 * Time.deltaTime;
            Jet.GetComponent<Image>().fillAmount = jetgo/10;
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
            revolve = true;
            anim.SetBool("isJumping", false);
        }

    }
}
