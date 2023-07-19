using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerA5 : PlayerMove_original
{
    int life = 3;
    Text shielcount;

    protected override void Awake()
    {
        base.Awake();
        shielcount = GameObject.Find("UI").transform.GetChild(5).GetComponent<Text>();
        shielcount.gameObject.SetActive(true);
        shielcount.text = "shield:" + life.ToString();
    }

    IEnumerator heje(){
        yield return new WaitForSeconds(1);
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1f, 1f);
    }

    public override void OnDamaged()
    {
        if (life > 0)
        {
            gameObject.layer = 11;
            gm.money += 200;
            spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
            life -= 1;
            shielcount.text = "shield:" + life.ToString();
            StartCoroutine(heje());
        }
        else
            base.HealthDown();
    }

}
