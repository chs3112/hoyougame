using UnityEngine;
using UnityEngine.UI;

public class PlayerX6 : PlayerMove_original
{

    Image Skillskill;
    Button Skill;
    float skillTime = 0;
    float skillcool;
    public GameObject box;
    

    protected override void Awake()
    {
        base.Awake();
        Skill = GameObject.Find("JoJack").transform.GetChild(2).GetComponent<Button>();
        Skillskill = GameObject.Find("JoJack").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        skillcool = 10;
        skillTime = 0;
        Skillskill.fillAmount = skillTime / skillcool;
        Skill.gameObject.SetActive(true);
    }
    
    protected override void Askill()
    {
        if (skillTime == 0)
        {
            skillTime = skillcool;
            GameObject bo1 = Instantiate(box, new Vector2(transform.position.x, transform.position.y + 4), Quaternion.identity);
            GameObject bo2 = Instantiate(box, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            bo1.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * derect, 100));
            bo2.GetComponent<Rigidbody2D>().AddForce(new Vector2(300 * derect, 100));
            Destroy(bo1, 3f);
            Destroy(bo2, 3f);
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
