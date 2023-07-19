using UnityEngine;
using UnityEngine.UI;

public class PlayerX5 : PlayerMove_original
{
    Image Nenene;
    int nene;
    protected override void Start()
    {
        base.Start();
        nnne.SetActive(true);
        Nenene = GameObject.Find("Nec").GetComponent<Image>();
        Nenene.fillAmount = nene / 3;
    }

    protected override void OnAttack(Transform enemy, Collision2D collision)
    {
        base.OnAttack(enemy, collision);
        nene += 1;
        Nenene.GetComponent<Image>().fillAmount = nene / 3f;
        if (nene == 3)
        {
            gm.health = 2;
            Nenene.GetComponent<Image>().fillAmount = 1f;

        }
    }

    public override void OnDamaged()
    {
        nene = 0;
        Nenene.GetComponent<Image>().fillAmount = nene / 3f;
        popo(5000);
        base.OnDamaged();
    }
}
