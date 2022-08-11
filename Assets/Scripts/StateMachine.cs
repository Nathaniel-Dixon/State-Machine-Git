using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class StateMachine : MonoBehaviour
{
    public enum State
    {
        // patrol routine
        Patrol,
        // searching
        Aware,
        //chase/combat 
        Combat,
        // 
        Flee,
        //Is alseep
        Sleep,
        // Inraged
        Inraged,
        //Dead
        Dead,
        //Slipt
        Slipt,
    }

    //The Ai's current state 
    [SerializeField] private State _state;

    private AIAgent _aiAgent;

    // Update is called once per frame
    private void Start()
    {
        // Grabs the first AiAgent (or what is in the <>)
        // and puts it in the variable
        _aiAgent = GetComponent<AIAgent>();

        NextState();
    }

    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Combat:
                StartCoroutine(CombatState());
                break;
            default:
                Debug.LogWarning("_state doesnt exist withing NextState Function, stopping statemachine");
                break;

        }
        //if (_state == State.Patrol)
        // {
        //StartCoroutine(PatrolState());
        // }
    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.Search();
        while (_state == State.Patrol) //continues till statement is false, looping eg x < 10 so would loop 10 times if x increases by 1 each time
        {
            _aiAgent.Patrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = State.Combat;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }

    private IEnumerator CombatState()
    {
        Debug.Log("Combat: Enter");

        while (_state == State.Combat) //continues till statement is false, looping eg x < 10 so would loop 10 times if x increases by 1 each time
        {
            // our code here
            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Combat: Exit");
        NextState();

    }
}
