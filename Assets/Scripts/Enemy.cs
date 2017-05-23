using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public static int enemyCount;
    private SceneLoader loader;
    public int hp = 120;
    public float projectileSpeed = -400f;
    public float fireChance = 0.4f;
    public bool spreadShot = false;

    public void Start()
    {
        enemyCount++;
        loader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if (Random.value < (fireChance * Time.deltaTime))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
        if (spreadShot)
        {
            GameObject projectileInstance2 = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(-150f, projectileSpeed);
            
            GameObject projectileInstance3 = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(150f, projectileSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            int damageTaken = bullet.GetDamage();
            Debug.Log("bullet hit for " + damageTaken);
            hp -= damageTaken;
            GetComponent<AudioSource>().Play();
            Destroy(collider.gameObject);
            if (hp <= 0)
            {
                enemyCount--;
                loader.enemyDestroyed();
                Destroy(gameObject);
            }
        }
    }
}