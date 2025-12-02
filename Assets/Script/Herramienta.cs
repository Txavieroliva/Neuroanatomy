using UnityEngine;

public class HerramientaDiagnostico : MonoBehaviour
{
    public bool puedeDiagnosticar = true;         
    public Renderer rend;                         
   
    private void Start()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!puedeDiagnosticar)
            return;  

        Lobulos lobulo = other.GetComponent<Lobulos>();

        if (lobulo != null)
        {
            
            if (lobulo.puntoVerdadero != null && lobulo.puntoFalso == null)
            {
               
                CambiarColor(Color.green);
            }
            else if (lobulo.puntoVerdadero == null && lobulo.puntoFalso != null)
            {
                
                CambiarColor(Color.yellow);
            }
            else if (lobulo.puntoVerdadero == null && lobulo.puntoFalso == null)
            {
                
                CambiarColor(Color.red);
            }

           
            puedeDiagnosticar = false;  
        }
    }

    void CambiarColor(Color c)
    {
        if (rend != null)
            rend.material.color = c;
    }

 
    public void ReactivarHerramienta()
    {
        puedeDiagnosticar = true;
    }
}
