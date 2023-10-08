using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public HealthBar healthBar; // HealthBar referans�n� ekleyin
    public GameObject deathEffect;

    void Start()
    {
        healthBar.SetMaxHealth(health); // Ba�lang��ta maksimum sa�l��� ayarlay�n
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health); // Sa�l�k �ubu�unu g�ncelleyin

        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
