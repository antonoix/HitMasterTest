using System;
using UnityEngine;

public abstract class InputSystem
{
    public event Action<Vector3> OnClicked;

    protected readonly Camera _cam = Camera.main;
    private const float _defaultDistance = 20;

    public virtual void Update()
    {
        if (CheckIfClicked())
        {
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                OnClicked?.Invoke(hit.point);
            }
            else
            {
                OnClicked?.Invoke(_cam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * _defaultDistance));
            }
        }
    }

    protected abstract bool CheckIfClicked();
}
