using UnityEngine;

public class PlayerB7 : PlayerMove_original
{
    protected override void BuffFloor(Collision2D collision)
    {
        if(collision.gameObject.tag == "Jump")
        {
            jumpPower = 35;
        }
        else
        {
            jumpPower = 17;
        }
        if (collision.gameObject.tag == "Speed")
        {
            maxSpeed = 9;
        }
        else maxSpeed = 4.5f;
    }

}
