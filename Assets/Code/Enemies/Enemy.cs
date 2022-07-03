using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDied;

    [SerializeField] private Slider _sliderHP;
    protected Animator _anim;
    protected float _startHealth;
    protected float _currentHealth;

    protected virtual void Start()
    {
        _anim = GetComponent<Animator>();
        _currentHealth = _startHealth;
    }

    public virtual void TakeDamage()
    {
        _currentHealth -= 5;
        _sliderHP.value = _currentHealth / _startHealth;
        if (_currentHealth <= 0)
            Die();
    }

    protected void Die()
    {
        _anim.enabled = false;
        OnDied?.Invoke(this);
    }
}
