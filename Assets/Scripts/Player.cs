using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
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
}
