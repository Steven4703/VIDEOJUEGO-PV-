
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectTurnManager : MonoBehaviour
{
    public static int player1Character = -1;
    public static int player2Character = -1;

    public Image[] characterFrames;
    public TMP_Text turnText;
    public Button confirmButton;

    public Color normalColor;
    public Color selectedColor;
    public Color lockedColor;

    private int currentSelection = -1;
    private bool selectingPlayer1 = true;

    void Start()
    {
        turnText.text = "JUGADOR 1 - ELIGE TU PERSONAJE";
        confirmButton.interactable = false;
        ResetFrames();
    }

    public void SelectCharacter(int index)
    {
        currentSelection = index;
        ResetFrames();
        characterFrames[index].color = selectedColor;
        confirmButton.interactable = true;
    }

    public void ConfirmSelection()
    {
        if (currentSelection == -1) return;

        if (selectingPlayer1)
        {
            player1Character = currentSelection;
            selectingPlayer1 = false;

            turnText.text = "JUGADOR 2 - ELIGE TU PERSONAJE";
            confirmButton.interactable = false;
            characterFrames[currentSelection].color = lockedColor;
            currentSelection = -1;
        }
        else
        {
            player2Character = currentSelection;
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    void ResetFrames()
    {
        for (int i = 0; i < characterFrames.Length; i++)
        {
            characterFrames[i].color =
                (i == player1Character) ? lockedColor : normalColor;
        }
    }
}
