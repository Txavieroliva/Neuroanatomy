using System.Runtime.ExceptionServices;
using UnityEngine;

public class SpawnButton : MonoBehaviour


{
    [Header("Prefabs a instanciar (m�x. 8)")]
    public GameObject[] prefabs;

    [Header("Punto donde aparecer�n los objetos")]
    public Transform spawnPoint;
    public GameObject ficha;

    public bool activated = false;
    public CirculoEnCerebro cerebro;

    void Awake()
    {
        cerebro = FindAnyObjectByType<CirculoEnCerebro>();
        cerebro = GetComponent<CirculoEnCerebro>();
    }



    private void OnMouseDown()
    {

        if (ficha != null)
        {
            Destroy(ficha);
            ficha = null;
            return;
        }


        /*if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogWarning("No hay prefabs asignados en el bot�n.");
            return;
        }*/

    
        
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[randomIndex];


        ficha = Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"Instanciado: {selectedPrefab.name}");
        cerebro.ColocarCirculoEnSuperficie();   

            
        

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = Color.gray;
    }
}

