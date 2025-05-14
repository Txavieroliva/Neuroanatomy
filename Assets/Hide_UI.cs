using UnityEngine;

public class Hide_UI : MonoBehaviour
{
    public Transform xrCamera; // Cámara del XR Rig
    public float distanceBehind = 2f;
    public float distanceInFront = 2f;
    public float height = 1.5f;
    public KeyCode toggleKey = KeyCode.H; // Tecla para cambiar la posición de la UI

    private bool isBehind = true; // Estado inicial: detrás del jugador

    void Start()
    {
        UpdatePosition(); // Posicionar al inicio
    }

    void Update()
    {
        // Cambiar posición con la tecla
        if (Input.GetKeyDown(toggleKey))
        {
            isBehind = !isBehind;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        Vector3 direction = isBehind ? -xrCamera.forward : xrCamera.forward;
        float distance = isBehind ? distanceBehind : distanceInFront;

        Vector3 position = xrCamera.position + direction * distance;
        position.y = xrCamera.position.y + height;

        transform.position = position;
        transform.LookAt(xrCamera);
        transform.Rotate(0, 180f, 0); // Para que mire correctamente hacia afuera
    }
}