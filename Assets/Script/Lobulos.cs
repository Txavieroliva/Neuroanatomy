using UnityEngine;

public class Lobulos : MonoBehaviour
{
    [Header("Punto donde aparece el circulo")]
    public Transform anchor;

    [Header("Prefab del circulo rojo")]
    public GameObject circuloPrefab;

    public GameObject puntoVerdadero;
    public GameObject puntoFalso;

    public void CrearCirculo()
    {
        if (puntoVerdadero != null)
            Destroy(puntoVerdadero);

        
            puntoVerdadero = Instantiate(
            circuloPrefab, 
            anchor.position, 
            anchor.rotation, 
            this.transform 
        );
    }

    public void CrearCirculoFalso()
    {
        if (puntoFalso != null)
            Destroy(puntoFalso);

        
            puntoFalso = Instantiate(
            circuloPrefab, 
            anchor.position, 
            anchor.rotation, 
            this.transform 
        );
    }


    public void EliminarCirculo()
    {
        if (puntoVerdadero != null)
            Destroy(puntoVerdadero);
    }
    
}