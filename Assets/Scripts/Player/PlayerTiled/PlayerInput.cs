using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool Left { get; private set; }
    public bool Right { get; private set; }
    public bool Up { get; private set; }
    public bool Down { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        Left = Input.GetKeyDown(KeyCode.A);
        Right = Input.GetKeyDown(KeyCode.D);
        Up = Input.GetKeyDown(KeyCode.W);
        Down = Input.GetKeyDown(KeyCode.S);
    }
}
