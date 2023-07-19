using UnityEngine;

public class PlayerA6 : PlayerMove_original
{
    protected override void Awake()
    {
        base.Awake();
        popo(HHHhh.hh.jeonpan);
    }
    
    protected override void Jumjum()
    {
        HHHhh.hh.jeonpan = Mathf.RoundToInt(gm.score/2f);
        base.Jumjum();
    }
}
