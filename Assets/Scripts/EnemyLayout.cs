using UnityEngine;

public class EnemyLayout : MonoBehaviour
{
    public float width = 100f;
    public float height = 100f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}