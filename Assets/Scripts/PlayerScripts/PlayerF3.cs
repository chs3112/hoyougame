using UnityEngine;

public class PlayerF3 : PlayerMove_original
{

    protected override void Start()
    {
        base.Start();
        gm.originTime *= 1.5f;
        Time.timeScale = gm.originTime;
    }


}
