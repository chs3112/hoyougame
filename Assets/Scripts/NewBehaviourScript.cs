using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] txt;
    GameObject[] bt;
    GameObject[] tt;
    Text[] texts;
    Button[] btn;

    void Start()
    {
        HHHhh.hh.Load();
        tt = new GameObject[HHHhh.hh.level];
        texts = new Text[HHHhh.hh.level];
        bt = new GameObject[HHHhh.hh.level];
        btn = new Button[HHHhh.hh.level];
        for (int i = 0; i < 18; i++)
        {
            bt[i] = txt[0].transform.GetChild(i).gameObject;
            btn[i] = bt[i].GetComponent<Button>();
            tt[i] = bt[i].transform.GetChild(1).gameObject;
            texts[i] = tt[i].GetComponent<Text>();
        }
        for(int i = 18; i < 36; i++)
        {
            bt[i] = txt[1].transform.GetChild(i-18).gameObject;
            btn[i] = bt[i].GetComponent<Button>();
            tt[i] = bt[i].transform.GetChild(1).gameObject;
            texts[i] = tt[i].GetComponent<Text>();
        }
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = true;

        }
        for (int i = 0; i < HHHhh.hh.clear - 1; i++)
        {
            texts[i].text = "<color=lime>" + "V" + "</color>";
            texts[i].gameObject.SetActive(true);
        }
        if (HHHhh.hh.clear < HHHhh.hh.level)
        {
            texts[HHHhh.hh.clear].gameObject.SetActive(false);
            for (int i = HHHhh.hh.level - 1; i > HHHhh.hh.clear - 1; i--)
            {
                texts[i].text = "<color=red>" + "X" + "</color>";
                texts[i].gameObject.SetActive(true);
                btn[i].interactable = false;
            }
        }
        if(HHHhh.hh.clear >= 18)
        {
            txt[0].SetActive(false);
            txt[1].SetActive(true);
        }
        else
        {
            txt[0].SetActive(true);
            txt[1].SetActive(false);
        }
    }


    public void Ooone()
    {
        string ggg = EventSystem.current.currentSelectedGameObject.name;
        for(int i = 1; i < HHHhh.hh.level + 1; i++)
        {
            if (ggg == "Button" + i.ToString())
                HHHhh.hh.stage = i;
        }
    }

    public void fff()
    {
        HHHhh.hh.infinite = 0;
        HHHhh.hh.online = false;
        SceneManager.LoadScene("SampleScene");        
        HHHhh.hh.Save();

    }


    public void Exit()
    {
        SceneManager.LoadScene("StartScenes");
        HHHhh.hh.Save();
    }


}
