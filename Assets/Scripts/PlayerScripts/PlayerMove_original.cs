using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerMove_original: MonoBehaviour
{
    protected bool isabled;
    protected GameManager gm;
    protected float maxSpeed;
    protected float jumpPower;
    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRenderer;
    protected Animator anim;
    CapsuleCollider2D capsulecollider;
    protected bool isRightDown;
    protected bool isLeftDown;
    private Text point;
    float minispeed = 0.5f;
    int hihi;
    protected int derect;
    protected bool isswing;
    protected FixedJoint2D joint;
    protected GameObject black;
    bool blac;
    protected int health;
    protected float originSpeed;
    protected bool ismujuck;
    public GameObject nnne;
    bool brak;


    protected virtual void Awake()
    {
        IsEnable();
        realMove.Aright = Right;
        realMove.Aright = RightUp;
        realMove.Aleft = Left;
        realMove.Aleftup = LeftUp;
        realMove.Ajump = Jump;
        realMove.Ajumpup = JumpUp;
        realMove.Askill = Askill;
        realMove.Askillup = AskillUp;
        blac = false;
        brak = false;
        isswing = false;
        derect = 1;
        minispeed = 0.5f;
        gameObject.layer = 10;
        nnne = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        point = GameObject.Find("UI").transform.GetChild(2).GetComponent<Text>();
        black = GameObject.Find("Black");
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        nnne.SetActive(false);
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        maxSpeed = 4.5f;
        originSpeed = 4.5f;
        if (HHHhh.hh.stage == 29)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);//투명화
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
        gm.health = 1;

    }

    protected virtual void IsEnable(){
        if(HHHhh.hh.infinite > 100){
            this.enabled = true;
            isabled = true;
        }
        else{
            this.enabled = false;
            isabled = false;
        }
    }

    protected virtual void Start()
    {
        black.SetActive(false);
        transform.position = new Vector2(0, 0);
        VelocityZero();

    }


    protected virtual void Right()
    {
        isRightDown = true;

    }

    protected virtual void RightUp()
    {
        isRightDown = false;
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);

    }

    protected virtual void Left()
    {
        isLeftDown = true;
    }

    protected virtual void LeftUp()
    {
        isLeftDown = false;
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);
    }



    protected virtual void Jump()
    {
        if (isswing)
        {
            joint.connectedBody = null;
            joint.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            StartCoroutine(sww());
        }
        if (!anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }

    
    protected IEnumerator sww(){
        yield return new WaitForSeconds(0.2f);
        isswing = false;
    }

    public void popo(int i)
    {
        hihi += i;
        if (i > 0)
            PointUp("+" + i.ToString());
        else
            PointUp(i.ToString());
        gm.score += i;
    }

    protected virtual void JumpUp()
    {
        
    }
    protected virtual void Askill()
    {
        
    }
    protected virtual void AskillUp()
    {
        
    }


    protected virtual void Update()
    {

        if (Input.GetButtonDown("Jump")) 
        {
            Jump();
        }
        if (Input.GetButtonUp("Jump"))
        {
            JumpUp();
        }
        if(gm.score < (int)(this.gameObject.transform.position.x * 100) + hihi)
        {
            gm.score = (int)(this.gameObject.transform.position.x * 100) + hihi;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRightDown = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRightDown = false;
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLeftDown = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isLeftDown = false;
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);
        }
        if (rigid.velocity.x * derect > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (rigid.velocity.x * derect < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Mathf.Abs(rigid.velocity.x) < minispeed)
        {
            anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", true);
    }

    protected virtual void Movement(){
        if (isRightDown)
        {
            rigid.AddForce(Vector2.right * 10 *derect, ForceMode2D.Impulse);
        }

        if (isLeftDown)
        {
            rigid.AddForce(Vector2.left * 10 * derect, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Movement();
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1))
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);



        if (rigid.velocity.y < 0)
        {
            Findground();
        }
        
    }

    protected virtual void Findground(){
        Vector3 vec = new Vector3(rigid.position.x - 0.28f, rigid.position.y - 0.55f, 0);
        Debug.DrawRay(vec, Vector3.right * 0.6f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitt = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Enemy"));
        if (rayHit || rayHitt)
        {
            anim.SetBool("isJumping", false);
        }

    }

    protected virtual void EncounterEnemy(Collision2D collision)
    {
        if(ismujuck){
            OnAttack(collision.transform, collision);
        }
        else if (transform.position.y - 0.48f > collision.transform.position.y)
        {
            OnAttack(collision.transform, collision);
        }
        else{
            OnDamaged();
        }
    }

    protected virtual void EncounterSpike(){
        OnDamaged();
    }

    protected virtual void BuffFloor(Collision2D collision){

        if(collision.gameObject.tag == "Jump")
        {
            jumpPower = 35;
        }
        else
        {
            jumpPower = 17;
        }
        if (collision.gameObject.tag == "Ice")
        {
            minispeed = 100;
            rigid.drag = 0;
        }
        else
        {
            minispeed = 0.5f;
            rigid.drag = 2;
        }
        if (collision.gameObject.tag == "Return")
        {
            derect = -1;
        }
        else
        {
            derect = 1;
        }
        if (collision.gameObject.tag == "Black")
        {
            black.SetActive(true);
            brak = true;
        }
        else if(!blac && brak)
        {
            brak = false;
            black.SetActive(false);
        }
        if (collision.gameObject.tag == "Invisible")
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);
        }
        else if(spriteRenderer.color[3] == 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
        if (collision.gameObject.tag == "Speed")
        {
            maxSpeed = 9;
        }
        else if (collision.gameObject.tag == "Slow")
        {
            maxSpeed = 2;
        }
        else maxSpeed = originSpeed;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isabled){
            return;
        }
        if (collision.gameObject.tag == "swing" && !isswing)
        {
            joint = collision.gameObject.GetComponent<FixedJoint2D>();
            joint.enabled = true;
            gameObject.transform.position = collision.gameObject.transform.position;
            joint.connectedBody = rigid;
            isswing = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            EncounterEnemy(collision);
        }
        if (collision.gameObject.tag == "Spike")
        {
            EncounterSpike();
        }
        BuffFloor(collision);

    }

    protected virtual void EncounterCliff(){
        OnDamaged();
    }

    protected virtual void CollcetCoin(Collider2D collision){
        bool isBronze = collision.name.Contains("Bronze");
        bool isSilver = collision.name.Contains("Silver");
        bool isGold = collision.name.Contains("Gold");

        if (isBronze)
        {
            gm.money += 5;
        }
        else if (isSilver)
        {
            gm.money += 10;
        }
        else if (isGold)
        {
            gm.money += 20;
        }

        collision.gameObject.SetActive(false);

    }


    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        
        if(!isabled){
            return;
        }
        if (collision.gameObject.tag == "Cliff") EncounterCliff();
        if (collision.gameObject.tag == "Enemyy") OnDamaged();
        if (collision.gameObject.tag == "Fire") OnDamaged();

        if (collision.gameObject.tag == "Item")
        {
            CollcetCoin(collision);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            gameObject.layer = 11;
            if (HHHhh.hh.stage == HHHhh.hh.clear)
            {
                HHHhh.hh.clear += 1;
                HHHhh.hh.monney += 500;
            }
            HHHhh.hh.Save();
            gm.victory();
            Timee();
        }
    }
    protected virtual void Timee()
    {
        Time.timeScale = 0;
    }


    public virtual void OnDamaged()
    {
        HealthDown();
    }

    protected virtual void OnAttack(Transform enemy, Collision2D collision)
    {
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        if (ismujuck)
            enemyMove.OnDamaged(false);
        else
            enemyMove.OnDamaged(true);
    }

    public void bla()
    {
        blac = true;
        black.SetActive(true);
        StartCoroutine(blbl());
    }

    protected virtual IEnumerator blbl()
    {
        yield return new WaitForSeconds(1.5f);
        blac = false;
        black.SetActive(false);
    }


    protected virtual void OnDie()
    {
        capsulecollider.enabled = false;
        HHHhh.hh.Save();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    protected virtual void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }


    protected virtual void PointUp(string pointt)
    {
        CancelInvoke("PointDown");
        point.gameObject.SetActive(true);
        point.text = pointt;
        point.color = new Color(1, 1, 1, 1);
        Invoke("PointDown", 3);
    }

    protected virtual void PointDown()
    {
        point.gameObject.SetActive(false);
    }


    protected void HealthDown()
    {
        if (health > 1)
        {
            health--;
            PlayerReposition(true);

        }
        else
        {
            bool rego = true;
            HHHhh.hh.death += 1;
            if (HHHhh.hh.death >= 1000 && HHHhh.hh.py_Data["X4"].inven == 0)
            {
                rego = false;
                collectPlayer("X4");
            }
            if (HHHhh.hh.infinite < 10)
            {
                OnDie();
                HHHhh.hh.att += 1;
                Timee();
                HHHhh.hh.Save();
                if (rego)
                {
                    gm.Restart();
                }
            }
            else
            {
                OnDie();
                Time.timeScale = 0;
                Jumjum();
                gm.Try.text = gm.score.ToString();
                if (gm.score >= 20000 && HHHhh.hh.py_Data["X0"].inven == 0)
                {
                    collectPlayer("X0");
                }
                if (gm.score >= 35000 && HHHhh.hh.py_Data["X2"].inven == 0)
                {
                    collectPlayer("X2");
                }
                if (gm.score >= 50000 && HHHhh.hh.py_Data["X5"].inven == 0)
                {
                    collectPlayer("X5");
                }
                gm.Victory.SetActive(true);
                gm.UIRestartBtn2.SetActive(false);
                HHHhh.hh.Save();
                Timee();
            }
        }
    }

    void collectPlayer(string id){

        gm.namee.text = HHHhh.hh.py_Data[id].player_name;
        gm.getimg.sprite = HHHhh.hh.py_Data[id].img;
        HHHhh.hh.py_Data[id].inven = 1;
        HHHhh.hh.liRandom.Add(id);
        gm.newplayer.SetActive(true);
    }

    protected virtual void Jumjum(){
        HHHhh.hh.monney += gm.money;
        gm.UIPoint.text = "Monney" + (gm.money).ToString();
        gm.Try.text = gm.score.ToString();

    }

    protected void PlayerReposition(bool go)
    {
        int o = 0;
        if (go)
        {
            o = 19;
        }
        float i = transform.position.x - (transform.position.x % 20) + o;
        transform.position = new Vector3(i, 0, 0);
        VelocityZero();
    }

    protected IEnumerator mujuckheje(float i)
    {
        ismujuck = true;
        yield return new WaitForSeconds(i);
        ismujuck = false;
    }

}
