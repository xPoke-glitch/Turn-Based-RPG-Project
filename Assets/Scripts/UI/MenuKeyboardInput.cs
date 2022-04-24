using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKeyboardInput : MenuInput
{
    private void Update()
    {
        Up = Input.GetKeyDown(KeyCode.W);
        Left = Input.GetKeyDown(KeyCode.A);
        Right = Input.GetKeyDown(KeyCode.D);
        Down = Input.GetKeyDown(KeyCode.S);
        Select = Input.GetKeyDown(KeyCode.Return);
        Back = Input.GetKeyDown(KeyCode.Backspace);
    }
}
