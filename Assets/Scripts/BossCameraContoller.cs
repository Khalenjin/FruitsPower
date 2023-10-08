using UnityEngine;

public class BossCameraController : MonoBehaviour
{
    public Transform target; // Kameran�n takip edece�i hedef (karakter)
    public float smoothSpeed = 0.125f; // Kamera takip h�z�
    private Vector3 initialOffset; // Ba�lang�� pozisyonu ile hedef aras�ndaki mesafe
    public float initialYOffset = 0.3f; // Y�kseklik ofseti
    public float initialXOffset = 0.3f; 
    private void Start()
    {
        initialOffset = new Vector3(initialXOffset, initialYOffset, -10f); // Y�kseklik ofsetini ekleyin
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
