using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    CameraLook cameraScript;
    public AudioSource speaker;
    public Slider music;
    public Slider effects;
    public Slider monsters;
    public Button back;
    public GameObject cover;
    bool menu;
    public bool dead;
    private void Start()
    {
        
    }

    public void EnterMenu()
    {
        menu = true;
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        effects.value = PlayerPrefs.GetFloat("EffectsVolume");
        monsters.value = PlayerPrefs.GetFloat("MonsterVolume");
    }

	void Update()
    {
        if (menu)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu") { Time.timeScale = 0; }
            cover.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            cover.SetActive(false);
            if(SceneManager.GetActiveScene().name != "MainMenu" && !dead)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (SceneManager.GetActiveScene().name != "MainMenu" && !menu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EnterMenu();
                cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraLook>();
                cameraScript.paused = true;
            }
        }

        speaker.volume = PlayerPrefs.GetFloat("MusicVolume");
    }


    public void ExitMenu()
    {

        PlayerPrefs.SetFloat("MusicVolume", music.value);
        PlayerPrefs.SetFloat("EffectsVolume", effects.value);
        PlayerPrefs.SetFloat("MonsterVolume", monsters.value);
        menu = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
          
            cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraLook>();
            cameraScript.paused = false;
            
        }
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
