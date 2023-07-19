using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerX2 : PlayerMove_original
{
    bool ismoney;

    protected override void Start()
    {
        base.Start();
        gm.originTime *= 0.8f;
        Time.timeScale = gm.originTime;
        ismoney = true;
    }

    protected override void Update()
    {
        base.Update();
        if (gm.money >= 10000 && ismoney)
        {
            gm.money += 2000;
            ismoney = false;
        }
    }


}
