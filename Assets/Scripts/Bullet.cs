using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int GetDamage()
    {
        return Random.Range(10, 30);
    }
}