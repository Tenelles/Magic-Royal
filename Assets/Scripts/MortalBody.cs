using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MortalBody : MonoBehaviour
{
    public event Action<HealthPoints> HealthPointsChanged;

    [SerializeField] private HealthPoints _healthPoints = new HealthPoints(1);
    private bool _isVulnerable;

    public bool IsVulnerable => _isVulnerable;

    private void Start()
    {
        _isVulnerable = true;
        Debug.Log(_healthPoints.CurrentPercentage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TakeDamage(5f);
    }

    private void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (!_isVulnerable)
            return;

        _healthPoints.Decrease(damage);

        StartCoroutine(nameof(ChangeVulnerability));
        HealthPointsChanged?.Invoke(_healthPoints);
        Debug.Log(_healthPoints.CurrentPercentage);
    }

    private IEnumerator ChangeVulnerability()
    {
        _isVulnerable = false;
        yield return new WaitForSeconds(0.5f);
        _isVulnerable = true;
    }

}
