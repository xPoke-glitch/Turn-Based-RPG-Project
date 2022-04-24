using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuInput : MonoBehaviour
{
    public bool Down { get; protected set; }
    public bool Up { get; protected set; }
    public bool Right { get; protected set; }
    public bool Left { get; protected set; }
    public bool Select { get; protected set; }
    public bool Back { get; protected set; }

    public bool IsAnyInput { get { return Down || Up || Select || Back || Right || Left; } }
}
