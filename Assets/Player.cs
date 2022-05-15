using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 500;
    public float directionalSpeed = 20;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z),directionalSpeed * Time.deltaTime);

        
        rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime;


        
    }
}
