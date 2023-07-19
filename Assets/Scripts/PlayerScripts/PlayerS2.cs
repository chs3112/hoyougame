using UnityEngine;
using UnityEngine.UI;

public class PlayerS2 : PlayerMove_original
{

    Image Skillskill;
    Button Skill;
    float skillTime = 0;
    float skillcool;
    GameObject[] enemys;
    float shortDis;
    GameObject pyojeok;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        skillcool = 1;
        skillTime = 0;
        Skillskill.fillAmount = skillTime / skillcool;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        bool useskill = false;
        if (skillTime == 0)
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            shortDis = Vector2.Distance(gameObject.transform.position, enemys[0].transform.position);

            pyojeok = enemys[0];

            foreach (GameObject find in enemys)
            {
                float dis = Vector2.Distance(gameObject.transform.position, find.transform.position);
                if (dis < shortDis)
                {
                    pyojeok = find;
                    shortDis = dis;
                }
            }
            if (shortDis < 10)
            {
                Vector3 here = pyojeok.transform.position;
                EnemyMove enemyMove = pyojeok.transform.GetComponent<EnemyMove>();
                enemyMove.OnDamaged(false);
                gameObject.layer = 11;
                Invoke("heje", 1);
                StartCoroutine(mujuckheje(1));
                popo(1000);
                spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
                this.transform.position = here;
                skillTime = skillcool;
                useskill = true;
            }
        }
        if (useskill && isswing)
        {
            joint.connectedBody = null;
            joint.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            StartCoroutine(sww());
        }
    }


    protected override void Update()
    {
        if (skillTime > 0)
        {
            skillTime -= 1 * Time.deltaTime;
            if (skillTime < 0)
            {
                skillTime = 0;
            }
            Skillskill.fillAmount = skillTime / skillcool;
        }
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Askill();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Askillup();
        }
        base.Update();
    }

    void Askillup()
    {

    }


}
