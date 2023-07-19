using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;

public class HHHhh : MonoBehaviour
{
    private static HHHhh instance = null;

    
    public GameObject[] players;
    public Dictionary<string, Player_Data> py_Data;
    public Dictionary<string, GameObject> py_object;

    public int stage;
    public int level = 36;
    public int clear;
    public int monney = 9000;
    public int highScore = 0;
    public int infinite;
    public bool online;
    public int tyty;
    public int att;
    public int death;

    public string jangchak;

    public int jeonpan;

    public int isRandom;
    public List<string> liRandom = new List<string>();
    public Dictionary<string, List<string>> len;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static HHHhh hh
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
        set
        {
            if(null == instance)
            {
                value = null;
            }
            else
            {
                value = instance;
            }
        }
    }

    void Start()
    {
        jangchak = "G0";
        py_Data = new Dictionary<string, Player_Data>();
        py_object = new Dictionary<string, GameObject>();
        len = new Dictionary<string, List<string>>();
        foreach(GameObject i in players){
            Player_Data obdata = i.GetComponent<Player_Data>();
            py_Data.Add(obdata.id, obdata);
            py_object.Add(obdata.id, i);
            if (len.TryGetValue(obdata.id.Substring(0,1), out List<string> oblen)){
                len[obdata.id.Substring(0,1)].Add(obdata.id);
            }
            else{
                len.Add(obdata.id.Substring(0,1), new List<string>());
                len[obdata.id.Substring(0,1)].Add(obdata.id);
            }
        }
        isRandom = 0;
        att = 1;
        level = 36;
        Load();
        BetterStreamingAssets.Initialize();
        string alltext = readFIle("ggg.txt");
        string[] contents = alltext.Split('\n');
        foreach (string g in contents)
        {
            string[] line = g.Split('/');
            if (line[0].Substring(0,1) == "E"){
                py_Data[line[0].Substring(1,2)].precontent = line[2];
            }
            else{
                py_Data[line[0]].player_name = line[1];
                py_Data[line[0]].content = line[2];
            }
        }
        foreach (string i in py_Data.Keys)
        {
            if (py_Data[i].inven != 0)
            {
                liRandom.Add(i);
            }
        }
    }
    public string readFIle(string filename)
    {
        byte[] byteContents = BetterStreamingAssets.ReadAllBytes(filename);
        string contentsString = System.Text.Encoding.GetEncoding("UTF-8").GetString(byteContents);

        return contentsString;
    }


    public void Load()
    {
        if (!PlayerPrefs.HasKey("Clear"))
        {
            clear = 1;
        }
        else
        {
            clear = PlayerPrefs.GetInt("Clear");
        }
        foreach (string i in py_Data.Keys){
            if (PlayerPrefs.HasKey(i))
            {
                py_Data[i].inven = PlayerPrefs.GetInt(i);
            }
            else
            {
                if(i == "G0"){
                    py_Data[i].inven = 1;
                }
                else{
                    py_Data[i].inven = 0;
                }
            }
        }
        if (!PlayerPrefs.HasKey("Jangchak"))
        {
            jangchak = "G0";
        }
        else
        {
            jangchak = PlayerPrefs.GetString("Jangchak");
        }
        if (!PlayerPrefs.HasKey("Monney"))
        {
            monney = 1500;
        }
        else
        {
            monney = PlayerPrefs.GetInt("Monney");
        }
        if (!PlayerPrefs.HasKey("IsRandom"))
        {
            isRandom = 0;
        }
        else
        {
            isRandom = PlayerPrefs.GetInt("IsRandom");
        }
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            highScore = 0;
        }
        else
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (!PlayerPrefs.HasKey("Death"))
        {
            death = 0;
        }
        else
        {
            death = PlayerPrefs.GetInt("Death");
        }
    }

    public void Save()
    { 
        PlayerPrefs.SetInt("Clear", clear);
        foreach (string i in py_Data.Keys){
            PlayerPrefs.SetInt(i, py_Data[i].inven);
        }
        PlayerPrefs.SetString("Jangchak", jangchak);
        PlayerPrefs.SetInt("Monney", monney);
        PlayerPrefs.SetInt("IsRandom", isRandom);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("Death", death);
        PlayerPrefs.Save();

        
    }

    public void Delel()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Clear", 36);
        PlayerPrefs.SetString("Name", "");
        foreach (string i in py_Data.Keys){
            PlayerPrefs.SetInt(i, py_Data[i].inven);
        }
        PlayerPrefs.SetString("Jangchak", jangchak);
        PlayerPrefs.SetInt("Monney", 1000000);
        PlayerPrefs.SetInt("HighScore", 1000000);
        PlayerPrefs.SetInt("Death", 1000);
    }

    public void Cho()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Load();
    }

}


