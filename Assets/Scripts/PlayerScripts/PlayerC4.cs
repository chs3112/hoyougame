using UnityEngine;

public class PlayerC4 : PlayerMove_original
{

    float colorTime;

    protected override void Start()
    {
        base.Start();
        popo(5000);
        colorTime = 0;
    }

    protected override void Update()
    {
        base.Update();
        colorTime -= 1 * Time.deltaTime;
        if (colorTime < 0)
        {
            colorTime = 0.02f;
            spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
    }
    




}
