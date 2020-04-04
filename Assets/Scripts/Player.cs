using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
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

        MovePlayer();
    }

    private void InteractState() {
        PlayerInteract interaction = GetComponent<PlayerInteract>();

        interaction.Interact();

        playerState = State.Movement;
    }

    private void MovePlayer() {
        float moveX = 0;
        float moveY = 0;
        bool isRightInput = Input.GetKey("d");
        bool isLeftInput = Input.GetKey("a");
        bool isDownButton = Input.GetKey("s");
        bool isUpButton = Input.GetKey("w");

        if (isRightInput) {
            moveX = 1;
        } else if (isLeftInput) {
            moveX = -1;
        }

        if (isUpButton) {
            moveY = 1;
        } else if (isDownButton) {
            moveY = -1;
        }

        if (moveX != 0 && moveY != 0) {
            moveX /= Mathf.Sqrt(2);
            moveY /= Mathf.Sqrt(2);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(
            moveX * speed,
            moveY * speed
        );
    }

    private void PlayerAction() {
        PlayerInteract interaction = GetComponent<PlayerInteract>();

        if (interaction.HasInteractable()) {
            playerState = State.Interact;
        }
    }
}
