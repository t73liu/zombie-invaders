using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float travelDistance = 200f;
    public float spritePadding = 40f;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private void Start()
    {
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, zDistance));
        xMin = botLeft.x + spritePadding;
        xMax = topRight.x - spritePadding;
        yMin = botLeft.y + spritePadding;
        yMax = topRight.y - spritePadding;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * travelDistance * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * travelDistance * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * travelDistance * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * travelDistance * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
        }
        float xMoveLimit = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xMoveLimit, transform.position.y, transform.position.z);
        float yMoveLimit = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(transform.position.x, yMoveLimit, transform.position.z);
    }
}