using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // So I Can witch scenes
using UnityEngine.UI; // So I can use UI

public class OMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject backMenuHolder;

    // Access GameObjects in Menu Manager
    // public Slider[] volumeSliders; No sound in game
    public Toggle[] resolutionToggles;
    // public Toggle fullscreenToggle; no fullscreen option
    public int[] screenWidths;
    int activeScreenRexIndex;

    void Start()
    {
        activeScreenRexIndex = PlayerPrefs.GetInt("screen res index");
        // bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1)?true:false;
    }

    public void Play()
    {
        // Start Game, load spaceship map
        SceneManager.LoadScene("SampleScene"); //title of game
    }

    public void Quit()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("Player Quit Game");   
    }

    public void OptionsMenu()
    {
        // Hide Main Menu and reveal Options Menu
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        backMenuHolder.SetActive(true); // Does appear in Options Menu
    }

    public void MainMenu()
    {
        // Hide Options Menu and reveal Main Menu
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void Back()
    {
        backMenuHolder.SetActive(true);
    }


    public void SetScreenResolution(int i)
    {
        // If it's fullscreen or not
        if (resolutionToggles[i].isOn)
        {
            activeScreenRexIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution (screenWidths [i], (int) (screenWidths [i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenRexIndex); // Player settings os menu remembers
        }
    }

    /* NOT ADDING public void SetFullscreen(bool isFullscreen)
    {
        // If it's fullscreen
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles [i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions [allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true); // true because full screen
        } else
        {
            SetScreenResolution (activeScreenRexIndex); // Call function
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0)); // 1 = fullscreen 0 = not fullscreen
        PlayerPrefs.Save ();
    }
    

    public void SetMusicVolume(float value)
    {
        // (I don't have an audio manager yet) AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
     */
}
