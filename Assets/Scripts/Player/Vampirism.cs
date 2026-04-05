using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private ClosestEnemyProvider _closestEnemyProvider;
    [SerializeField] private Slider _slider;

    private Health _health;
    private Coroutine _visualUpdateCoroutine;

    private bool _shoodDamage;
    private bool _isCoolingDown = false;

    private float _damageTime = 6;
    private float _coolDownTime = 4;

    private float _damagePerSecond = 0.15f;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_shoodDamage && _closestEnemyProvider.ClosestEnemy != null)
        {
            _closestEnemyProvider.ClosestEnemy.TakeDamage(_damagePerSecond * Time.deltaTime);
            _health.Heal(_damagePerSecond * Time.deltaTime);
        }
    }

    public void Work()
    {
        if (_isCoolingDown == false)
        {
            _isCoolingDown = true;
            _closestEnemyProvider.gameObject.SetActive(true);
            _shoodDamage = true;

            if(_visualUpdateCoroutine != null)
                StopCoroutine(_visualUpdateCoroutine);

            _visualUpdateCoroutine = StartCoroutine(UpdateVisual(_damageTime, _slider.minValue));

            StartCoroutine(StopDamageAfterDelay());
        }
    }

    private IEnumerator StopDamageAfterDelay()
    {
        yield return new WaitForSeconds(_damageTime);

        _closestEnemyProvider.gameObject.SetActive(false);
        _shoodDamage = false;

        StartCoroutine(StartCoolingDown());
    }

    private IEnumerator StartCoolingDown()
    {
        if(_visualUpdateCoroutine != null)
            StopCoroutine(_visualUpdateCoroutine);
    
        _visualUpdateCoroutine = StartCoroutine(UpdateVisual(_coolDownTime, _slider.maxValue));

        yield return new WaitForSeconds(_coolDownTime);

        _isCoolingDown = false;
    }

    private IEnumerator UpdateVisual(float time, float target)
    {
        while (Mathf.Approximately(_slider.value, target) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _slider.maxValue/time * Time.deltaTime);

            yield return null;
        }
    }
}
