using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject blade;
    public Rigidbody2D rb;
    public GameObject rotateObject;
    public GameObject rotateObject2;
    public bool bladeRunning;
    public bool boulderRunning;
    public bool polyRunning;
    public GameObject boulder;

    public float health;

    public Animator anim;

    public AudioSource source;
    public AudioClip shoot;
    public AudioClip boulderClip;
    // Start is called before the first frame update
    void Start()
    {
        bladeRunning = true;
        boulderRunning = false;
        polyRunning = false;
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
            if (polyRunning == true)
            {
                StartCoroutine(polyAttack());
                polyRunning = false;
            }
        }

        if(health <= 0)
        {
            
            anim.SetBool("bossDead", true);
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
        source.clip = shoot;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(boulder, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(1.5f);
        }
        polyRunning = true;
    }

    IEnumerator polyAttack()
    {
        source.clip = shoot;
        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                rotateObject2.transform.Rotate(new Vector3(0, 0, rotateObject2.transform.rotation.z + 45));
                Instantiate(blade, rotateObject2.transform.position, rotateObject2.transform.rotation);
            }
            playSound();
            yield return new WaitForSeconds(.5f);
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
    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void playSound()
    {
        source.Play();
    }




}
