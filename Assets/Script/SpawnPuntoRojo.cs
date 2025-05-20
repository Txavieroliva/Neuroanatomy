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
            ColocarCirculoEnSuperficie();
        }
    }

    void ColocarCirculoEnSuperficie()
    {
        const int intentosMaximos = 50;
        for (int i = 0; i < intentosMaximos; i++)
        {
            Vector3 puntoAleatorio = cerebroCollider.bounds.center + new Vector3(
                Random.Range(-cerebroCollider.bounds.extents.x, cerebroCollider.bounds.extents.x),
                Random.Range(-cerebroCollider.bounds.extents.y, cerebroCollider.bounds.extents.y),
                Random.Range(-cerebroCollider.bounds.extents.z, cerebroCollider.bounds.extents.z)
            );

            Vector3 direccion = (cerebroCollider.bounds.center - puntoAleatorio).normalized;

            if (Physics.Raycast(puntoAleatorio, direccion, out RaycastHit hit, 2f * cerebroCollider.bounds.extents.magnitude))
            {
                if (hit.collider == cerebroCollider)
                {
                    Vector3 posicionFinal = hit.point;
                    Quaternion rotacionFinal = Quaternion.LookRotation(hit.normal);

                    if (circuloActual == null)
                    {
                        circuloActual = Instantiate(circuloPrefab, posicionFinal, rotacionFinal);
                        circuloActual.transform.parent = transform;
                        circuloActual.transform.localScale = new Vector3((float)0.1, (float)0.1, (float)0.1);
                    }
                    else
                    {
                        circuloActual.transform.position = posicionFinal;
                        circuloActual.transform.rotation = rotacionFinal;
                    }

                    return;
                }
            }
        }

        Debug.LogWarning("No se pudo colocar el c�rculo en la superficie del cerebro.");
    }
}