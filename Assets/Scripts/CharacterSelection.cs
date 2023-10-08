using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private string selectedCharacter = ""; // Seçilen karakterin adýný saklamak için bir deðiþken

    public Text characterNameText; // UI üzerinde karakterin adýný göstermek için bir Text bileþeni

    public void SelectCharacter(string characterName)
    {
        selectedCharacter = characterName;
        characterNameText.text = "Selected Character: " + selectedCharacter;
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            // Seçilen karakteri bir oyuncu tercihi olarak saklayabilir veya baþka bir yerde kullanabilirsiniz.
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacter);

            // Oyunu baþlatmak için bir sonraki sahneye geçebilirsiniz.
            SceneManager.LoadScene("Level 1 Deneme");
        }
        else
        {
            // Kullanýcý bir karakter seçmediyse bir uyarý gösterebilirsiniz.
        }
    }
}
