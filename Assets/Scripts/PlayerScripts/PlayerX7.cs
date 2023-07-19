using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class PlayerX7 : PlayerMove_original
{
    bool isupping;
    public GameObject explode;

    protected override void Awake()
    {
        base.Awake();
        isupping = false;
    }

    public void exxpl()
    {
        if (!isupping)
        {
            isupping = true;
            StartCoroutine(ess(Instantiate(explode, transform.position, Quaternion.identity)));
        }
    }

    IEnumerator ess(GameObject a)
    {
        for (int i = 0; i < 35; i++)
        {
            a.transform.localScale = new Vector3(a.transform.localScale.x + 1, a.transform.localScale.y + 1, 1);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(a);
        isupping = false;
    }


}
