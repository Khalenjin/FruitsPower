using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Deneme : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Start()
    {
        // Se�ilen karakterin indeksini PlayerPrefs'ten al�n
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Do�ru karakteri etkinle�tirin
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterPrefabs[i].SetActive(i == selectedCharacter);
        }
    }
}
