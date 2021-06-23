using System;
using System.Collections;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Body : MonoBehaviour, IDamageable
    {
        public event Action<Hp> HpChanged;

        [SerializeField] private Hp _healthPoints;
        private bool _isVulnerable;

        public bool IsVulnerable => _isVulnerable;

        private void Start()
        {
            _isVulnerable = true;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (!_isVulnerable)
                return;

            _healthPoints.Decrease(damage);

            StartCoroutine(nameof(ChangeVulnerability));
            HpChanged?.Invoke(_healthPoints);
        }

        public void TakeHealing(float healing)
        {
            if (healing < 0)
                throw new ArgumentOutOfRangeException(nameof(healing));

            _healthPoints.Increase(healing);

            HpChanged?.Invoke(_healthPoints);
        }

        private IEnumerator ChangeVulnerability()
        {
            _isVulnerable = false;
            yield return new WaitForSeconds(0.5f);
            _isVulnerable = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            TakeDamage(5f);
        }
    }
}