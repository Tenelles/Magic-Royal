using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private MortalBody _target;
    private Scrollbar _scrollbar;


    private void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
        _target.OnHpChanged += UpdateValue;
    }

    private void OnDestroy()
    {
        _target.OnHpChanged -= UpdateValue;
    }

    private void UpdateValue(HealthPoints healthPoints) => _scrollbar.size = healthPoints.CurrentPercentage;
}

