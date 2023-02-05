using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPref;
    public bool waveRunning;
    public GameObject Obstacle;
    public GameObject Boss;

    public GameObject bossSpawn;
    public GameObject grass;

    public float currentTime;
    public float startTime;

    private bool bossSpawned;
    private GameObject[] bosses;

    private bool ended;

    public GameObject EndParticle;

    public float endTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        waveRunning = true;
        startTime = Time.time;
        bossSpawned = false;
        ended = false;
        endTime = 999;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if (currentTime < startTime + 20)
        {
            if(waveRunning == true)
            {
                StartCoroutine(wave(5, 4));
                waveRunning = false;
            }
            
        }
        if (currentTime < startTime + 30)
        {
            if (waveRunning == true)
            {
                StartCoroutine(wave(5, 2));
                waveRunning = false;
            }

        }
        if(currentTime < startTime + 50 && currentTime > 30 + startTime)
        {
            if(waveRunning == true)
            {
                StartCoroutine(waveObst(10, 2));
                waveRunning = false;
            }
        }

        if(bossSpawned == true)
        {
            bosses = GameObject.FindGameObjectsWithTag("enemy");
            if (bosses.Length <= 0 && ended != true)
            {
                EndGame();
                ended = true;
                bossSpawned = false;
            }
        }
        if (currentTime > endTime && ended == true)
        {
            Instantiate(EndParticle);
            ended = false;
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
        Instantiate(Boss, bossSpawn.transform.position, Boss.transform.rotation);
        bossSpawned = true;
    }
    void EndGame()
    {
        endTime = Time.time + 5;
        Instantiate(grass);
        Debug.Log("Ending Sequence Initiated");
        
    }
}
