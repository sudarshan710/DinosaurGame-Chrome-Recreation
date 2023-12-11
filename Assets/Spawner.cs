using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trianglePrefab;
    public float triangleSpeed = 15f;

    void Start()
    {
        InvokeRepeating("SpawnTriangle", 5f, 5f);
    }

    void Update()
    {
        MoveTriangles();
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
