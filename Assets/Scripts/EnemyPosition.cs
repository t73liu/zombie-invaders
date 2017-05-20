using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public float radius = 40f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}