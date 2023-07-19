using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerStage : PlayerMove_original
{

    protected override void IsEnable()
    {
        if (HHHhh.hh.infinite < 10){
            this.enabled = true;
            isabled = true;
        }
        else{
            this.enabled = false;
            isabled = false;
        }

    }
}
