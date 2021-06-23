using System;
using UnityEngine;

[Serializable]
public class HealthPoints
{
    [SerializeField]
    [Min(float.Epsilon)]
    private float _max;

    [SerializeField]
    [Range(float.Epsilon, 1f)]
    private float _current;

    public float Max => _max;
    public float CurrentValue => _current * _max;
    public float CurrentPercentage => _current;

    public HealthPoints(float max)
    {
        if (max <= 0f)
            throw new ArgumentOutOfRangeException();

        _max = max;
        _current = 1f;
    }

    public void Increase(float value)
    {
        if (value < 0f)
            throw new ArgumentOutOfRangeException(nameof(value));

        _current += value / _max;
        if (_current > 1f)
            _current = 1f;
    }
    public void Decrease(float value)
    {
        if (value < 0f)
            throw new ArgumentOutOfRangeException(nameof(value));

        _current -= value / _max;
        if (_current < 0f)
            _current = 0f;
    }
    public void IncreaseMax(float value)
    {
        if (value < 0f)
            throw new ArgumentOutOfRangeException(nameof(value));

        _max += value;
    }
    public void DecreaseMax(float value)
    {
        if (value < 0f || value >= _max)
            throw new ArgumentOutOfRangeException(nameof(value));

        _max -= value;
    }
}