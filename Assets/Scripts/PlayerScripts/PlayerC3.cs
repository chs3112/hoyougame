

public class PlayerC3 : PlayerMove_original
{
    Infinite fire;

    protected override void Awake()
    {
        base.Awake();
        fire = FindObjectOfType<Infinite>().GetComponent<Infinite>();
    }

    protected override void Start()
    {
        base.Start();
        fire.speed = 0.4f;
        fire.jengga = 0.02f;
        fire.maxspeed = 7.5f;
    }
}
