using System;
using UnityEngine;

[Serializable]
public class Hp
{
    [SerializeField]
    [Min(0f)]
    private float _max;
    private float _current;

    public float Max => _max;
    public float Current => _current;

    public Hp(float max)
    {
        if (max < 0f)
            throw new ArgumentOutOfRangeException();

        _max = max;
        _current = _max;
    }

    public float GetPercentage()
    {
        if (_max == 0)
            return 0;
        return _current / _max;
    }

    public void Increase(float value)
    {
        if (value < 0f)
            throw new ArgumentOutOfRangeException(nameof(value));

        IncreaseOnUnsignedValue(-value);
    }

    public void Decrease(float value)
    {
        if (value < 0f)
            throw new ArgumentOutOfRangeException(nameof(value));

        IncreaseOnUnsignedValue(-value);
    }

    private void IncreaseOnUnsignedValue(float value)
    {
        _current += value;
        _current = Mathf.Clamp(_current, 0f, _max);
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