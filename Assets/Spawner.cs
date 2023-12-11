using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trianglePrefab;
    public GameObject bulletPrefab;
    public float triangleSpeed = 15f;
    public float bulletSpeed = 20f;

    public Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 90f); // Example: 90 degrees around the Y-axis


    void Start()
    {
        if (gameObject.name == "TriangleSpawner")
        {
            InvokeRepeating("SpawnTriangle", 5f, 5f);
        }

        if (gameObject.name == "BulletSpawner")
        {
            InvokeRepeating("SpawnBullet", 3f, 3f);
        }
    }

    void Update()
    {
        if (gameObject.name == "TriangleSpawner")
        {
            MoveTriangles();
        }

        if (gameObject.name == "BulletSpawner")
        {
            MoveBullets();
        }
    }

    void SpawnBullet()
    {
        GameObject bulletPrefabGO = Instantiate(bulletPrefab, transform.position, spawnRotation);
        bulletPrefabGO.AddComponent<NPCObject>();
    }

    void MoveBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet"); // Assuming triangles have a "Triangle" tag

        foreach (GameObject bullet in bullets)
        {
            Vector3 moveDirection = Vector3.up;
            bullet.transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        }
    }
    void SpawnTriangle()
    {
        GameObject trianglePrefabGO = Instantiate(trianglePrefab, transform.position, Quaternion.identity);
        trianglePrefabGO.AddComponent<NPCObject>();
    }

    void MoveTriangles()
    {
        GameObject[] triangles = GameObject.FindGameObjectsWithTag("Triangle"); // Assuming triangles have a "Triangle" tag

        foreach (GameObject triangle in triangles)
        {
            Vector3 moveDirection = Vector3.left;
            triangle.transform.Translate(moveDirection * triangleSpeed * Time.deltaTime);
        }
    }
}
