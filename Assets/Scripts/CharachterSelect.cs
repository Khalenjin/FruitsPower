using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharachterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        SetActiveCharacter(selectedCharacter);
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        SetActiveCharacter(selectedCharacter);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        SetActiveCharacter(selectedCharacter);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        SceneManager.LoadScene("Level 1");
    }

    // Seçilen karakteri etkinleþtirmek için bu fonksiyonu kullanýn
    private void SetActiveCharacter(int characterIndex)
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(i == characterIndex);
        }
    }
}
