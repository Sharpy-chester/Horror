using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    float movementMultiplier = 10f;
    float xDir;
    float zDir;
    Vector3 moveDirection;
    Rigidbody rb;
    internal bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        moveDirection = xDir * Vector3.right + zDir * Vector3.forward;
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            Movement();
        }
    }

    void Movement()
    {
        rb.AddRelativeForce(moveDirection.normalized * playerSpeed, ForceMode.Acceleration);
    }
}
