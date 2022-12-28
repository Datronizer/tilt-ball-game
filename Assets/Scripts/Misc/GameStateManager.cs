using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool PauseState { get; private set; }
    private CanvasGroup pauseMenu;

    private void Awake()
    {
        pauseMenu = GetComponent<CanvasGroup>();

        // Just in case it acts up
        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
        pauseMenu.interactable = false;
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;

        pauseMenu.alpha = 1;
        pauseMenu.blocksRaycasts = true;
        pauseMenu.interactable = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
        pauseMenu.interactable = false;
    }

    public void OnPauseButtonClicked()
    {
        PauseGame();
    }

    public void OnResumeButtonClicked()
    {
        ResumeGame();
    }
}
