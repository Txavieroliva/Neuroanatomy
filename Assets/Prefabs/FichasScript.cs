using UnityEngine;

public class FichasScript : MonoBehaviour
{
  
    
    public GameObject circuloActual;
    public int lobulo;
    public GameObject lobuloActual;

   

    void Start()
    {
        Inicio();
    }
    
    public void DestroyItem()
    {
        Destroy(this);
        var script = lobuloActual.GetComponent<Lobulos>();
        script.EliminarCirculo();
    }
    
    void Inicio()
    {
        switch (lobulo)
        {
            case 1:
            {
                lobuloActual = GameObject.Find("Lobulo 1");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 2:
            {
                lobuloActual = GameObject.Find("Lobulo 2");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 3:
            {
                lobuloActual = GameObject.Find("Lobulo 3");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 4:
            {
                lobuloActual = GameObject.Find("Lobulo 4");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 5:
            {
                lobuloActual = GameObject.Find("Lobulo 5");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 6:
            {
                lobuloActual = GameObject.Find("Lobulo 6");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 7:
            {
                lobuloActual = GameObject.Find("Lobulo 7");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 8:
            {
                lobuloActual = GameObject.Find("Lobulo 8");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            default:
            break;
            
        }
    }

}
