using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public float playerSpeed ;
    //public float playerJumpForce;
    #endregion


    #region PRIVATE VARIABLES
    Rigidbody rb;
    //Vector3 movement;
    bool isGrounded = true;
    float horizontalMultiplier = 2;
    float horizontalInput;
   // [SerializeField] LayerMask groundMask;
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
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }*/

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
    /*
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * playerJumpForce);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CoinS" || collision.gameObject.tag == "CoinG")
        {
            //Instantiate(particlePfab,this.transform.position,Quaternion.identity);
            GameObject expolsionPrefab = PoolScript.instance.GetObjectsFromPool("StarA");
            if (expolsionPrefab != null)
            {
                expolsionPrefab.SetActive(true);
                Debug.Log("Explosion True");
                expolsionPrefab.transform.position = transform.position + new Vector3(0,1,0);
            }
            
            Debug.Log("Collision Happened");
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().Score(10);
            collision.gameObject.SetActive(false);
            Debug.Log("GameObject False");
            //expolsionPrefab.SetActive(false);
        }
    }
    #endregion
}
