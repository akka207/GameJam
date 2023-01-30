using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI speedUI;
    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;
    [Header("Player Move")]
    private Vector3 moveDirection;

    [SerializeField]
    private float moveSpeed;
    private float horizotalInput;
    private float verticalInput;
    [SerializeField]
    private Transform orintation;
    [SerializeField]
    private Rigidbody rb;

    private void InputAxis()
    {
        horizotalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        moveDirection = orintation.forward * verticalInput + orintation.right * horizotalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f);
    }
    private void SpeedControl()
    {
        Vector3 flatVelosity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        speedUI.text = Mathf.Round(flatVelosity.magnitude).ToString();
        if(flatVelosity.magnitude>moveSpeed)
        {
            Vector3 limitedVelosity = flatVelosity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelosity.x,rb.velocity.y, limitedVelosity.z);
        }
    }
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        InputAxis();
        SpeedControl();
        if (grounded)
            rb.drag = groundDrag;
        else rb.drag = 0;
    }
    void FixedUpdate()
    {
        Debug.Log(horizotalInput + " : " + verticalInput);
        MovePlayer();
    }

}
