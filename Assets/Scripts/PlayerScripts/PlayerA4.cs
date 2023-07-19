using UnityEngine;
using UnityEngine.UI;

public class PlayerA4 : PlayerMove_original
{
    Button Skill;
    
    Image Skillskill;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        Skillskill.fillAmount = 0;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        if (maxSpeed == 4.5f)
        {
            maxSpeed = 12;
            originSpeed = 12;
        }
    }

    void Askillup()
    {
        if (maxSpeed == 12)
        {
            originSpeed = 4.5f;
            maxSpeed = 4.5f;
        }
    }

    protected override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Askill();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Askillup();
        }
    }



}
