using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreGogo : MonoBehaviour
{
    HHHhh hhh;

    private void Start()
    {
        hhh = GameObject.Find("Num").GetComponent<HHHhh>();
    }

    public void Go()
    {
        SceneManager.LoadScene("Storenew");
    }
    public void Exit()
    {
        SceneManager.LoadScene("StartScenes");
        hhh.Save();
    }
    public void Gogo()
    {
        SceneManager.LoadScene("Imformation");
    }

    public void cho()
    {
        hhh.Cho();
    }
}
