using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class RellenoBarras : MonoBehaviour
{
    Slider slider;
    [SerializeReference]
    float valorDeseado;

    public Image image;
    Color currentColor;

    ParticleSystem particles;

    [SerializeField] float velocidad = 0.3f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();
        currentColor = image.color;
        particles.startColor = currentColor;    
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0f)
        {
            image.color = new Color(0,0,0,0);
        }
        else
        {
            image.color = currentColor;
        }

        if (slider.value < valorDeseado)
        {
            if (!particles.isPlaying)
            {
                particles.Play();
            }
            slider.value += velocidad * Time.deltaTime;
            
        }
        else
        {
            particles.Stop();
        }
    }

    public void RellenarBarra(float f)
    {
        valorDeseado = f;

    }
}
