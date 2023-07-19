using UnityEngine;

public class PlayerC2 : PlayerMove_original
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Jumjum()
    {
        gm.score = Mathf.CeilToInt(gm.score * 1.5f);
        base.Jumjum();
    }
}
