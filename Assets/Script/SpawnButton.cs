using System.Runtime.ExceptionServices;
using UnityEngine;
using Oculus.Interaction.Surfaces;
using System.Runtime.CompilerServices;
using System.Collections;

public class SpawnButton : MonoBehaviour


{
    [Header("Prefabs a instanciar (max. 8)")]
    public GameObject[] prefabs;

    [Header("Punto donde aparecen los objetos")]
    public Transform spawnPoint;
    public GameObject ficha;

    public bool activated = false;

    public Collider collider;

    public float tiempoBloqueo = 10f;


    void Awake()
    {
    
    }


   


    private void OnTriggerEnter(Collider other)
    {

        if(!activated)
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



    

        StartCoroutine(ActivarCollider());

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = Color.gray;


        }
        

    }
    
    IEnumerator ActivarCollider()
    {
        collider.enabled = false;
        activated = true;
        
        yield return new WaitForSeconds(tiempoBloqueo);
        collider.enabled = true;
        activated = false;
    }
}

