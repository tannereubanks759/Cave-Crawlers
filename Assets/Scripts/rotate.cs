using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool goingright;
    private float nextFire;
    private float fireRate = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        goingright = false;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 3.6)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                goingright = !goingright;
            }
            if (goingright == true)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * -40);
            }
            if (goingright == false)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * -40);
            }

            Debug.Log(Time.time);
        }
        
    }
    
      
}
