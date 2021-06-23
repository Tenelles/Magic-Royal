using System;

interface IDamageable
{
    event Action<Hp> HpChanged;

    void TakeDamage(float damage);

    void TakeHealing(float healing);
}
