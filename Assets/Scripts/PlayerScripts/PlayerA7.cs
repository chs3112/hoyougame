using UnityEngine;
using UnityEngine.UI;

public class PlayerA7 : PlayerMove_original
{
    
    Image Skillskill;
    Button Skill;
    float skillTime = 0;
    float skillcool;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        skillcool = 1;
        skillTime = 0;
        Skillskill.fillAmount = 0;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        bool useskill = false;
        if(skillTime == 0){
            StartCoroutine(mujuckheje(0.1f));
            this.transform.position = new Vector3(transform.position.x, 0, this.transform.position.z);
            skillTime = skillcool;
            useskill = true;
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

    
    protected override void EncounterEnemy(Collision2D collision)
    {
        if(ismujuck){
            popo(700);
            OnAttack(collision.transform, collision);
        }
        if (transform.position.y - 0.48f > collision.transform.position.y)
        {
            OnAttack(collision.transform, collision);
        }
        else
            OnDamaged();
    }

    void Askillup()
    {

    }
}
