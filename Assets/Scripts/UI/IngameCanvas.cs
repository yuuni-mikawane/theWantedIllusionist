using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private AudioSource music;
    private AudioManager audioManager;
    private GameManager gameManager;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.Instance;
        gameManager = GameManager.Instance;
        musicSlider.value = music.volume;
        SFXSlider.value = audioManager.CurrentSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                if (settings.activeSelf)
                {
                    TurnOffSettings();
                }
                else
                {
                    Resume();
                }
            }
            else
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                gameManager.gameState = GameState.Pause;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        gameManager.gameState = GameState.Playing;
        Time.timeScale = 1f;
    }

    public void TurnOffSettings()
    {
        settings.SetActive(false);
    }

    public void TurnOnSettings()
    {
        settings.SetActive(true);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsyncScene());
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        gameManager.StartRunTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnSFXSliderChange(float volume)
    {
        audioManager.UpdateSFXVolume(volume);
    }

    public void OnMusicSliderChange(float volume)
    {
        music.volume = volume;
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
