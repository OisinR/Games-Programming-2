using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public Slider music;
    public Slider effects;
    public Slider monsters;
    public Button back;
    public GameObject cover;
    bool menu;

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
            cover.SetActive(true);
        }
        else
        {
            cover.SetActive(false);
        }
    }


    public void ExitMenu()
    {

        PlayerPrefs.SetFloat("MusicVolume", music.value);
        PlayerPrefs.SetFloat("EffectsVolume", effects.value);
        PlayerPrefs.SetFloat("MonsterVolume", monsters.value);
        menu = false;
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
