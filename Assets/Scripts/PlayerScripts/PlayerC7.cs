using UnityEngine;

public class PlayerC7 : PlayerMove_original
{
    public PhysicsMaterial2D migg;

    protected override void Start()
    {
        base.Start();
        rigid.sharedMaterial = migg;
    }


}
