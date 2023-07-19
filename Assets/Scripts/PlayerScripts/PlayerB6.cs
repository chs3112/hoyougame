using UnityEngine;

public class PlayerB6 : PlayerMove_original
{
    protected override void CollcetCoin(Collider2D collision)
    {
        base.CollcetCoin(collision);
        gm.fire.transform.position = new Vector2(gm.fire.transform.position.x - 5, gm.fire.transform.position.y);
    }


}
