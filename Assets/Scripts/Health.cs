using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private bool _godMode;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        if (ModeSwitcher.Instance.IsDefendMode())
            return;

        if (_godMode)
        {
            Debug.Log(gameObject + " is in God Mode. No damage taken.");
            return;
        }

        //Debug.Log(gameObject + " has taken " + damageTaken + " damage!");

        _currentHealth -= damageTaken;

        if (_currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Debug.Log(gameObject + " is dead");
        Destroy(gameObject);
    }
}
