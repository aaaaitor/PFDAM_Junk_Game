using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats jugador;
    CircleCollider2D colectorJugador;
    public float velocidadRecoleccion;

    void Start()
    {
        jugador = FindObjectOfType<PlayerStats>();
        colectorJugador = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        colectorJugador.radius = jugador.magnetismoActual;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el jugador colisiona con el objeto recogible y si
        // es asi lo recoge
        if (collision.gameObject.TryGetComponent(out ICollectible collectible))
        {
            // Aplica la fuerza de recollecion al objeto recogible en direccion al jugador
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direccionFuerza = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direccionFuerza * velocidadRecoleccion);

            collectible.Collect();
        }
    }
}
