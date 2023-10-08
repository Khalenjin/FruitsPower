using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Deneme : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Start()
    {
        // Seçilen karakterin indeksini PlayerPrefs'ten alýn
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Doðru karakteri etkinleþtirin
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterPrefabs[i].SetActive(i == selectedCharacter);
        }
    }
}
