using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCrawler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float PushForce;
    private float nextFire;
    public float fireRate;
    public GameObject blade;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        nextFire = Time.time;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down.normalized * PushForce;

        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(blade, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 40f;
            Destroy(collision.gameObject);
        }
    }
}
