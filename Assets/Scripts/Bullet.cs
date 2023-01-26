using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    public Rigidbody2D rb;
    public float PushForce;
    private GameObject barrel;
    
    // Start is called before the first frame update
    void Start()
    {
        barrel = GameObject.FindGameObjectWithTag("Barrel");
        this.transform.position = barrel.transform.position;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * PushForce;
    }
}
