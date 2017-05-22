using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("wall destroy");
        DestroyObject(collider.gameObject);
    }
}