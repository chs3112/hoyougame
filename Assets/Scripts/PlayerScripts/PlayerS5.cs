using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerS5 : PlayerMove_original
{

    Image Skillskill;
    Button Skill;
    float skillTime = 0;
    float skillcool;
    public GameObject bunsin;
    

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
            for (int i = 0; i < 35; i++)
            {
                GameObject bo1 = Instantiate(bunsin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                bo1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(400f, 700f)));
                Destroy(bo1, 2.5f);
            }
            skillTime = skillcool;
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
