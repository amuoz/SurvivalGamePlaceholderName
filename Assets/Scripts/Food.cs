using UnityEngine;

public class Food : MonoBehaviour
{
    public float size;
    
    public void Interact(GameObject other)
    {
        Stomach belly = other.GetComponent<Stomach>();
        
        if (belly != null) {
            belly.Feed(size);
        }

        Destroy(this.gameObject);
    }
}