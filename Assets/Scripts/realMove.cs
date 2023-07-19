using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class realMove : MonoBehaviour
{
    public Transform play;
    PlayerMove_original py;
    public static Action Aright;
    public static Action Arightup;
    public static Action Aleft;
    public static Action Aleftup;
    public static Action Ajump;
    public static Action Ajumpup;
    public static Action Askill;
    public static Action Askillup;

    private void Start()
    {
        py = play.GetChild(0).GetComponent<PlayerMove_original>();
    }
    public void Right()
    {
        Aright();
    }

    public void RightUp()
    {
        Arightup();
    }

    public void Left()
    {
        Aleft();
    }

    public void LeftUp()
    {
        Aleftup();
    }

    public void Jump()
    {
        Ajump();
    }

    public void JumpUp()
    {
        Ajumpup();
    }

    public void Skill()
    {
        Askill();
    }

    public void SkillUp()
    {
        Askillup();
    }

}

