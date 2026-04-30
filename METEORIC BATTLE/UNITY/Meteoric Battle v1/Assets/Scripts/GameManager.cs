using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    public GameObject[] players;
    private int playersAlive;

    // UI de victoria
    public GameObject winPanel;
    public Text winText;

    void Start()
    {
        playersAlive = players.Length;

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        playersAlive--;

        if (playersAlive == 1)
        {
            DeclareWinner();
        }
    }

    void DeclareWinner()
    {
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                string winnerName = player.name;
                Debug.Log("Winner: " + winnerName);

                ShowWinner(winnerName);
            }
        }
    }

    void ShowWinner(string winnerName)
    {
        Time.timeScale = 0f;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        if (winText != null)
        {
            winText.text = "Winner: " + winnerName;
        }
    }
}