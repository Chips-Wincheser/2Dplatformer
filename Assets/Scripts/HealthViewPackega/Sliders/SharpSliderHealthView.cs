public class SharpSliderHealthView : Slider
{
    protected override void UpdateCounterDisplay(float health)
    {
        SliderHealth.value = health;
    }
}
