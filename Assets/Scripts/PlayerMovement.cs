using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public float playerSpeed = 5f;
    public float playerJumpForce = 2f;
    #endregion

    #region PRIVATE VARIABLES
    Rigidbody rb;

    bool isGrounded = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * playerJumpForce);
            isGrounded = false;
        }


    }
    private void FixedUpdate()
    {
        // inputX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, rb.velocity.z);


    }
    #endregion
}
