

public class PlayerB5 : PlayerMove_original
{
    protected override void EncounterCliff()
    {
        popo(300);
        base.PlayerReposition(false);
    }


}
