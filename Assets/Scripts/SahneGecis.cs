using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    public void SonrakiSahneyeGec()
    {
        SceneManager.LoadScene("BossFight"); // Belirlediğiniz sahneye geçiş yapar.
    }
}
