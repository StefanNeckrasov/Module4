using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Animator _animator;

    private bool _isDie;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_isDie) return;

        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDie = true;
        _animator.SetTrigger("Die");
    }

    void Update()
    {
        
    }
}
