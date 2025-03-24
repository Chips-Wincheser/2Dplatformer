using TMPro;
using UnityEngine;

public class TextHealthView : HealthViewBase
{
    [SerializeField] private TextMeshProUGUI _counterText;
    
    protected override void UpdateCounterDisplay(float health)
    {
        health*=_healthPlayer.MaxValue;
        _counterText.text = health.ToString();
    }
}