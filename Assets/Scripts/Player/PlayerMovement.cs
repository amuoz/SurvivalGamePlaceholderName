using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 1.5f;

    public void Move() {
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

        CmdExecuteMovement(new Vector2(moveX, moveY).normalized);
    }

    [Command]
    private void CmdExecuteMovement(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    [Command]
    public void CmdStop() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
