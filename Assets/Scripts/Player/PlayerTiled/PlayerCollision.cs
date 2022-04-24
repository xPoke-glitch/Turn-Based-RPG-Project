using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool LeftCollision { get; private set; }
    public bool RightCollision { get; private set; }
    public bool UpCollision { get; private set; }
    public bool DownCollision { get; private set; }
    public bool CenterCollision { get; private set; }

    [SerializeField]
    private float raycastRange;
    [SerializeField]
    private LayerMask movementsRaysLayerMask;
    [SerializeField]
    private LayerMask interactionLayerMask;
    [SerializeField]
    private bool debug;

    
    void Start()
    {
        LeftCollision = false;
        RightCollision = false;
        UpCollision = false;
        DownCollision = false;
        CenterCollision = false;
    }

    void FixedUpdate()
    {
        // Movements Collision
        RaycastHit2D left = Physics2D.Raycast(transform.position, -Vector2.right, raycastRange, movementsRaysLayerMask.value);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, raycastRange, movementsRaysLayerMask.value);
        RaycastHit2D up = Physics2D.Raycast(transform.position, Vector2.up, raycastRange, movementsRaysLayerMask.value);
        RaycastHit2D down = Physics2D.Raycast(transform.position, -Vector2.up, raycastRange, movementsRaysLayerMask.value);

        if (left.collider != null)
            LeftCollision = true;
        else
            LeftCollision = false;

        if (right.collider != null)
            RightCollision = true;
        else
            RightCollision = false;

        if (up.collider != null)
            UpCollision = true;
        else
            UpCollision = false;

        if (down.collider != null)
            DownCollision = true;
        else
            DownCollision = false;

        // Center Interaction Collision
        RaycastHit2D center = Physics2D.Raycast(transform.position, Vector3.forward, raycastRange, interactionLayerMask);
        if (center.collider != null)
        {
            CenterCollision = true;
            IInteractableTile tile = null;
            center.collider.gameObject.TryGetComponent<IInteractableTile>(out tile);
            if(tile!=null)
                tile.Interact(); // launch interaction
        }
        else
        {
            CenterCollision = false;
        }
    }

    void Update()
    {
        if (debug)
        {
            Vector3 up = transform.TransformDirection(Vector3.up) * raycastRange;
            Vector3 down = transform.TransformDirection(-Vector3.up) * raycastRange;
            Vector3 left = transform.TransformDirection(-Vector3.right) * raycastRange;
            Vector3 right = transform.TransformDirection(Vector3.right) * raycastRange;
            Vector3 center = transform.TransformDirection(Vector3.forward) * raycastRange;
            Debug.DrawRay(transform.position, up, Color.red);
            Debug.DrawRay(transform.position, down, Color.red);
            Debug.DrawRay(transform.position, left, Color.red);
            Debug.DrawRay(transform.position, right, Color.red);
            Debug.DrawRay(transform.position, center, Color.red);
        }
    }
}
