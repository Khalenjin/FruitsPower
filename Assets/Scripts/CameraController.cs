using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] players; // Birden fazla karakter prefabýný eklemek için dizi kullanýlýyor.

    private int selectedCharacterIndex = 0; // Baþlangýçta seçilen karakterin indeksini 0 olarak varsayalým.

    private void Start()
    {
        // PlayerPrefs'ten seçilen karakterin indeksini alýn
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Seçilen karakterin indeksine göre karakteri etkinleþtirin
        SetActiveCharacter(selectedCharacterIndex);
    }

    private void Update()
    {
        // Kameranýn pozisyonunu seçilen karakterin pozisyonuna güncelleyin
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < players.Length)
        {
            transform.position = new Vector3(players[selectedCharacterIndex].position.x, players[selectedCharacterIndex].position.y, transform.position.z);
        }
    }

    // Seçilen karakteri etkinleþtirmek için bu fonksiyonu kullanýn
    private void SetActiveCharacter(int characterIndex)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(i == characterIndex);
        }
    }
}
