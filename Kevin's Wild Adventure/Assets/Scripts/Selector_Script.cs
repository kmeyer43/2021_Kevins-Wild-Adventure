using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_Script : MonoBehaviour
{

    public GameObject Kevin;
    public GameObject Kyle;
    private int CharacterInt = 1;
    private SpriteRenderer KevinRender, KyleRender;
    private readonly string selectedCharacter = "SelectedCharacter";

    private Vector2 CharacterPostion;
    private Vector2 OffScreen;

    private void Awake()
    {
        CharacterPostion = Kevin.transform.position;
        OffScreen = Kyle.transform.position;
        KevinRender = Kevin.GetComponent<SpriteRenderer>();
        KyleRender = Kyle.GetComponent<SpriteRenderer>();
    }

    // Right Arrow = Next Character
    public void RightArrow()
    {
        switch(CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                KevinRender.enabled = false;
                Kevin.transform.position = OffScreen;
                Kyle.transform.position = CharacterPostion;
                KyleRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                KyleRender.enabled = false;
                Kyle.transform.position = OffScreen;
                Kevin.transform.position = CharacterPostion;
                KevinRender.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    // Left Arrow = Previous Character
    public void LeftArrow()
    {
        switch(CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                KevinRender.enabled = false;
                Kevin.transform.position = OffScreen;
                Kyle.transform.position = CharacterPostion;
                KyleRender.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                KyleRender.enabled = false;
                Kyle.transform.position = OffScreen;
                Kevin.transform.position = CharacterPostion;
                KevinRender.enabled = true;
                CharacterInt++;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if (CharacterInt > 2)
        {
            CharacterInt = 1;
        } else {
            CharacterInt = 2;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level 1");
    }

}
