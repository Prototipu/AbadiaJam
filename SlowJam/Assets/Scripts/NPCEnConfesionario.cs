using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnConfesionario : MonoBehaviour
{
    public Transform conversant;
    public string Conv;

    public bool EndConv = false;
    public bool HaEntrado = false;

    public void EntrarConfesionario()
    {
        gameObject.SetActive(true);
        HaEntrado=true;
    }   
    
    public void SalirConfesionario()
    {
        gameObject.SetActive(false);
    }   

    public void FinConversacion()
    {
        EndConv = true; 
    }

}
