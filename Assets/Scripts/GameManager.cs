using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPref;
    public bool waveRunning;
    public GameObject Obstacle;


    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        waveRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if (currentTime < 20)
        {
            if(waveRunning == true)
            {
                StartCoroutine(wave(5, 4));
                waveRunning = false;
            }
            
        }
        if (currentTime < 30)
        {
            if (waveRunning == true)
            {
                StartCoroutine(wave(5, 2));
                waveRunning = false;
            }

        }
        if(currentTime < 50 && currentTime > 30)
        {
            if(waveRunning == true)
            {
                StartCoroutine(waveObst(5, 3));
                waveRunning = false;
            }
        }

    }
    IEnumerator wave(int waveCount, int time)
    {
        for(int i =0; i < waveCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8, 8), 5.3f, 0);
            Instantiate(enemyPref, spawnPos, enemyPref.transform.rotation);
            yield return new WaitForSeconds(time);
        }
        waveRunning = true;
    }
    IEnumerator waveObst(int waveCount, int time)
    {
        for (int i = 0; i < waveCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8, 8), 5.5f, 0);
            Instantiate(Obstacle, spawnPos, Obstacle.transform.rotation);
            yield return new WaitForSeconds(time);
        }
        waveRunning = true;
    }
}
