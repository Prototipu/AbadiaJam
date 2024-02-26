using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.ChatMapper;

public class ConfesionarioManager : MonoBehaviour
{
    public GameObject Player;

    public List<GameObject> AllNPCs;
    public GameObject CurrentNPC;
    int CurrentNPCIndex = 0;

    public bool PrimerDialogoHecho = false;
    public bool MasConfesoresDialogoHecho = false;
    public bool FinConfesionesDialogoHecho = false;

    public enum State {None, InicioDia, DefinirPersoanje, Entrar, Conversar, Salir, MasConfesores, FinConfesiones }
    public State currentState = State.DefinirPersoanje;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentNPC = AllNPCs[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
            case State.None:
                ChangeState(State.InicioDia);
                break;
            case State.InicioDia:
                if (PrimerDialogoHecho)
                    ChangeState(State.DefinirPersoanje);
                break;
            case State.DefinirPersoanje:
                //Definir los valores del personaje que entra en el confesionario
                CurrentNPC = AllNPCs[CurrentNPCIndex];
                CurrentNPCIndex++;
                //Pasar al siguiente estado
                ChangeState(State.Entrar);
                break;

            case State.Entrar:
                if (CurrentNPC.GetComponent<NPCEnConfesionario>().HaEntrado)
                    ChangeState(State.Conversar);
                break;

            case State.Conversar:

                if (CurrentNPC.GetComponent<NPCEnConfesionario>().EndConv)
                {
                    ChangeState(State.Salir);
                }

                break;

            case State.Salir:
                Debug.Log("CurrentNPCIntex: " + CurrentNPCIndex + " AllNPCs.Count: " + AllNPCs.Count);

                if (CurrentNPCIndex == AllNPCs.Count)
                {
                    Debug.Log("entra en el if de acabar");
                    ChangeState(State.FinConfesiones);
                }
                else
                {
                    ChangeState(State.MasConfesores);
                }

                break;
            case State.MasConfesores:
                if (MasConfesoresDialogoHecho)
                    ChangeState(State.DefinirPersoanje);
                break;
            case State.FinConfesiones:

                    //Lógica de salir del confesionario
                    Debug.Log("Se acabó el día de confesarse");
                
                break;
        }

        /*if (FinConfesionesDialogoHecho)
        {
            ChangeState(State.FinConfesiones);
        }*/
    }

    void ChangeState(State newState)
    {
        //Exit Logic
        switch(currentState)
        {
            case State.None:

                break;
            case State.InicioDia:
                MasConfesoresDialogoHecho = false;
                //FinConfesionesDialogoHecho = false;
                break;
            case State.DefinirPersoanje:
                break;

            case State.Entrar:
                break;

            case State.Conversar:

                break;

            case State.Salir:

                break;
            case State.MasConfesores:
                MasConfesoresDialogoHecho = false;
                //FinConfesionesDialogoHecho = false;
                break;
            case State.FinConfesiones:

                break;
        }

        //Enter Logic
        switch (newState)
        {
            case State.None:

                break;
            case State.InicioDia:
                StartConversation("Inicio Dia", Player.transform, Player.transform);
                break;
            case State.DefinirPersoanje:

                break;

            case State.Entrar:
                CurrentNPC.GetComponent<NPCEnConfesionario>().EntrarConfesionario();
                break;

            case State.Conversar:
                StartConversation(CurrentNPC.GetComponent<NPCEnConfesionario>().Conv, Player.transform, CurrentNPC.GetComponent<NPCEnConfesionario>().conversant);
                break;

            case State.Salir:
                CurrentNPC.GetComponent<NPCEnConfesionario>().SalirConfesionario();

                break;
            case State.MasConfesores:
                StartConversation("MasConfesores", Player.transform, Player.transform);
                MasConfesoresDialogoHecho = false;
                break;
            case State.FinConfesiones:
                StartConversation("FinConfesiones", Player.transform, Player.transform);
                //FinConfesionesDialogoHecho = false;
                break;
        }

        currentState = newState;
    }

    void StartConversation(string conv, Transform actor, Transform conversant)
    {
        DialogueManager.StartConversation(conv, actor, conversant);
    }

    public void FinDialogoPlayer()
    {
        PrimerDialogoHecho = true;
        MasConfesoresDialogoHecho = true;
        //FinConfesionesDialogoHecho = true;
    }
    public void FinConfesiones()
    {
        ChangeState(State.Salir);
    }
    
}
