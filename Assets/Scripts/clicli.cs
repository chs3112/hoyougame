using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class clicli : MonoBehaviour, IPointerClickHandler
{
    public Botton bt;

    public void OnPointerClick(PointerEventData ddata)
    {
        if(name.Substring(0, 1) == "i")
        {
            bt.gho(name.Substring(1, 2), true);
        }
        if (name.Substring(0, 1) == "n")
        {
            bt.gho(name.Substring(1, 2), false);
        }
    }

}
