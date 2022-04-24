using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveUnit;

    private PlayerInput _input;
    private PlayerCollision _collision;

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _collision = GetComponent<PlayerCollision>();
    }

    void Update()
    {
        if (_input.Left && !_collision.LeftCollision && !_collision.CenterCollision)
        {
            transform.position = new Vector3(transform.position.x - moveUnit, transform.position.y, transform.position.z);
        }
        else if (_input.Right && !_collision.RightCollision && !_collision.CenterCollision)
        {
            transform.position = new Vector3(transform.position.x + moveUnit, transform.position.y, transform.position.z);
        }
        else if (_input.Up && !_collision.UpCollision && !_collision.CenterCollision)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveUnit, transform.position.z);
        }
        else if (_input.Down && !_collision.DownCollision && !_collision.CenterCollision)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveUnit, transform.position.z);
        }
    }
}
