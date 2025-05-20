using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
 
public class MultiUIToggler : MonoBehaviour
{
    [System.Serializable]
    public class ToggleUI
    {
        public Toggle toggle;
        public GameObject targetUI;
    }

    public List<ToggleUI> toggleUIList;

    void Start()
    {
        foreach (var item in toggleUIList)
        {
            item.toggle.onValueChanged.AddListener((bool isOn) =>
            {
                item.targetUI.SetActive(isOn);
            });

            // Inicializar visibilidad
            item.targetUI.SetActive(item.toggle.isOn);
        }
    }
}
