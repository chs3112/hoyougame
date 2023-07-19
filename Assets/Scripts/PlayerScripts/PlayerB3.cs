using UnityEngine;

public class PlayerB3 : PlayerMove_original
{
    int ismonsterjump;
    protected override void Awake()
    {
        base.Awake();
        ismonsterjump = 1;
    }

    protected override void OnAttack(Transform enemy, Collision2D collision)
    {
        rigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        if (ismonsterjump > 0)
        {
            popo((ismonsterjump) * 500);
        }
        ismonsterjump += 1;
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        if (ismujuck)
            enemyMove.OnDamaged(false);
        else
            enemyMove.OnDamaged(true);
    }
    
    protected override void Findground(){
        Vector3 vec = new Vector3(rigid.position.x - 0.28f, rigid.position.y - 0.55f, 0);
        Debug.DrawRay(vec, Vector3.right * 0.6f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitt = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Enemy"));
        if (rayHit || rayHitt)
        {
            anim.SetBool("isJumping", false);
            ismonsterjump = 1;
        }

    }

}
