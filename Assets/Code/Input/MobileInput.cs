using UnityEngine;

public class MobileInput : InputSystem
{
    protected override bool CheckIfClicked()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
