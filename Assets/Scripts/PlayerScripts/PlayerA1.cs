using UnityEngine;

public class PlayerA1: PlayerMove_original
{

    protected override void Awake()
    {
        base.Awake();
        ismujuck = true;
    }
    protected override void EncounterEnemy(Collision2D collision)
    {
        base.OnAttack(collision.transform, collision);
        popo(700);
    }


}
