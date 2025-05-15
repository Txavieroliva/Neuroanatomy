using UnityEngine;

public class CirculoEnCubo : MonoBehaviour
{
    public GameObject circuloPrefab;
    private GameObject circuloActual;

    void Start()
    {
        ColocarCirculoEnCaraAleatoria();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter
        {
            if (circuloActual != null)
            {
                Destroy(circuloActual);
            }

            ColocarCirculoEnCaraAleatoria();
        }
    }

    void ColocarCirculoEnCaraAleatoria()
    {
        // Caras del cubo (normales y posiciones)
        Vector3[] normales = {
            Vector3.up, Vector3.down,
            Vector3.left, Vector3.right,
            Vector3.forward, Vector3.back
        };

        Vector3[] centros = {
            Vector3.up * 0.5f, Vector3.down * 0.5f,
            Vector3.left * 0.5f, Vector3.right * 0.5f,
            Vector3.forward * 0.5f, Vector3.back * 0.5f
        };

        int cara = Random.Range(0, 6);
        Vector3 normal = normales[cara];
        Vector3 centroCara = centros[cara];

        float desplazamiento = 0.45f;

        Vector2 rand2D = new Vector2(Random.Range(-desplazamiento, desplazamiento), Random.Range(-desplazamiento, desplazamiento));

        Vector3 localOffset = Vector3.zero;

        if (normal == Vector3.up || normal == Vector3.down)
            localOffset = new Vector3(rand2D.x, 0, rand2D.y);
        else if (normal == Vector3.left || normal == Vector3.right)
            localOffset = new Vector3(0, rand2D.x, rand2D.y);
        else if (normal == Vector3.forward || normal == Vector3.back)
            localOffset = new Vector3(rand2D.x, rand2D.y, 0);

        Vector3 posicionFinal = transform.position + centroCara + localOffset;

        circuloActual = Instantiate(circuloPrefab, posicionFinal, Quaternion.LookRotation(normal));
        circuloActual.transform.parent = transform;
    }
}
