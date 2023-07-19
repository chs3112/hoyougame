using UnityEngine;
using UnityEngine.UI;

public class PlayerA8 : PlayerMove_original
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
        skillcool = 0.1f;
        skillTime = 0;
        Skillskill.fillAmount = skillTime / skillcool;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        rigid.velocity = Vector2.zero;
        skillTime = skillcool;
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
