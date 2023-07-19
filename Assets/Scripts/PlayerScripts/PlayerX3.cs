using UnityEngine;
using UnityEngine.UI;

public class PlayerX3 : PlayerMove_original
{

    Button Skill;
    Image Skillskill;
    bool isgong;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        Skillskill.fillAmount = 0;
        Skill.gameObject.SetActive(true);
        isgong = false;
    }
    
    protected override void Askill()
    {
        if(isgong){
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            isgong = false;
        }
        else{
            transform.localScale = new Vector3(1, 1, 1);
            isgong = true;
        }
    }

    void Askillup()
    {
        
    }

    protected override void Findground()
    {
        if (isgong){
            Vector3 vec1 = new Vector3(rigid.position.x - 0.14f, rigid.position.y - 0.275f, 0);
            Debug.DrawRay(vec1, Vector3.right * 0.3f, new Color(0, 1, 0));
            RaycastHit2D rayHit1 = Physics2D.Raycast(vec1, Vector3.right, 0.3f, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitt1 = Physics2D.Raycast(vec1, Vector3.right, 0.3f, LayerMask.GetMask("Enemy"));
            if (rayHit1 || rayHitt1)
            {
                anim.SetBool("isJumping", false);
            }
        }
        else{
            base.Findground();
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
