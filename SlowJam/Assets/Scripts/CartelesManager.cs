using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem.ChatMapper;
using TMPro;

public class CartelesManager : MonoBehaviour
{
    public List <GameObject> Carteles;
    public List<GameObject> Botones;
    public List<GameObject> TextosPequenos;

    public List<GameObject> Barras;
    public List<GameObject> BarrasGrandes;

    public GameObject CartelGrande;
    public GameObject TextoCartelGrande;

    public List<string> TextosCartelGrandeHemanaLuzei;

    public DialogueDatabase DialogueDatabase;

    int currentCartel;
    int valorTexto1, valorTexto2, valorTexto3, valorTexto4;

    int currentBarra;


    public void ShowCartel(int num)
    {        
        Carteles[num].SetActive(true);
        Botones[num].SetActive(true);

        currentCartel = num;
    }

    public void CambiarTextoPequeno(string texto)
    {

        TextosPequenos[currentCartel].GetComponent<TMP_Text>().text = texto;
    }

    //Hace aparecer el cartel grande
    public void ActivarCartelGrande(bool t)
    {
        CartelGrande.SetActive(t);
    } 

    //Cambia el texto del cartel grande (cuando se selecciona uno pequeño) por el que debe salir respecto a la confesion. Utiliza las funciones "ValorTextoX"
    public void CambiarTextoCartelGrande (int TextoAMostrar)
    {
        if (TextoAMostrar == 0)
        {
            TextoCartelGrande.GetComponent<TMP_Text>().text = TextosCartelGrandeHemanaLuzei[valorTexto1];
        }
        else if (TextoAMostrar == 1)
        {
            TextoCartelGrande.GetComponent<TMP_Text>().text = TextosCartelGrandeHemanaLuzei[valorTexto2];
        }
        else if (TextoAMostrar == 2)
        {
            TextoCartelGrande.GetComponent<TMP_Text>().text = TextosCartelGrandeHemanaLuzei[valorTexto3];
        }
        else
        {
            TextoCartelGrande.GetComponent<TMP_Text>().text = TextosCartelGrandeHemanaLuzei[valorTexto4];
        }
    }

    //Estas cuatro funciones guardan un numero que equivale a la confesión respectiva para usarlo en la funcion "CambiarTextoCartelGrande"
    public void ValorTexto1(int i)
    {
        valorTexto1 = i;
    }
    public void ValorTexto2(int i)
    {
        valorTexto2 = i;
    }
    public void ValorTexto3(int i)
    {
        valorTexto3 = i;
    }
    public void ValorTexto4(int i)
    {
        valorTexto4 = i;
    }

    //Activa la seleccion del cartel
    public void SePuedenSeleccionarCarteles()
    {
        for (int i = 0; i < Botones.Count; i++)
        {
            Botones[i].SetActive(true);
        }
    }

    //Se esconden todos los carteles cuando se va el personaje que se esta confesando
    public void EsconderTodosLoscarteles()
    {
        for (int i = 0; i < Botones.Count; i++)
        {
            Botones[i].SetActive(false);
        }

        for (int i = 0; i < Carteles.Count; i++)
        {
            Carteles[i].SetActive(false);
        }
    }

    

 
    //Esta funcion guarda en una variable la barra la cual sera modificada con la siguiente funcion
    public void CurrentBarra(int i)
    {
        currentBarra = i;
    }

    //Esta funcion aumenta el valor de la barra con el valor que se le pasa. 
    public void AumentarBarra(float f)
    {
        //Barras[currentBarra].GetComponent<Slider>().value = Barras[currentBarra].GetComponent<Slider>().value + f;
        Barras[currentBarra].GetComponent<RellenoBarras>().RellenarBarra(f);
    }

    //Esta funcion pasa al cartel grande los valores de las barras del cartel pequeño que se haya seleccionado 
    public void PasarValorBarrasGrandes(int i)
    {
        if (i == 0) 
        {
            BarrasGrandes[0].GetComponent <Slider>().value = Barras[0].GetComponent<Slider>().value;
            BarrasGrandes[1].GetComponent <Slider>().value = Barras[1].GetComponent<Slider>().value;
            BarrasGrandes[2].GetComponent <Slider>().value = Barras[2].GetComponent<Slider>().value;
        }
        else if (i == 1)
        {
            BarrasGrandes[0].GetComponent<Slider>().value = Barras[3].GetComponent<Slider>().value;
            BarrasGrandes[1].GetComponent<Slider>().value = Barras[4].GetComponent<Slider>().value;
            BarrasGrandes[2].GetComponent<Slider>().value = Barras[5].GetComponent<Slider>().value;
        }
        else if(i == 2)
        {
            BarrasGrandes[0].GetComponent<Slider>().value = Barras[6].GetComponent<Slider>().value;
            BarrasGrandes[1].GetComponent<Slider>().value = Barras[7].GetComponent<Slider>().value;
            BarrasGrandes[2].GetComponent<Slider>().value = Barras[8].GetComponent<Slider>().value;
        }
        else
        {
            BarrasGrandes[0].GetComponent<Slider>().value = Barras[9].GetComponent<Slider>().value;
            BarrasGrandes[1].GetComponent<Slider>().value = Barras[10].GetComponent<Slider>().value;
            BarrasGrandes[2].GetComponent<Slider>().value = Barras[11].GetComponent<Slider>().value;
        }
    }
} 
