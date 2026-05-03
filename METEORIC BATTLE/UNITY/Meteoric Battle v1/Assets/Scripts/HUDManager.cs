using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Player 1")]
    public Image player1Image;
    public TMP_Text player1Text;

    [Header("Player 2")]
    public Image player2Image;
    public TMP_Text player2Text;

    [Header("Character Icons (orden = selección)")]
    public Sprite[] characterIcons;

    public void SetupHUD()
    {
        player1Text.text = "J1 - " + characterIcons[CharacterSelectTurnManager.player1Character].name;
        player2Text.text = "J2 -" + characterIcons[CharacterSelectTurnManager.player2Character].name;

        player1Image.sprite =
            characterIcons[CharacterSelectTurnManager.player1Character];

        player2Image.sprite =
            characterIcons[CharacterSelectTurnManager.player2Character];
    }
}
