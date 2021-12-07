using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        // This commented out statement will reset player levels back to the start
        // meaning any levels the player unlocked are locked again
        // uncomment this whenever you would like to lock levels again.
        // Make sure to comment this back out after you open the levels scene.
        //PlayerPrefs.DeleteKey("levelAt");
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); /* < Change this int value to whatever your
                                                             level selection build index is on your
                                                             build settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

}
