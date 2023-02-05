using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject gun;
    public GameObject Bullet;

    public float health;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public bool isDead;
    

    private float moveSpeed, moveHorizontal;
    public SpriteRenderer sprite;
    private Rigidbody2D rb2D;
    private float nextFire;
    public float fireRate;

    public Slider slider;

    private bool isPaused;
    public GameObject canvas;

    public GameObject DeathParticle;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        health = 100;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        isPaused = canvas.GetComponent<UiScript>().GetPaused();

        //gun movement
        if(!isDead && !isPaused)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - this.transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            gun.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        

        //firing
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Bullet);
        }

        if(health <= 0)
        {
            Die();
        }

    }
    private void FixedUpdate()
    {
        if ((moveHorizontal > 0.1f || moveHorizontal < -.1f))
        {
            
            if (moveHorizontal > .1f)
            {
                sprite.flipX = false;
            }
            else if (moveHorizontal < -.1f)
            {
                sprite.flipX = true;
            }
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blade")
        {
            health -= 30;
            slider.value = health;
            Debug.Log("hit");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "boulder")
        {
            Die();
            slider.value = 0;
        }
        
    }

    public void Die()
    {
        
        isDead = true;
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
    }
    public void SetDead(bool value)
    {
        isDead = value;
    }

    
}
