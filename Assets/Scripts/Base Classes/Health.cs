using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract event Action<float> HealthChanged;
    public abstract void TakeDamage(int damage);
    public abstract void Death();
}
