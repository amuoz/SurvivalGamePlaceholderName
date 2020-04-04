using UnityEngine;

public class Food : MonoBehaviour
{
    public float size;
    
    public void Interact(GameObject other)
    {
        Stomach belly = other.GetComponent<Stomach>();
        
    void OnTriggerEnter2D(Collider2D player)
        if (belly != null) {
            belly.Feed(size);
        }

        Destroy(this.gameObject);
    }
}