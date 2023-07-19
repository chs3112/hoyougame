using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ininin : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text monney;
    HHHhh hhh;

    void Start()
    {
        hhh = GameObject.Find("Num").GetComponent<HHHhh>();
        score.text = "High Score : " + (hhh.highScore).ToString();
        monney.text = "Monney : " + (hhh.monney).ToString();
    }

}
