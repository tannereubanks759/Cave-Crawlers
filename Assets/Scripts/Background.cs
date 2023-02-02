using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float PushForce;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, 12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > 1)
        {
            rb.velocity = Vector2.down.normalized * PushForce;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
