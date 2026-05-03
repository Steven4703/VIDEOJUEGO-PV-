
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //VFX Last 30s
    [Header("30 Seconds Effects")]
    public GameObject effects30Seconds;
    private bool effects30Activated = false;

    //Time
    [Header("Timer")]
    public float matchTime = 60f;
    public TMPro.TMP_Text timerText;
    private bool matchEnded = false;

    //Gameplay
    [Header("Gameplay")]
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    //Players
    [Header("Players")]
    public GameObject[] playerPrefabs; 
    public Transform[] spawnPoints; 
    public GameObject[] players;
    private int playersAlive;

    //Victory
    [Header("UI Victoria")]
    public GameObject winPanel;
    public TMP_Text winText;

    public HUDManager hudManager;

    void Start()
    {
        Time.timeScale = 1f;

        //Players

        players = new GameObject[2];

        players[0] = Instantiate(
            playerPrefabs[CharacterSelectTurnManager.player1Character],
            spawnPoints[0].position,
            Quaternion.identity
        );

        players[1] = Instantiate(
            playerPrefabs[CharacterSelectTurnManager.player2Character],
            spawnPoints[1].position,
            Quaternion.identity
        );

        if (hudManager != null)
        {
            hudManager.SetupHUD();
        }

        //Controls

        AssignControls();

        playersAlive = players.Length;

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {

    //Timer
        
    if (matchEnded) return;

        matchTime -= Time.deltaTime;
        matchTime = Mathf.Max(matchTime, 0f);

        UpdateTimerUI();

        if (matchTime <= 0f)
        {
            CheckDraw();
        }

    //VFX Last 30s
        
    if (!effects30Activated && matchTime <= 30f)
        {
            Activate30SecondsEffects();
        }

        if (matchTime <= 0f)
        {
            CheckDraw();
        }


        //Pause Buttom

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    //Control assignment

    void AssignControls()
    {
        players[0].GetComponent<PlayerMovement>().horizontalAxis = "Horizontal_P1";
        players[0].GetComponent<PlayerMovement>().verticalAxis = "Vertical_P1";

        players[1].GetComponent<PlayerMovement>().horizontalAxis = "Horizontal_P2";
        players[1].GetComponent<PlayerMovement>().verticalAxis = "Vertical_P2";
    }

    //Buttom Methods

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

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    //Victory Conditions

    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        playersAlive--;

        if (playersAlive == 1)
            DeclareWinner();
    }

    void DeclareWinner()
    {   
    if (players[0].activeSelf)
    {
        string characterName =
            playerPrefabs[CharacterSelectTurnManager.player1Character].name;

        ShowWinner("Jugador 1 - " + characterName);
    }
    else if (players[1].activeSelf)
    {
        string characterName =
            playerPrefabs[CharacterSelectTurnManager.player2Character].name;

        ShowWinner("Jugador 2 - " + characterName);
    }

    }

    void ShowWinner(string winnerName)
    {
        Time.timeScale = 0f;

        if (winPanel != null)
            winPanel.SetActive(true);

        if (winText != null)
            winText.text = "Winner: " + winnerName;
    }

    //Time Controller
    
    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(matchTime / 60f);
        int seconds = Mathf.FloorToInt(matchTime % 60f);

        if (timerText != null)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
    void CheckDraw()
    {
        matchEnded = true;
        Time.timeScale = 0f;

        if (winPanel != null)
            winPanel.SetActive(true);

        if (winText != null)
            winText.text = "EMPATE";
    }

    //VFX Activate

    void Activate30SecondsEffects()
    {
        effects30Activated = true;

        if (effects30Seconds != null)
            effects30Seconds.SetActive(true);
    }


}
