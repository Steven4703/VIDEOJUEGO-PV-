using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*Variables for the pause menu*/
    public GameObject pauseMenuUI;
    public bool isPaused = false;
    /*public GameObject hudCanvas;*/

    void Update()
    {
        /*Pause button*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    /*Function to continue the game*/
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        /*hudCanvas.SetActive(true); // Mostrar HUD*/

        // Hide and lock the cursor
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    /*Function to pause the game*/
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        /*hudCanvas.SetActive(false); // Hide HUD*/

        // Show and unlock cursor
        /*Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;*/
    }

    /*Function to restart the game*/
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*Function to start the game*/
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    /*Function to exit the game*/
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    /*Function to activate gameover canvas*/
    /*public void HideHUDOnGameOver()
    {
        hudCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }*/

    /*Function to go to the home screen*/
    public void MenuP()
    {
        SceneManager.LoadScene("Menu");
    }
}
