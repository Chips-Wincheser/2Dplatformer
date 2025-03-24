public class ButtonTreatment : BaseButton
{
    protected override void HandleButtonClick()
    {
        if (PlayerHealth != null)
            PlayerHealth.Treatment(15);
    }
}