using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Biie : MonoBehaviour
{
    public Image getimg;
    public Image[] getimgfour;
    public GameObject monneyplus;
    public GameObject[] monneyplusfour;
    public TMP_Text namee;
    public TMP_Text[] nameefour;
    public GameObject chang;
    public GameObject changfour;
    public TMP_Text monney;
    public TMP_Text[] monneyfour;
    public GameObject geoji;
    public Text mm;

    void Update()
    {
        mm.text = "monney" + HHHhh.hh.monney.ToString();
    }

    public void nomal()
    {
        if (HHHhh.hh.monney >= 1500)
        {
            HHHhh.hh.monney -= 1500;
            nonal(getimg, monneyplus, namee, monney);
            chang.SetActive(true);
        }
        else
        {
            geoji.SetActive(true);
        }
    }

    public void rare()
    {
        if (HHHhh.hh.monney >= 5000)
        {
            HHHhh.hh.monney -= 5000;
            for(int i = 0; i < 4; i++)
            {
                nonal(getimgfour[i], monneyplusfour[i], nameefour[i], monneyfour[i]);
            }
            changfour.SetActive(true);
        }
        else
        {
            geoji.SetActive(true);
        }
    }

    void py_get(string id, Image img, GameObject ga, TMP_Text txt, TMP_Text tt, int moint){
        string a = HHHhh.hh.len[id][Random.Range(0, HHHhh.hh.len[id].Count)];
        if (HHHhh.hh.py_Data[a].inven == 0)
        {
            txt.text = HHHhh.hh.py_Data[a].player_name;
            img.sprite = HHHhh.hh.py_Data[a].img;
            HHHhh.hh.py_Data[a].inven = 1;
            HHHhh.hh.liRandom.Add(a);
            ga.SetActive(false);
        }
        else
        {
            txt.text = HHHhh.hh.py_Data[a].player_name;
            img.sprite = HHHhh.hh.py_Data[a].img;
            tt.text = "monney+"+moint.ToString();
            HHHhh.hh.monney += moint;
            ga.SetActive(true);
        }
    }

    void nonal(Image img, GameObject ga, TMP_Text txt, TMP_Text tt)
    {

        float i = Random.Range(0.00f, 100.00f);
        if (i < 5)//sss 5%
        {
            py_get("S", img, ga, txt, tt, 5000);
        }
        else if (i < 20)//aaa 15%
        { 
            py_get("A", img, ga, txt, tt, 1500);
        }
        else if (i < 40)//bbb 20%
        {
            py_get("B", img, ga, txt, tt, 500);
        }
        else if (i < 70)//ccc 30%
        {
            py_get("C", img, ga, txt, tt, 250);
        }
        else//jjj 30%
        {
            py_get("F", img, ga, txt, tt, 1000);
        }
    }



    public void Exit()
    {
        SceneManager.LoadScene("StartScenes");
        HHHhh.hh.Save();
    }


}
