using UnityEngine;

public class PCInput : InputSystem
{
    protected override bool CheckIfClicked()
    {
        return Input.GetMouseButtonDown(0);
    }
}
