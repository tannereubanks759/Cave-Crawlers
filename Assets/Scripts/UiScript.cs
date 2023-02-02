using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiScript : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    private Scene scene;
    private bool isPaused;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Level")
        {
            DeathMenu.SetActive(false);
            PauseMenu.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){
            if (isPaused)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        player.GetComponent<CharacterControllerScript>().SetDead(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public bool GetPaused()
    {
        return isPaused;
    }
}
