using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowMouse : MonoBehaviour {
    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
