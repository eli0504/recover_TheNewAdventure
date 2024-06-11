using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private bool isPaused;

    //panels
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject rememberPanel;
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject musicPanel;

    //buttons
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button controlButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
      
        QuitControlPanel();
        QuitMusicPanel();
    }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        //Pause logic with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //PAUSE
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Instance.ShowPausePanel();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        QuitPausePanel();
        isPaused = false;
    }

    public void ShowPausePanel()
    {
        rememberPanel.SetActive(false);
        pausePanel.SetActive(true);

    }
    public void QuitPausePanel()
    {
        pausePanel.SetActive(false);
    }
    //setings
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        rememberPanel.SetActive(false);
    }
    public void QuitSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    //credits
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        rememberPanel.SetActive(false);
    }
    public void QuitCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    //control button

    public void ShowControlPanel()
    {

        controlPanel.SetActive(true);

    }
    public void QuitControlPanel()
    {
        controlPanel.SetActive(false);
    }

    //music button

    public void ShowMusicPanel()
    {

        musicPanel.SetActive(true);

    }
    public void QuitMusicPanel()
    {
        musicPanel.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Health.lives = 3;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
