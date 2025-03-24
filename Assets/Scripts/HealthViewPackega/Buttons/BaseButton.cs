using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] protected Health PlayerHealth;

    private void OnEnable()
    {
        Button.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(HandleButtonClick);
    }

    protected abstract void HandleButtonClick();
}
