public class ButtonDamage : BaseButton
{
    protected override void HandleButtonClick()
    {
        if(PlayerHealth != null)
            PlayerHealth.TakeDamage(15);
    }
}