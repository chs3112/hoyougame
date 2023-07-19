using System.Collections;
using UnityEngine;

public class PlayerX4 : PlayerMove_original
{

    int location;
    int spsp;

    protected override void Awake()
    {
        base.Awake();
        location = 1;
        spsp = 1;
    }

    protected override void EncounterSpike()
    {
        popo(-1000);
        spsp = 1;
        StartCoroutine(hurt());
    }
    
    IEnumerator hurt()
    {
        for(int i = 0; i < 10; i++){
            if(i % 2 == 0) spriteRenderer.color = new Color(1, 0, 0, 0.6f);
            else spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    protected override void Update()
    {
        base.Update();
        if (transform.position.x >= location * 20)
        {
            if (spsp * 300 > 1500) popo(1500);
            else popo(spsp * 300);
            spsp += 1;
            location += 1;
        }
    }

}
