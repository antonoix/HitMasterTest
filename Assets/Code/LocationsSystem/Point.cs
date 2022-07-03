using System;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public event Action OnTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out var hero))
        {
            OnTouched?.Invoke();
        }
    }
}
