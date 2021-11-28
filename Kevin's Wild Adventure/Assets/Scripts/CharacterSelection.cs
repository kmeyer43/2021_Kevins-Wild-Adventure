using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    // References to the controlled characters
    public GameObject character1, character2;

    // The variable that constains which character is currently selected
    public int selectedCharacter = 1;

    // Use this for initialization
    void Start()
    {
        // Set the selected character to the first character
        character1.gameObject.SetActive(true);
        character2.gameObject.SetActive(false);
    }

    // The public method to switch characters with a button press
    public void SwitchCharacter() {

        // Processing whichCharacterIsOn variable
        switch (whichCharacterIsOn())
        {
            case 1:
                // If the first character is on, switch to the second character
                character1.gameObject.SetActive(false);
                character2.gameObject.SetActive(true);
                break;
            case 2:
                // If the second character is on, switch to the first character
                character1.gameObject.SetActive(true);
                character2.gameObject.SetActive(false);
                break;
        }
    }
}
