using UnityEngine;

public class Stomach : MonoBehaviour
{
    private float hunger = 100.0f;

    public float Hunger => hunger;

    public void Feed(float foodSize)
    {
        hunger += foodSize;
        if (hunger > 100.0f)
        {
            hunger = 100.0f;
        }
    }
}