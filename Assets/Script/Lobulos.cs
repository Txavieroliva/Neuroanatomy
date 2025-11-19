using UnityEngine;

public class Lobulos : MonoBehaviour
{
    [Header("Punto donde aparece el circulo")]
    public Transform anchor;

    [Header("Prefab del circulo rojo")]
    public GameObject circuloPrefab;

    private GameObject circuloActual;

    public void CrearCirculo()
    {
        if (circuloActual != null)
            Destroy(circuloActual);

        
        circuloActual = Instantiate(
            circuloPrefab, 
            anchor.position, 
            anchor.rotation, 
            this.transform 
        );
    }

    public void EliminarCirculo()
    {
        if (circuloActual != null)
            Destroy(circuloActual);
    }
    
}