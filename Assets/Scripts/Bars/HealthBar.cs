using Characters;
using Characters.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private BasicHealth _damageable;

    public void Awake()
    {
        _damageable.HealthChanged.AddListener(UpdateSliderOnHealthChanged);
    }

    public void OnDisable()
    {
        _damageable.HealthChanged.RemoveListener(UpdateSliderOnHealthChanged);
    }

    private void UpdateSliderOnHealthChanged()
    {
        _slider.value = Mathf.InverseLerp(0, _damageable.MaxHealth, _damageable.Health);
    }
}
