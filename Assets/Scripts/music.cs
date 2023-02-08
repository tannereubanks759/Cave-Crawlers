using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class music : MonoBehaviour
{
    public AudioSource source;
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level")
        {
            DontDestroyOnLoad(this.gameObject);
        }
        if(scene.name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }
    public void SetMusic(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
