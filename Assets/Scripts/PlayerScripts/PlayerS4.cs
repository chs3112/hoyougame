using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerS4 : PlayerMove_original
{

    Image Skillskill;
    Button Skill;
    float skillTime = 0;
    float skillcool;
    bool ismuuu;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        ismuuu = false;
        skillcool = 30;
        skillTime = 0;
        Skillskill.fillAmount = skillTime / skillcool;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        if (skillTime == 0){
            ismuuu = true;
            StartCoroutine(mucolor());
            StartCoroutine(mujuckheje(5));
            skillTime = skillcool;
        }
    }

    IEnumerator mucolor(){
        for(int i = 0; i < 20; i++){
            if (i % 2 == 0){
                spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
            }
            else{
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
            yield return new WaitForSeconds(0.2f);
        }
        for(int i = 0; i < 10; i++){
            if (i % 2 == 0){
                spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
            }
            else{
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
            yield return new WaitForSeconds(0.1f);

        }
        ismuuu = false;
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

    public override void OnDamaged()
    {
        if (!ismuuu){
            base.OnDamaged();
        }
    }

    void Askillup()
    {

    }



}
