using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerB4 : PlayerMove_original
{

    protected override void Awake()
    {
        base.Awake();
        gm.FindTrap = FindTrap;
    }
    
    void FindTrap(GameObject inst, int inin){
        
        if(inin == 6)
        {
            Tilemap col = inst.transform.GetChild(0).transform.GetChild(1).GetComponent<Tilemap>();
            col.color = new Color(1, 0, 0, 1);
        }
        if(inin == 17)
        {
            SpriteRenderer col = inst.transform.GetChild(4).GetComponent<SpriteRenderer>();
            col.color = new Color(1, 1, 1, 1);
        }
    }
}
