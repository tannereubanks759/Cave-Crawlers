using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float PushForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down.normalized * PushForce;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down.normalized * PushForce;

        if (this.transform.position.y < -6.8f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            rb.velocity = Vector2.down.normalized * PushForce;
        }
    }
}
