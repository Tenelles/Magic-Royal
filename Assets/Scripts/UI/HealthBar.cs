using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private IDamageable _target;
    private Scrollbar _scrollbar;


    private void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
        _target.HpChanged += UpdateValue;
    }

    private void OnDestroy()
    {
        _target.HpChanged -= UpdateValue;
    }

    private void UpdateValue(Hp healthPoints) => _scrollbar.size = healthPoints.GetPercentage();
}

