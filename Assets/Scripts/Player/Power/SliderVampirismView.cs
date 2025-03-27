using System.Collections;
using UnityEngine;

public class SliderVampirismView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _vampirismSlider;

    public void StartVampirism(float vampirismDuration, float cooldownDuration)
    {
        _vampirismSlider.gameObject.SetActive(true);
        StartCoroutine(UpdateSlider(vampirismDuration, cooldownDuration));
    }

    private IEnumerator UpdateSlider(float vampirismDuration, float cooldownDuration)
    {
        float time = 0;
        while (time < vampirismDuration)
        {
            time += Time.deltaTime;
            _vampirismSlider.value = 1 - (time / vampirismDuration);
            yield return null;
        }

        time = 0;
        while (time < cooldownDuration)
        {
            time += Time.deltaTime;
            _vampirismSlider.value = time / cooldownDuration;
            yield return null;
        }
    }
}
