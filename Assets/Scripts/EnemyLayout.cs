using UnityEngine;

public class EnemyLayout : MonoBehaviour
{
    public float width = 300f;
    public float height = 200f;
    public float speed = 400f;
    public GameObject enemyType;
    private bool moveLeft;
    private bool moveDown;
    private float xMax;
    private float xMin;

    public void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        foreach (Transform posn in transform)
        {
            GameObject instance = Instantiate(enemyType, posn.position, Quaternion.identity);
            instance.transform.SetParent(posn);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    public void Update()
    {
        if (moveLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float leftLayoutLimit = transform.position.x - width * 0.5f;
        if (leftLayoutLimit < xMin)
        {
            moveLeft = false;
        }

        float rightLayoutLimit = transform.position.x + width * 0.5f;
        if (rightLayoutLimit > xMax)
        {
            moveLeft = true;
        }
    }
}