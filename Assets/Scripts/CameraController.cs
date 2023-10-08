using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] players; // Birden fazla karakter prefab�n� eklemek i�in dizi kullan�l�yor.

    private int selectedCharacterIndex = 0; // Ba�lang��ta se�ilen karakterin indeksini 0 olarak varsayal�m.

    private void Start()
    {
        // PlayerPrefs'ten se�ilen karakterin indeksini al�n
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Se�ilen karakterin indeksine g�re karakteri etkinle�tirin
        SetActiveCharacter(selectedCharacterIndex);
    }

    private void Update()
    {
        // Kameran�n pozisyonunu se�ilen karakterin pozisyonuna g�ncelleyin
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < players.Length)
        {
            transform.position = new Vector3(players[selectedCharacterIndex].position.x, players[selectedCharacterIndex].position.y, transform.position.z);
        }
    }

    // Se�ilen karakteri etkinle�tirmek i�in bu fonksiyonu kullan�n
    private void SetActiveCharacter(int characterIndex)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(i == characterIndex);
        }
    }
}
