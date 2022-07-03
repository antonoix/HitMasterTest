using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    private float _activatedTime;

    public void Init(Vector3 aim, Vector3 position)
    {
        transform.position = position;
        transform.LookAt(aim);
        _activatedTime = Time.time;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (Time.time > _activatedTime + 5)
            Deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out _))
            return;
        FindEnemyComponent(other.gameObject);
        Deactivate();
    }

    private void FindEnemyComponent(GameObject currentObject)
    {
        while (currentObject != null)
        {
            if (currentObject.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage();
                break;
            }
            if (currentObject.transform.parent == null)
                break;
            currentObject = currentObject.transform.parent.gameObject;
        }
    }

    private void Deactivate()
    {
        _activatedTime = float.MaxValue;
        gameObject.SetActive(false);
    }
}
