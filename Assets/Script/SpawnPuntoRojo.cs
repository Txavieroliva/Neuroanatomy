using UnityEngine;

public class CirculoEnCerebro : MonoBehaviour
{
    public GameObject circuloPrefab;
    private GameObject circuloActual;

    private Collider cerebroCollider;

    void Start()
    {
        cerebroCollider = GetComponent<Collider>();

        if (cerebroCollider == null)
        {
            Debug.LogError("Este objeto (el cerebro) necesita un Collider.");
            return;
        }

        ColocarCirculoEnSuperficie();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Cualquier tecla
        {
            if (circuloActual != null)
            {
                Destroy(circuloActual);
            }

            ColocarCirculoEnSuperficie();
        }
    }

    void ColocarCirculoEnSuperficie()
    {
        const int intentosMaximos = 50;
        for (int i = 0; i < intentosMaximos; i++)
        {
            // Generar un punto aleatorio dentro de los bounds del cerebro
            Vector3 puntoAleatorio = cerebroCollider.bounds.center + new Vector3(
                Random.Range(-cerebroCollider.bounds.extents.x, cerebroCollider.bounds.extents.x),
                Random.Range(-cerebroCollider.bounds.extents.y, cerebroCollider.bounds.extents.y),
                Random.Range(-cerebroCollider.bounds.extents.z, cerebroCollider.bounds.extents.z)
            );

            // Lanza un rayo desde fuera del cerebro hacia adentro
            Vector3 direccion = (cerebroCollider.bounds.center - puntoAleatorio).normalized;

            if (Physics.Raycast(puntoAleatorio, direccion, out RaycastHit hit, 2f * cerebroCollider.bounds.extents.magnitude))
            {
                if (hit.collider == cerebroCollider)
                {
                    Vector3 posicionFinal = hit.point;
                    Quaternion rotacion = Quaternion.LookRotation(hit.normal);

                    circuloActual = Instantiate(circuloPrefab, posicionFinal, rotacion);
                    circuloActual.transform.parent = transform;
                    return;
                }
            }
        }

        Debug.LogWarning("No se pudo colocar el círculo en la superficie del cerebro.");
    }
}