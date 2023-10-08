using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private string selectedCharacter = ""; // Se�ilen karakterin ad�n� saklamak i�in bir de�i�ken

    public Text characterNameText; // UI �zerinde karakterin ad�n� g�stermek i�in bir Text bile�eni

    public void SelectCharacter(string characterName)
    {
        selectedCharacter = characterName;
        characterNameText.text = "Selected Character: " + selectedCharacter;
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            // Se�ilen karakteri bir oyuncu tercihi olarak saklayabilir veya ba�ka bir yerde kullanabilirsiniz.
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacter);

            // Oyunu ba�latmak i�in bir sonraki sahneye ge�ebilirsiniz.
            SceneManager.LoadScene("Level 1 Deneme");
        }
        else
        {
            // Kullan�c� bir karakter se�mediyse bir uyar� g�sterebilirsiniz.
        }
    }
}
