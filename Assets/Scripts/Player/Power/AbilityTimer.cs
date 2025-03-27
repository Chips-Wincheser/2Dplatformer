using System.Collections;
using UnityEngine;

public class AbilityTimer : MonoBehaviour
{
    [SerializeField] private SliderVampirismView _slider;
    [SerializeField] private HandlerTriggerPower _triggerPower;

    private float _vampirismDuration = 6f;
    private float _cooldownTime = 4f;

    private WaitForSeconds _waitForVampirismDuration;
    private WaitForSeconds _waitForCooldownDuration;

    public bool IsOnCooldown { get; private set; }
    public bool IsVampirismActive { get; private set; }

    private void Awake()
    {
        _waitForVampirismDuration=new WaitForSeconds(_vampirismDuration);
        _waitForCooldownDuration=new WaitForSeconds(_cooldownTime);
    }

    public void StartCooldown()
    {
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        IsOnCooldown = true;
        IsVampirismActive = true;

        _slider.StartVampirism(_vampirismDuration, _cooldownTime);

        yield return _waitForVampirismDuration;
        
        IsVampirismActive = false;

        _triggerPower.ClearEnemysList();
        _triggerPower.SpriteCollisionToggle(false);
        
        yield return _waitForCooldownDuration;
        
        IsOnCooldown = false;
    }
}
