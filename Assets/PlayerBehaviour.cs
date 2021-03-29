using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float health = 100;
    public bool onSlime = false;
    public bool grounded = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.55f))
        {
            grounded = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            grounded = false;
            rb.AddForce(Vector3.up * 300);

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Slime"))
        {
            onSlime = true;
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            onSlime = false;
        }
    }
}
