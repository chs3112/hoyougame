using System.Collections;
using UnityEngine;

public class PlayerB2 : PlayerMove_original
{

    protected override void EncounterSpike()
    {
        popo(-100);
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

}
