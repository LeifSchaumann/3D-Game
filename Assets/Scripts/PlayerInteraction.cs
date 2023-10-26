using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask pickUpMask;
    public float pickUpRange;
    public Transform pickUpTarget;

    private Camera playerCamera;
    private Rigidbody heldRB;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldRB != null)
            {
                heldRB.useGravity = true;
                heldRB = null;
            } else
            {
                Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(cameraRay, out RaycastHit hit, pickUpRange, pickUpMask))
                {
                    heldRB = hit.rigidbody;
                    heldRB.useGravity = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (heldRB != null)
        {
            Vector3 dirToTarget = pickUpTarget.position - heldRB.position;
            heldRB.velocity = dirToTarget * dirToTarget.magnitude * 20f;
            heldRB.angularVelocity *= 0.95f;
        }
    }
}
