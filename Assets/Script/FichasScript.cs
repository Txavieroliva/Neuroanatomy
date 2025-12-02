using UnityEngine;

public class FichasScript : MonoBehaviour
{
  
    
    
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
                lobuloActual = GameObject.Find("Frontal Lobe R");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 2:
            {
                lobuloActual = GameObject.Find("Parietal Lobe R");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 3:
            {
                lobuloActual = GameObject.Find("Occipital Lobe R");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 4:
            {
                lobuloActual = GameObject.Find("Temporal Lobe R");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 5:
            {
                lobuloActual = GameObject.Find("Frontal Lobe L");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 6:
            {
                lobuloActual = GameObject.Find("Parietal Lobe L");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 7:
            {
                lobuloActual = GameObject.Find("Occipital Lobe L");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            case 8:
            {
                lobuloActual = GameObject.Find("Temporal Lobe L");
                var script = lobuloActual.GetComponent<Lobulos>();
                script.CrearCirculo();
                break;
            }
            default:
            break;
            
        }
    }

}
