using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 400f;
    private float bulletSpeed;
    public float spritePadding = 40f;
    public float shootIntervals = 2f;
    public GameObject bullet;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private SceneLoader loader;

    private void Start()
    {
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, zDistance));
        xMin = botLeft.x + spritePadding;
        xMax = topRight.x - spritePadding;
        yMin = botLeft.y + spritePadding;
        yMax = topRight.y - spritePadding;
        bulletSpeed = moveSpeed + 50f;
        loader = FindObjectOfType<SceneLoader>();
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shoot", 0.00001f, shootIntervals);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shoot");
        }
        float xMoveLimit = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xMoveLimit, transform.position.y, transform.position.z);
        float yMoveLimit = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(transform.position.x, yMoveLimit, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        loader.Load("LoseScreen");
    }
}