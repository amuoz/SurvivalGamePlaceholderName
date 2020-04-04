using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool debugDistance = true;
    private enum State {
        Movement,
        Interact
    }
    private State playerState;
    private Dictionary<State, System.Action> stateFunctions;
    // Start is called before the first frame update
    void Start() {
        playerState = State.Movement;
        initStateFunctions();
    }

    private void initStateFunctions() {
        stateFunctions = new Dictionary<State, System.Action>();
        stateFunctions[State.Movement] = MoveState;
        stateFunctions[State.Interact] = InteractState;
    }

    // Update is called once per frame
    void Update() {
        stateFunctions[playerState]();
        
        if (debugDistance) {
            Debug.DrawLine(
                transform.position,
                new Vector3(transform.position.x + 0.15f, transform.position.y + 0.15f, 10),
                Color.white
            );
        }
    }

    private void MoveState() {
        bool isActionInput = Input.GetButton("Fire1");
        if (isActionInput) {
            PlayerAction();
        }

        GetComponent<PlayerMovement>().Move();
    }

    private void InteractState() {
        GetComponent<PlayerInteraction>().Interact();

        playerState = State.Movement;
    }

    private void PlayerAction() {
        if (GetComponent<PlayerInteraction>().HasInteractable()) {
            playerState = State.Interact;
        }
    }
}
