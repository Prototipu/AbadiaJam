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



    public enum State {DefinirPersoanje, Entrar, Conversar, Salir }
    public State currentState = State.DefinirPersoanje;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNPC = AllNPCs[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
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
                    Debug.Log("Se acabó");
                }
                else
                {
                    ChangeState(State.DefinirPersoanje);
                }

                break;
        }
    }

    void ChangeState(State newState)
    {
        //Exit Logic
        switch(currentState)
        {
            case State.DefinirPersoanje:
                break;

            case State.Entrar:
                break;

            case State.Conversar:

                break;

            case State.Salir:

                break;
        }

        //Enter Logic
        switch (newState)
        {
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
        }

        currentState = newState;
    }

    void StartConversation(string conv, Transform actor, Transform conversant)
    {
        DialogueManager.StartConversation(conv, actor, conversant);
    }
}
