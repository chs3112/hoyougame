using UnityEngine;

public class PlayerF2 : PlayerMove_original
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Jumjum()
    {
        gm.score = Mathf.CeilToInt(gm.score * 0.33f);

        base.Jumjum();
    }

}
