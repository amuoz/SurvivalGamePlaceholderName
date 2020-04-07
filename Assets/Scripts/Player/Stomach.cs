using UnityEngine;
using Mirror;

public class Stomach : NetworkBehaviour
{
    private float hunger = 100.0f;

    [SerializeField]
    private float decay = 1f;

    public float Hunger => hunger;

    // Update is called once per frame
    void Update()
    {
        hunger = Mathf.Clamp(hunger - Time.deltaTime * decay, 0, 100f);
    }

    public void Feed(float foodSize)
    {
        hunger += foodSize;
        if (hunger > 100.0f)
        {
            hunger = 100.0f;
        }
    }
}