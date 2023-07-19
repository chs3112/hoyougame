using UnityEngine;

public class PlayerB8 : PlayerMove_original
{

    protected override void Awake()
    {
        base.Awake();
        maxSpeed = 1000000;
        originSpeed = maxSpeed;
    }

    protected override void Movement()
    {
        if (isRightDown)
        {
            rigid.AddForce(Vector2.right * 50 * derect, ForceMode2D.Force);
        }
        if (isLeftDown)
        {
            rigid.AddForce(Vector2.left * 50 * derect, ForceMode2D.Force);
        }
    }
}
