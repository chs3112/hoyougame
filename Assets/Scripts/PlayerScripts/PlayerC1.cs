

public class PlayerC1 : PlayerMove_original
{
    bool firstmoney;
    protected override void Awake()
    {
        base.Awake();
        firstmoney = true;
    }

    protected override void Update()
    {
        base.Update();
        if (firstmoney && gm.score > 10000){
            gm.money += 1000;
            firstmoney = false;
        }
    }


}
