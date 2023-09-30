using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cuando el objeto colisione con el jugador lo elimina
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
