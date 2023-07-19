using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class Botton : MonoBehaviour
{
    public TMP_Text nam;
    public TMP_Text cont;
    public Image imim;
    public Button wear;
    public GameObject bag;
    public Sprite noneImg;
    string now;

    void Start()
    {
        jeongri();
        if (HHHhh.hh.isRandom == 1) gho("R0", true);
        else gho(HHHhh.hh.jangchak, true);
    }

    void Update()
    {

    }

    public void gho(string id, bool ni) //i:캐릭 번호 d:캐릭 등급 ni:버튼 활성화 여부(보유캐릭인지)
    {
        HHHhh.hh.isRandom = 0;
        imim.color = new Color(1f, 1f, 1f);
        if (id == "R0")
        {
            int rrrr = Random.Range(0, HHHhh.hh.liRandom.Count);
            HHHhh.hh.isRandom = 1;
            now = HHHhh.hh.liRandom[rrrr];
            nam.text = "랜덤";
            cont.text = "보유캐릭중 랜덤으로 플레이 됩니다.";
            imim.sprite = HHHhh.hh.py_Data["G0"].img;
        }
        else
        {
            now = id;
            nam.text = HHHhh.hh.py_Data[id].player_name;
            cont.text = HHHhh.hh.py_Data[id].content;
            imim.sprite = HHHhh.hh.py_Data[id].img;
            if (id.Substring(0,1) == "X" && !ni){
                nam.text = "비공";
                cont.text = HHHhh.hh.py_Data[id].precontent;
                imim.sprite = noneImg;
                if(id == "X4")
                {
                    cont.text = (1000-HHHhh.hh.death).ToString()+"번 죽고 오세요.";
                }
            }
        }
        wear.interactable = ni;

    }

    

    public void jeongri()
    {
        int a = 0; // 캐릭 저장 위치
        Image img = bag.transform.GetChild(a).GetComponent<Image>();
        bag.transform.GetChild(a).name = "iR0";
        img.sprite = HHHhh.hh.py_Data["G0"].img;
        a += 1;
        foreach (string i in HHHhh.hh.py_Data.Keys)
        {
            if (HHHhh.hh.py_Data[i].inven != 0)
            {
                img = bag.transform.GetChild(a).GetComponent<Image>();
                bag.transform.GetChild(a).name = "i"+i;
                img.sprite = HHHhh.hh.py_Data[i].img;
                a += 1;
            }
        }
        //없는 캐릭-------------------------------------------------------------------
        foreach (string i in HHHhh.hh.py_Data.Keys)
        {
            if (HHHhh.hh.py_Data[i].inven == 0)
            {
                img = bag.transform.GetChild(a).GetComponent<Image>();
                if(i.Substring(0,1) == "X"){
                    bag.transform.GetChild(a).name = "n"+i;
                    img.sprite = noneImg;
                    a += 1;
                }
                else{
                    img.color = new Color(0.5f, 0.5f, 0.5f);
                    bag.transform.GetChild(a).name = "n"+i;
                    img.sprite = HHHhh.hh.py_Data[i].img;
                    a += 1;
                }
            }
        }
    }

    public void jang(){
        HHHhh.hh.jangchak = now;
    }

}