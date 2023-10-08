using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public bool isFlipped = false;

    private bool hasWaited = false;

    private void Start()
    {
        // Ba�lang��ta 8 saniye beklemek i�in Invoke fonksiyonunu kullanabilirsiniz.
        Invoke("StartMoving", 8f);
    }

    private void Update()
    {
        // Bekleme tamamland�ktan sonra hareket etmeye ba�la.
        if (hasWaited)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void StartMoving()
    {
        hasWaited = true;
        LookAtPlayer(); // E�er hareket ba�lad���nda oyuncuya bakmak isterseniz.
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
