using UnityEngine;

public class BossCameraController : MonoBehaviour
{
    public Transform target; // Kameranýn takip edeceði hedef (karakter)
    public float smoothSpeed = 0.125f; // Kamera takip hýzý
    private Vector3 initialOffset; // Baþlangýç pozisyonu ile hedef arasýndaki mesafe
    public float initialYOffset = 0.3f; // Yükseklik ofseti
    public float initialXOffset = 0.3f; 
    private void Start()
    {
        initialOffset = new Vector3(initialXOffset, initialYOffset, -10f); // Yükseklik ofsetini ekleyin
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + initialOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
