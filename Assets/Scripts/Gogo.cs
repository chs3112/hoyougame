using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gogo : MonoBehaviour
{
    void Awake()
    {
        HHHhh.hh = GameObject.Find("Num").GetComponent<HHHhh>();

    }

    public void Gogogo()
    {
        HHHhh.hh.Save();
        SceneManager.LoadScene("Lol");
    }

    public void Go()
    {
        HHHhh.hh.Save();
        HHHhh.hh.infinite = 101;
        HHHhh.hh.jeonpan = 0;
        HHHhh.hh.online = false;
        if(HHHhh.hh.isRandom == 1)
        {
            int rrrr = Random.Range(0, HHHhh.hh.liRandom.Count);
            HHHhh.hh.isRandom = 1;
            HHHhh.hh.jangchak = HHHhh.hh.liRandom[rrrr];
        }
        SceneManager.LoadScene("SampleScene");
    }

    
    public void Go2()
    {
        HHHhh.hh.Save();
        HHHhh.hh.infinite = 102;
        HHHhh.hh.jeonpan = 0;
        HHHhh.hh.online = false;
        if(HHHhh.hh.isRandom == 1)
        {
            int rrrr = Random.Range(0, HHHhh.hh.liRandom.Count);
            HHHhh.hh.isRandom = 1;
            HHHhh.hh.jangchak = HHHhh.hh.liRandom[rrrr];
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void Infi()
    {
        HHHhh.hh.Save();
        SceneManager.LoadScene("Infinite");
    }

    public void Signn()
    {
        HHHhh.hh.Save();
        SceneManager.LoadScene("Sign");
    }
    public void Home()
    {
        HHHhh.hh.Save();
        SceneManager.LoadScene("StartScenes");
    }

    public void store()
    {
        SceneManager.LoadScene("Store");
        HHHhh.hh.Save();
    }
}
