using UnityEngine;

public class PlayerB1 : PlayerMove_original
{
    
    public GameObject Seaes;
    protected override void Awake()
    {
        base.Awake();
        gm.Seamake = Seamake;
    }

    void Seamake(Vector2 vec){
        Instantiate(Seaes, vec, Quaternion.identity);
    }


}
