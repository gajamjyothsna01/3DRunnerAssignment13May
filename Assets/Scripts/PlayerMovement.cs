using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public float playerSpeed ;
    public float playerJumpForce;
    #endregion


    #region PRIVATE VARIABLES
    Rigidbody rb;
    //Vector3 movement;
    bool isGrounded = true;
    float horizontalMultiplier = 2;
    float horizontalInput;
    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
       // float horizontalInput = Input.GetAxis("Horizontal");
       horizontalInput = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        // inputX = Input.GetAxis("Horizontal");
        //  rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        //  rb.velocity = new Vector3(rb.velocity.x *playerSpeed, rb.velocity.y, rb.velocity.z);
        Vector3 forwardMove = transform.forward * playerSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * playerSpeed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }
    #endregion
}
