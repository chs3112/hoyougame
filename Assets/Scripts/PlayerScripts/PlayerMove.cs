using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    /*
    public GameManager gameManager;
    public GameObject costum;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsulecollider;
    protected HHHhh hhh;
    private bool isRightDown;
    private bool isLeftDown;
    private bool isJumpDown;
    public Text ttt;
    public Text point;
    public int jump = 2;
    public Image Jet;
    public Image Skillskill;
    public GameObject Jetbar;
    public Button Skill;
    public float skillTime = 0;
    public float skillcool;
    int spsp = 1;
    public float minispeed = 0.5f;
    int hihi;
    int i = 1;
    public float jetgo = 1;
    public GameObject nenenene;
    int derect;
    int skilderect;
    int nene;
    bool firstjump;
    GameObject[] enemys;
    float shortDis;
    GameObject pyojeok;
    public bool isswing;
    FixedJoint2D joint;
    public Infinite infi;
    public GameObject black;
    public PhysicsMaterial2D migg;
    int life;
    public Text jumpcount;
    bool blac;
    bool speedup;
    public GameObject box;
    public GameObject explode;
    public GameObject bunsin;
    bool isupping;
    bool ismuuu;
    int ismonsterjump;
    int jumpmon;
    bool isgogoin;
    bool ismujuck;
    bool ismoney;
    bool revolve;

    void Awake()
    {
        revolve = true;
        isgogoin = false;
        ismoney = true;
        ismonsterjump = 0;
        jumpmon = 0;
        isupping = false;
        ismuuu = false;
        blac = false;
        firstjump = false;
        isswing = false;
        nene = 0;
        skilderect = 1;
        derect = 1;
        minispeed = 0.5f;
        isJumpDown = false;
        Skillskill.GetComponent<Image>().fillAmount = 0;
        spsp = 1;
        gameObject.layer = 10;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        hhh = GameObject.Find("Num").GetComponent<HHHhh>();
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        speedup = false;
        if (hhh.stage == 29)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);//투명화
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }

        if (hhh.infinite)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
            if (hhh.jangchak.SequenceEqual(new int[] { 3, 5 }))
            {
                if (hhh.jeonpan != 0)
                    popo(hhh.jeonpan);
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 3, 0 }))
            {
                ismujuck = true;
            }
            else
            {
                ismujuck = false;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 1, 3 }))
            {
                Papa();
                popo(5000);
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 3, 2 }))
                Jetbar.SetActive(true);
            if (hhh.jangchak.SequenceEqual(new int[] { 2, 7 }))
            {
                maxSpeed = 1000000;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 4, 0 }) ||
                hhh.jangchak.SequenceEqual(new int[] { 4, 1 }) ||
                hhh.jangchak.SequenceEqual(new int[] { 3, 3 }) ||
                hhh.jangchak.SequenceEqual(new int[] { 3, 6 }) ||
                hhh.jangchak.SequenceEqual(new int[] { 5, 2 })) // 스킬사용
            {
                Skill.gameObject.SetActive(true);
                skillcool = 1;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 3, 7 }))
            {

                Skill.gameObject.SetActive(true);
                skillcool = 0.1f;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 5, 5 }) ||
                hhh.jangchak.SequenceEqual(new int[] { 4, 4 }))
            {
                Skill.gameObject.SetActive(true);
                skillcool = 10;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 4, 3 }))
            {
                Skill.gameObject.SetActive(true);
                skillcool = 30;
            }
        }

        nenenene.GetComponent<Image>().fillAmount = nene / 3;
    }

    public void Start()
    {
        RuntimeAnimatorController ani = Resources.Load<RuntimeAnimatorController>($"Hoyous/ho{hhh.jangchak[0]}/you{hhh.jangchak[1]}");
        anim.runtimeAnimatorController = ani;

        black.SetActive(false);
        if (hhh.infinite)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 1, 6 }))
                rigid.sharedMaterial = migg;
            else
                rigid.sharedMaterial = null;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 4, 2 }) && hhh.infinite)
        {
            jumpcount.gameObject.SetActive(true);
            jump = 1;
            jumpcount.text = "Jump:" + jump.ToString();
        }
        else if (hhh.jangchak.SequenceEqual(new int[] { 3, 4 }) && hhh.infinite)
        {
            life = 3;
            jumpcount.gameObject.SetActive(true);
            jumpcount.text = "shield:" + life.ToString();
        }
        else
            jumpcount.gameObject.SetActive(false);
        if (hhh.jangchak.SequenceEqual(new int[] { -1, 2 }) && hhh.infinite)
        {
            Time.timeScale = 1.5f;
        }



    }

    void Papa()
    {
        if (hhh.stage == 29)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);
        }
        else
        {
            spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            Invoke("Papa", 0.02f);
        }
    }

    public void Right()
    {
        isRightDown = true;

    }

    public void RightUp()
    {
        isRightDown = false;
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);

    }

    public void Left()
    {
        isLeftDown = true;
    }

    public void LeftUp()
    {
        isLeftDown = false;
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * minispeed * derect, rigid.velocity.y);
    }

    IEnumerator mujuckheje(float i)
    {
        ismujuck = true;
        yield return new WaitForSeconds(i);
        ismujuck = false;
    }

    public void Askill()
    {
        bool useskill = false;
        if (hhh.jangchak.SequenceEqual(new int[] { 3, 3 }) && maxSpeed == 4.5f)//가속
        {
            maxSpeed = 12;
            speedup = true;
            useskill = true;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 4, 0 }) && skillTime == 0)//순간이동
        {
            StartCoroutine(mujuckheje(0.1f));
            this.transform.position = new Vector3(transform.position.x + (2 * skilderect), this.transform.position.y, this.transform.position.z);
            skillTime = skillcool;
            useskill = true;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 4, 1 }) && skillTime == 0)//암살
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
        if (hhh.jangchak.SequenceEqual(new int[] { 5, 5 }) && skillTime == 0)//나무 던지기
        {
            skillTime = skillcool;
            GameObject bo1 = Instantiate(box, new Vector2(transform.position.x, transform.position.y + 4), Quaternion.identity);
            GameObject bo2 = Instantiate(box, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            bo1.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * skilderect, 100));
            bo2.GetComponent<Rigidbody2D>().AddForce(new Vector2(300 * skilderect, 100));
            Destroy(bo1, 3f);
            Destroy(bo2, 3f);

        }
        if (hhh.jangchak.SequenceEqual(new int[] { 4, 3 }) && skillTime == 0)//무적
        {
            ismuuu = true;
            spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
            Invoke("mumu", 1);
            StartCoroutine(mujuckheje(1));
            skillTime = skillcool;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 3, 6 }) && skillTime == 0)//밑으로 이동
        {
            this.transform.position = new Vector3(transform.position.x, 0, this.transform.position.z);
            skillTime = skillcool;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 3, 7 }) && skillTime == 0)//정지
        {
            rigid.velocity = Vector2.zero;
            skillTime = skillcool;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 5, 2 }) && skillTime == 0)//공주
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            isgogoin = true;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 4, 4 }) && skillTime == 0)//분신
        {
            for (int i = 0; i < 35; i++)
            {
                GameObject bo1 = Instantiate(bunsin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                bo1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(400f, 700f)));
                Destroy(bo1, 2.5f);
            }
            skillTime = skillcool;
        }
        if (useskill && isswing)
        {
            joint.connectedBody = null;
            joint.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Invoke("sww", 0.2f);
        }
    }

    void mumu()
    {
        ismuuu = false;
        spriteRenderer.color = new Color(1, 1, 1f, 1f);
    }

    void heje()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1f, 1f);
    }


    public void Askillup()
    {
        if (hhh.jangchak.SequenceEqual(new int[] { 3, 3 }) && maxSpeed == 12)
        {
            maxSpeed = 4.5f;
            speedup = false;
        }
        if (hhh.jangchak.SequenceEqual(new int[] { 5, 2 }) && isgogoin)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isgogoin = false;
        }
    }

    public void exxpl()
    {
        if (!isupping)
        {
            isupping = true;
            StartCoroutine(ess(Instantiate(explode, transform.position, Quaternion.identity)));
        }
    }

    IEnumerator ess(GameObject a)
    {
        for (int i = 0; i < 35; i++)
        {
            a.transform.localScale = new Vector3(a.transform.localScale.x + 1, a.transform.localScale.y + 1, 1);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(a);
        isupping = false;
    }

    public void Jump()
    {
        if (isswing)
        {
            joint.connectedBody = null;
            joint.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Invoke("sww", 0.2f);
        }
        if (hhh.infinite)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 5, 0 }))
            { //국왕
                if (jump == 2)
                {
                    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("isJumping", true);
                    jump -= 1;
                    jumpPower = 11;
                }
                else if (jump == 1)
                {
                    rigid.velocity = Vector2.zero;
                    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("isJumping", true);
                    jump -= 1;
                    jumpPower = 17;
                }
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 4, 2 }) && jump > 0) //왕자
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
                jump -= 1;
                popo(300 * jumpmon);
                jumpmon += 1;
                jumpcount.text = "Jump:" + jump.ToString();
            }
            else if (hhh.jangchak.SequenceEqual(new int[] { 3, 2 })) //비행
            {
                if (!anim.GetBool("isJumping"))
                {
                    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    firstjump = true;
                }
                else
                {
                    isJumpDown = true;
                    revolve = false;
                    if (jetgo > 0)
                    {
                        rigid.velocity = Vector2.zero;
                    }
                }
                anim.SetBool("isJumping", true);
            }
            else
            {
                if (!anim.GetBool("isJumping"))
                {
                    if (hhh.jangchak.SequenceEqual(new int[] { 1, 4 }))//점핑 점프시 추가 점수
                    {
                        popo(150);
                    }
                    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("isJumping", true);
                }
            }
        }
        else
        {
            if (!anim.GetBool("isJumping"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
            }
        }
    }

    public void popo(int i)
    {
        hihi += i;
        if (i > 0)
            PointUp("+" + i.ToString());
        else
            PointUp(i.ToString());
        gameManager.jumsu += i;
    }

    public void JumpUp()
    {
        isJumpDown = false;
        if (firstjump) firstjump = false;
    }


    public void Update()
    {

        if (skillTime > 0)
        {
            skillTime -= 1 * Time.deltaTime;
            if (skillTime < 0)
            {
                skillTime = 0;
            }
            Skillskill.GetComponent<Image>().fillAmount = skillTime / skillcool;
        }
        if (Input.GetKeyDown("x") && hhh.infinite)
        {
            Askill();
        }
        if (Input.GetKeyUp("x") && hhh.infinite)
        {
            Askillup();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonUp("Jump"))
        {
            JumpUp();
        }
        if (gameManager.jumsu < (int)(this.gameObject.transform.position.x * 100) + hihi)
        {
            gameManager.jumsu = (int)(this.gameObject.transform.position.x * 100) + hihi;
        }

        if (gameManager.jumsu >= 10000 && ismoney)
        {
            ismoney = false;
            if (hhh.jangchak.SequenceEqual(new int[] { 1, 0 }))
            {
                gameManager.stagePoint += 1000;
            }
            else if (hhh.jangchak.SequenceEqual(new int[] { 5, 1 }))
            {
                gameManager.stagePoint += 2000;
            }
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



        if (hhh.infinite && hhh.jangchak.SequenceEqual(new int[] { 5, 3 })) //칠흑의 강아지
        {
            if (transform.position.x >= i * 20)
            {
                if (spsp * 300 > 1000) popo(1000);
                else popo(spsp * 300);
                spsp += 1;
                i += 1;
            }
        }



        if (rigid.velocity.x * derect > 0)
        {
            spriteRenderer.flipX = false;
            skilderect = 1;
        }
        if (rigid.velocity.x * derect < 0)
        {
            spriteRenderer.flipX = true;
            skilderect = -1;
        }

        if (Mathf.Abs(rigid.velocity.x) < minispeed)
        {
            anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isRightDown)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 2, 7 })) // 가속비
                rigid.AddForce(Vector2.right * 50 * derect, ForceMode2D.Force);
            else
                rigid.AddForce(Vector2.right * 10 * derect, ForceMode2D.Impulse);
        }

        if (isLeftDown)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 2, 7 }))
                rigid.AddForce(Vector2.left * 50 * derect, ForceMode2D.Force);
            else
                rigid.AddForce(Vector2.left * 10 * derect, ForceMode2D.Impulse);
        }

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if (isJumpDown && jetgo > 0 && !firstjump)
        {
            rigid.AddForce(Vector2.up * 50, ForceMode2D.Force);
            jetgo -= 0.02f;

            Jet.GetComponent<Image>().fillAmount = jetgo;
        }
        else if (jetgo < 1 && revolve)
        {
            jetgo += 0.002f;
            Jet.GetComponent<Image>().fillAmount = jetgo;
        }



        if (rigid.velocity.y < 0)
        {
            if (isgogoin && hhh.infinite) //공주
            {
                Vector3 vec1 = new Vector3(rigid.position.x - 0.14f, rigid.position.y - 0.275f, 0);
                Debug.DrawRay(vec1, Vector3.right * 0.3f, new Color(0, 1, 0));
                RaycastHit2D rayHit1 = Physics2D.Raycast(vec1, Vector3.right, 0.3f, LayerMask.GetMask("Platform"));
                RaycastHit2D rayHitt1 = Physics2D.Raycast(vec1, Vector3.right, 0.3f, LayerMask.GetMask("Enemy"));
                if (rayHit1 || rayHitt1)
                {
                    anim.SetBool("isJumping", false);
                }
            }
            else
            {
                Vector3 vec = new Vector3(rigid.position.x - 0.28f, rigid.position.y - 0.55f, 0);
                Debug.DrawRay(vec, Vector3.right * 0.6f, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Platform"));
                RaycastHit2D rayHitt = Physics2D.Raycast(vec, Vector3.right, 0.6f, LayerMask.GetMask("Enemy"));
                if (rayHit)
                {
                    if (hhh.jangchak.SequenceEqual(new int[] { 5, 0 }))//국왕
                        jump = 2;
                    if (hhh.jangchak.SequenceEqual(new int[] { 4, 2 }) && anim.GetBool("isJumping"))//왕자
                    {
                        jump += 1;
                        jumpmon = 0;
                        jumpcount.text = "Jump:" + jump.ToString();
                    }
                    ismonsterjump = 0;
                    if (hhh.jangchak.SequenceEqual(new int[] { 3, 2 }))
                        revolve = true;
                    anim.SetBool("isJumping", false);
                }
                if (rayHitt)
                {
                    if (hhh.jangchak.SequenceEqual(new int[] { 5, 0 }))
                        jump = 2;
                    if (hhh.jangchak.SequenceEqual(new int[] { 4, 2 }) && anim.GetBool("isJumping"))
                    {
                        jump += 1;
                        jumpmon = 0;
                        jumpcount.text = "Jump:" + jump.ToString();
                    }
                    ismonsterjump = 0;
                    if (hhh.jangchak.SequenceEqual(new int[] { 3, 2 }))
                        revolve = true;
                    anim.SetBool("isJumping", false);
                }
            }
        }

    }

    public void sww()
    {
        isswing = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && hhh.jangchak.SequenceEqual(new int[] { 1, 5 }) && hhh.infinite) // 클라이밍
        {
            anim.SetBool("isJumping", false);
            jump = 1;
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
            if (ismujuck)
            {
                if (hhh.jangchak.SequenceEqual(new int[] { 4, 0 }))
                    popo(500);
                else if (hhh.jangchak.SequenceEqual(new int[] { 3, 0 }))
                    popo(700);
                OnAttack(collision.transform, collision);
            }
            else
            {
                if (transform.position.y - 0.48f > collision.transform.position.y)
                {
                    OnAttack(collision.transform, collision);
                }
                else
                    OnDamaged();
            }
        }
        if (collision.gameObject.tag == "Spike")
        {
            if (hhh.infinite)
            {
                if (hhh.jangchak.SequenceEqual(new int[] { 5, 3 }))
                {
                    popo(-1000);
                    JoJo();
                    spsp = 1;
                }
                else if (hhh.jangchak.SequenceEqual(new int[] { 2, 1 }))
                {
                    popo(-100);
                    JoJo();
                }
                else
                    OnDamaged();
            }
            else
                OnDamaged();
        }

        if (collision.gameObject.tag == "Jump")
        {
            jumpPower = 35;
        }
        else
        {
            jumpPower = 17;
        }
        if (collision.gameObject.tag == "Ice" && !(hhh.jangchak.SequenceEqual(new int[] { 2, 6 }) && hhh.infinite))
        {
            minispeed = 100;
            rigid.drag = 0;
        }
        else
        {
            minispeed = 0.5f;
            rigid.drag = 2;
        }
        if (collision.gameObject.tag == "Return" && !(hhh.jangchak.SequenceEqual(new int[] { 2, 6 }) && hhh.infinite))
        {
            derect = -1;
        }
        else
        {
            derect = 1;
        }
        if (collision.gameObject.tag == "Black" && !(hhh.jangchak.SequenceEqual(new int[] { 2, 6 }) && hhh.infinite))
        {
            black.SetActive(true);
        }
        else if (!blac)
        {
            black.SetActive(false);
        }
        if (collision.gameObject.tag == "Invisible" && !(hhh.jangchak.SequenceEqual(new int[] { 2, 6 }) && hhh.infinite))
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);
        }
        else if (spriteRenderer.color[3] == 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
        if (collision.gameObject.tag == "Speed")
        {
            maxSpeed = 9;
            speedup = false;
        }
        else if (collision.gameObject.tag == "Slow" && !(hhh.jangchak.SequenceEqual(new int[] { 2, 6 }) && hhh.infinite))
        {
            speedup = false;
            maxSpeed = 2;
        }
        else if (!speedup)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 2, 7 }))
                maxSpeed = 100000;
            else maxSpeed = 4.5f;
        }

    }

    void JoJo()
    {
        spriteRenderer.color = new Color(1, 0, 0, 0.6f);
        Invoke("Jo", 1f);
    }

    void Jo()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }



    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemyy")
        {
            OnDamaged();
        }
        if (collision.gameObject.tag == "Fire")
        {
            OnDamaged();
        }

        if (collision.gameObject.tag == "Item")
        {
            bool isBronze = collision.name.Contains("Bronze");
            bool isSilver = collision.name.Contains("Silver");
            bool isGold = collision.name.Contains("Gold");

            if (hhh.jangchak.SequenceEqual(new int[] { 2, 5 }) && hhh.infinite)
            {
                infi.transform.position = new Vector2(infi.transform.position.x - 5, infi.transform.position.y);
            }

            if (isBronze)
            {
                if (hhh.jangchak.SequenceEqual(new int[] { 5, 2 }))
                    popo(200);
                gameManager.stagePoint += 5;
            }
            else if (isSilver)
            {
                if (hhh.jangchak.SequenceEqual(new int[] { 5, 2 }))
                    popo(400);
                gameManager.stagePoint += 10;
            }
            else if (isGold)
            {
                if (hhh.jangchak.SequenceEqual(new int[] { 5, 2 }))
                    popo(800);
                gameManager.stagePoint += 20;
            }

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            gameObject.layer = 11;
            if (hhh.stage == hhh.clear)
            {
                hhh.clear += 1;
                hhh.monney += 500;
            }
            hhh.Save();
            gameManager.victory();
            Timee();
        }
    }
    public void Timee()
    {
        Time.timeScale = 0;
    }

    public void OnDamaged()
    {
        if (hhh.jangchak.SequenceEqual(new int[] { 3, 4 }) && hhh.infinite) // 쉴드
        {
            if (life > 0)
            {
                gameObject.layer = 11;
                Invoke("heje", 1);
                gameManager.stagePoint += 200;
                spriteRenderer.color = new Color(0.5f, 0.5f, 1f, 0.8f);
                life -= 1;
                jumpcount.text = "shield:" + life.ToString();
            }
            else
                gameManager.HealthDown();
        }
        else if (!ismuuu)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 5, 4 }) && hhh.infinite) //네크로멘서
            {
                nene = 0;
                nenenene.GetComponent<Image>().fillAmount = nene / 3f;
                popo(5000);

            }
            gameManager.HealthDown();
        }
    }

    public void OnAttack(Transform enemy, Collision2D collision)
    {
        if (hhh.infinite)
        {
            if (hhh.jangchak.SequenceEqual(new int[] { 1, 0 }))
                gameManager.stagePoint += 15;
            else if (hhh.jangchak.SequenceEqual(new int[] { 5, 1 }))
                gameManager.stagePoint += 25;
            else
                gameManager.stagePoint += 10;
            if (hhh.jangchak.SequenceEqual(new int[] { 5, 4 })) // 네크로멘서
            {
                if (nene < 2)
                {
                    nene += 1;
                    nenenene.GetComponent<Image>().fillAmount = nene / 3f;
                }
                else
                {
                    gameManager.health = 2;
                    nenenene.GetComponent<Image>().fillAmount = 1f;

                }
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 2, 2 })) // 점핑
            {
                rigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
                if (ismonsterjump > 0)
                {
                    popo(ismonsterjump * 500);
                }
                ismonsterjump += 1;
            }
            if (hhh.jangchak.SequenceEqual(new int[] { 4, 2 })) // 왕자
            {
                jump += 1;
                jumpcount.text = "Jump:" + jump.ToString();
            }
        }
        else
        {
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
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
        Invoke("blbl", 1.5f);
    }

    public void blbl()
    {
        blac = false;
        black.SetActive(false);
    }


    public void OnDie()
    {
        capsulecollider.enabled = false;
        hhh.Save();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }


    public void PointUp(string pointt)
    {
        CancelInvoke("PointDown");
        point.gameObject.SetActive(true);
        point.text = pointt;
        point.color = new Color(1, 1, 1, 1);
        Invoke("PointDown", 3);
    }

    public void PointDown()
    {
        point.gameObject.SetActive(false);
    }



*/
}
