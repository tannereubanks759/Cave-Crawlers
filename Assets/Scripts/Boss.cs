using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject blade;
    public Rigidbody2D rb;
    public GameObject rotateObject;
    public bool bladeRunning;
    public bool boulderRunning;
    public GameObject boulder;

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        bladeRunning = true;
        boulderRunning = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > 3.5)
        {
            rb.velocity = Vector2.down.normalized * 1;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }



        if (health > 0 && this.transform.position.y < 3.6)
        {
            if (bladeRunning == true)
            {
                StartCoroutine(bladeWave());
                bladeRunning = false;
            }
            if (boulderRunning == true)
            {
                StartCoroutine(boulderWave());
                boulderRunning = false;
            }
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator bladeWave()
    {
        
        for (int i = 0; i < 27*2; i++)
        { 
            Instantiate(blade, rotateObject.transform.position, rotateObject.transform.rotation);
            yield return new WaitForSeconds(.3f);
        }
        boulderRunning = true;
    }

    IEnumerator boulderWave()
    {

        for (int i = 0; i < 10; i++)
        {
            Instantiate(boulder, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(1.5f);
        }
        bladeRunning = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            health -= 30;
            Destroy(collision.gameObject);
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }




}
