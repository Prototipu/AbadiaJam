using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCEnConfesionario : MonoBehaviour
{
    public Transform conversant;
    public string Conv;

    public bool EndConv = false;
    public bool HaEntrado = false;
    public bool IsMoving = false;
    public bool IsLeaving = false;

    public float Speed = 5f;
    public Vector2 CentroConfesionario;
    public Vector2 FueraConfesionario;

    private void Update()
    {
        if (IsMoving)
        {
            MoverAlMedio();
        }

        if (IsLeaving)
        {
            SacarDelConfesionario();
        }
    }

    public void EntrarConfesionario()
    {
        gameObject.SetActive(true);

        IsMoving = true;
    }

    public void SalirConfesionario()
    {
        IsLeaving = true;
    }

    void MoverAlMedio()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, CentroConfesionario, step);

        float distance = Vector2.Distance(transform.position, CentroConfesionario);
        if (distance < 0.1)
        {
            // Detener el movimiento una vez alcanzada la posición objetivo
            IsMoving = false;
            HaEntrado = true;

            Debug.Log("¡Objetivo alcanzado!");
        }
    }

    void SacarDelConfesionario()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, FueraConfesionario, step);

        float distance = Vector2.Distance(transform.position, FueraConfesionario);
        if (distance < 0.1)
        {
            // Detener el movimiento una vez alcanzada la posición objetivo
            IsLeaving = false;
            gameObject.SetActive(false);
        }
    }

    public void FinConversacion()
    {
        EndConv = true;
    }

}
