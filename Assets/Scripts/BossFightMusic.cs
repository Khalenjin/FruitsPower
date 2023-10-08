using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightMusic : MonoBehaviour
{
    private AudioSource audioSource; // Yeni müziði temsil eden ses kaynaðý

    private void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();

        // BossFight sahnesine geçtiðinizde yeni müziði baþlatýn
        if (SceneManager.GetActiveScene().name == "BossFight")
        {
            audioSource.Play();
        }
    }

    // BossFight sahnesinde çalmak istediðiniz müziði baþlatmak için bir yöntem ekleyebilirsiniz.
    public void StartBossFightMusic()
    {
        audioSource.Play();
    }

    // BossFight sahnesinde müziði duraklatmak veya durdurmak için yöntemler ekleyebilirsiniz.
    public void PauseBossFightMusic()
    {
        audioSource.Pause();
    }

    public void StopBossFightMusic()
    {
        audioSource.Stop();
    }
}
