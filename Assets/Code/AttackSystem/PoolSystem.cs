using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem<T> where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _pool;
    private Transform _container;

    public PoolSystem(T prefab, int startLength, Transform container)
    {
        _prefab = prefab;
        _container = container;
        _pool = new List<T>();
        FillPool(startLength);
    }

    private void FillPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newElement = Object.Instantiate(_prefab, _container);
            newElement.gameObject.SetActive(false);
            _pool.Add(newElement);
        }
    }

    public T GetElement()
    {
        foreach (var element in _pool)
        {
            if (!element.gameObject.activeInHierarchy)
            {
                element.gameObject.SetActive(true);
                return element;
            }
        }
        var newElement = Object.Instantiate(_prefab, _container);
        _pool.Add(newElement);
        return newElement;
    }
}
