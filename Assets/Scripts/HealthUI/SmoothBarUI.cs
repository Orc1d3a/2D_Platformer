using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class SmoothBarUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private float _speed = 0.4f;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateSlider;
    }

    private void UpdateSlider()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateVisualHealth());
    }

    private IEnumerator UpdateVisualHealth()
    {
        float target = _health.CurrentHealth / _health.MaxHealth;

        while (Mathf.Approximately(_slider.value, target) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
