using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Triangle"))
        {
            Debug.Log("Destroyer OnTriggerEnter2D: Destroying Triangle!");
            Destroy(collision.gameObject);
        }
    }

}
