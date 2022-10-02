using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Shell : MonoBehaviour
{
    [SerializeField] float force = 50f;
    [SerializeField] GameObject explosion;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
    private void Update()
    {
        transform.forward = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explode= Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explode, 1.6f);
        Destroy(gameObject);
    }
}
