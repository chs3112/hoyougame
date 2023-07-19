using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System;

public class GameManager : MonoBehaviour
{
    public int money;
    public int stageIndex;
    public int health;
    public int score;
    public PlayerMove_original player;
    public GameObject Stage;
    public GameObject[] Stages;
    public GameObject[] Infinite;
    public int inin;
    public GameObject attempt;
    TextMesh ttt;
    public Text Try;

    public Text UIPoint;
    public Text point;
    public Text UIStage;
    public GameObject Victory;
    public GameObject UIRestartBtn2;
    public GameObject memuSet;
    Vector3 vec = new Vector3(0, 0, 0);
    public GameObject cos;
    public GameObject fire;
    public GameObject newplayer;
    public Image getimg;
    public TMP_Text namee;
    bool ngo;
    public Text tntn;
    public GameObject metor;
    public TMP_Text rrname;
    public Action<Vector2> Seamake;
    public Action<GameObject, int> FindTrap;

    public Action LastScoreCheck;
    public float originTime;
    public Transform pyT;



    void Awake()
    {
        Instantiate(HHHhh.hh.py_object[HHHhh.hh.jangchak], new Vector3(0,0,0), Quaternion.identity, pyT);
        ttt = attempt.GetComponent<TextMesh>();
        if (HHHhh.hh.infinite > 100)
            attempt.SetActive(false);
        else
            attempt.SetActive(true);
        ttt.text = "Attempt " + HHHhh.hh.att.ToString();
        player = FindObjectOfType<PlayerMove_original>().GetComponent<PlayerMove_original>();
        Time.timeScale = 1f;
        originTime = 1f;
    }

    void Start()
    {
        if (HHHhh.hh.infinite > 100) metor.SetActive(true);
        else metor.SetActive(false);
        if (HHHhh.hh.infinite == 102){
            originTime *= 2;
            Time.timeScale = originTime;
        }
        if (HHHhh.hh.infinite < 10)
        {
            stageIndex = HHHhh.hh.stage - 1;
            fire.SetActive(false);
            UIPoint.gameObject.SetActive(false);
            point.gameObject.SetActive(false);
            NextStage();
        }
        else
        {
            UIStage.gameObject.SetActive(false);
            fire.SetActive(true);
            money = 0;
            score = 0;
            HHHhh.hh.tyty = 0;
        }
        rrname.text = HHHhh.hh.py_Data[HHHhh.hh.jangchak].player_name;
    }

    void sang()
    {   
        if (vec.x - player.transform.position.x < 100)
        {
            if(UnityEngine.Random.Range(1, 5) == 1 && Seamake != null){
                Seamake(vec);
                vec.x += 20;
            }
            else
            {
                inin = UnityEngine.Random.Range(0, Infinite.Length);
                GameObject inst = Instantiate(Infinite[inin], vec, Quaternion.identity);
                if(FindTrap != null) FindTrap(inst, inin);
                vec.x += 20;
            }
        }
    }
    public void Restart()
    {
        if(HHHhh.hh.isRandom == 1)
        {

            int rrrr = UnityEngine.Random.Range(0, HHHhh.hh.liRandom.Count);
            HHHhh.hh.isRandom = 1;
            HHHhh.hh.jangchak = HHHhh.hh.liRandom[rrrr];
        }
        SceneManager.LoadScene("SampleScene");
    }


    public void Continue()
    {
        memuSet.SetActive(false);
        Time.timeScale = originTime;

    }


    void Update()
    {
        if (HHHhh.hh.infinite > 100)
        {
            UIPoint.text = "Monney" + (money).ToString();
            point.text = score.ToString();
        }
        


        if (Input.GetButtonDown("Cancel"))
        {
            if (memuSet.activeSelf)
            {
                memuSet.SetActive(false);
                Time.timeScale = originTime;
            }
            else
            {
                memuSet.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (HHHhh.hh.infinite > 100)
        {
            sang();
        }

        if (Input.GetKeyDown(KeyCode.R) && Victory.activeSelf == true)
        {
            Restart();
        }


    }
    /*
    public void Cont()
    {
        memuSet.SetActive(false);
        if (HHHhh.hh.jangchak.SequenceEqual(new int[] { 5, 1 }) && HHHhh.hh.infinite)
        {
            Time.timeScale = 0.8f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    */
    public void NextStage()
    {
        if(Stage.transform.childCount != 0)
        {
            for(int i = 0; i < Stage.transform.childCount; i++)
            {
                Destroy(Stage.transform.GetChild(i).gameObject);
            }
        }
        Vector3 vecc = new Vector3(-1.5f, 0, -7.5f);
        Instantiate(Stages[stageIndex], vecc, Quaternion.identity).transform.parent = Stage.transform;
        UIStage.text = "STAGE" + (stageIndex + 1);
        money = 0;
        HHHhh.hh.Save();
    }

    
    void collectPlayer(string id){

        namee.text = HHHhh.hh.py_Data[id].player_name;
        getimg.sprite = HHHhh.hh.py_Data[id].img;
        HHHhh.hh.py_Data[id].inven = 1;
        HHHhh.hh.liRandom.Add(id);
        newplayer.SetActive(true);
    }

    public void victory()
    {
        Try.text = "Attempt " + HHHhh.hh.att.ToString();
        HHHhh.hh.att = 1;
        tntn.text = "YOU WIN";
        Victory.SetActive(true);
        UIRestartBtn2.SetActive(true);
        if (HHHhh.hh.stage > HHHhh.hh.clear || stageIndex == HHHhh.hh.level - 1)
            UIRestartBtn2.SetActive(false);
        if (HHHhh.hh.stage == 12 && HHHhh.hh.py_Data["X1"].inven == 0)
        {
            collectPlayer("X1");
        }
        else if (HHHhh.hh.stage == 24 && HHHhh.hh.py_Data["X3"].inven == 0)
        {
            collectPlayer("X3");
        }
        else if (HHHhh.hh.stage == 36 && HHHhh.hh.py_Data["X6"].inven == 0)
        {
            print("adf");
            collectPlayer("X6");
        }
        HHHhh.hh.Save();
    }



    


    public void Next()
    {
        HHHhh.hh.stage += 1;
        HHHhh.hh.infinite = 0;
        SceneManager.LoadScene("SampleScene");
        HHHhh.hh.Save();
    }



    public void GameExit()
    {
        if (HHHhh.hh.infinite < 10)
        {
            HHHhh.hh.att = 1;
            SceneManager.LoadScene("Lol");
        }
        else
        {
            HHHhh.hh.Save();
            SceneManager.LoadScene("Infinite");
        }
    }

    public void check()
    {
        if (ngo)
        {
            Restart();
        }
    }
//게임 메뉴 버튼
    public void Timie(){
        Time.timeScale = 0f;
    }



}