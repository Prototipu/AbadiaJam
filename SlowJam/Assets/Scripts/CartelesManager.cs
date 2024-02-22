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

    public GameObject CartelGrande;
    public GameObject TextoCartelGrande;

    public List<string> TextosCartelGrandeHemanaLuzei;

    public DialogueDatabase DialogueDatabase;

    int currentCartel;
    int valorTexto1, valorTexto2, valorTexto3, valorTexto4;


    public void ShowCartel(int num)
    {        
        Carteles[num].SetActive(true);
        Botones[num].SetActive(true);

        currentCartel = num;
        //Debug.Log(currentCartel);
    }

    public void CambiarTextoPequeno(string texto)
    {
        Debug.Log(currentCartel);

        TextosPequenos[currentCartel].GetComponent<TMP_Text>().text = texto;
        Debug.Log(texto + "eeeeeeeee");
    }

    public void ActivarCartelGrande(bool t)
    {
        CartelGrande.SetActive(t);
    } 

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

    public void SePuedenSeleccionarCarteles()
    {
        for (int i = 0; i < Botones.Count; i++)
        {
            Botones[i].SetActive(true);
        }
    }

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

} 
