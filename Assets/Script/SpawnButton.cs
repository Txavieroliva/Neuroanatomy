using System.Runtime.ExceptionServices;
using UnityEngine;

public class SpawnButton : MonoBehaviour


{
    [Header("Prefabs a instanciar (max. 8)")]
    public GameObject[] prefabs;

    [Header("Punto donde aparecen los objetos")]
    public Transform spawnPoint;
    public GameObject ficha;

    public bool activated = false;
   

    void Awake()
    {
    
    }



    private void OnMouseDown()
    {

        if (ficha != null)
        {
            Destroy(ficha);
            ficha = null;
            return;
        }


        
    
        
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[randomIndex];


        ficha = Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"Instanciado: {selectedPrefab.name}");
           

            
        

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = Color.gray;
    }
}

