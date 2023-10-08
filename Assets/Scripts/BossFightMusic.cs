using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightMusic : MonoBehaviour
{
    private AudioSource audioSource; // Yeni m�zi�i temsil eden ses kayna��

    private void Start()
    {
        // AudioSource bile�enini al
        audioSource = GetComponent<AudioSource>();

        // BossFight sahnesine ge�ti�inizde yeni m�zi�i ba�lat�n
        if (SceneManager.GetActiveScene().name == "BossFight")
        {
            audioSource.Play();
        }
    }

    // BossFight sahnesinde �almak istedi�iniz m�zi�i ba�latmak i�in bir y�ntem ekleyebilirsiniz.
    public void StartBossFightMusic()
    {
        audioSource.Play();
    }

    // BossFight sahnesinde m�zi�i duraklatmak veya durdurmak i�in y�ntemler ekleyebilirsiniz.
    public void PauseBossFightMusic()
    {
        audioSource.Pause();
    }

    public void StopBossFightMusic()
    {
        audioSource.Stop();
    }
}
