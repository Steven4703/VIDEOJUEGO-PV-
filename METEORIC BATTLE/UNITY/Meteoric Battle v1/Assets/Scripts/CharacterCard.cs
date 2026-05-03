using UnityEngine;

public class CharacterCard : MonoBehaviour
{
    public int characterIndex;
    private CharacterSelectTurnManager manager;

    void Start()
    {
        manager = FindObjectOfType<CharacterSelectTurnManager>();
    }

    public void OnClick()
    {
        manager.SelectCharacter(characterIndex);
    }
}

