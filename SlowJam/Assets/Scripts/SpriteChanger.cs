using UnityEngine;
using UnityEngine.UI;

public class CambiadorDeSprite : MonoBehaviour
{
    
    GameObject dayIcon;
    void Awake()
    {
        // Buscar el GameObject que contiene el componente CambiadorDeSprite
        dayIcon = GameObject.FindWithTag("DayIcon");
        
    }

    // Método para cambiar el sprite de la imagen
    public void CambiarSprite(Sprite nuevoSprite)
    {
       dayIcon.GetComponent<Image>().sprite = nuevoSprite;
    }
}

