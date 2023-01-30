using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = new Vector3(moveDir.x, 0, moveDir.z) * speed;
        if (moveDir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), rotateSpeed * Time.deltaTime);
        rb.AddForce(Physics.gravity * 10f, ForceMode.Acceleration);
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}