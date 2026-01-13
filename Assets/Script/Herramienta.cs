using UnityEngine;

public class HerramientaDiagnostico : MonoBehaviour
{
    public bool puedeDiagnosticar = true;
    public Renderer rend;
    

    public Lobulos lobuloDetectado;      

    private void Start()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!puedeDiagnosticar) return;

        Lobulos lobulo = other.GetComponent<Lobulos>();

        if (lobulo != null)
        {
            lobuloDetectado = lobulo; 
            EjecutarDiagnostico();   
        }
    }


   

    public void EjecutarDiagnostico()
    {
        if (!puedeDiagnosticar || lobuloDetectado == null) return;

      
        if (lobuloDetectado.puntoVerdadero != null && lobuloDetectado.puntoFalso == null)
        {
            CambiarColor(Color.green);
        }
        else if (lobuloDetectado.puntoVerdadero == null && lobuloDetectado.puntoFalso != null)
        {
            CambiarColor(Color.yellow);
        }
        else if (lobuloDetectado.puntoVerdadero == null && lobuloDetectado.puntoFalso == null)
        {
            CambiarColor(Color.red);
        }

        
        puedeDiagnosticar = false;

       
    }


  

    void CambiarColor(Color c)
    {
        if (rend != null)
            rend.material.color = c;
    }

    

    public void ReactivarHerramienta()
    {
        puedeDiagnosticar = true;
        lobuloDetectado = null;
        CambiarColor(Color.white); 
    }
}
