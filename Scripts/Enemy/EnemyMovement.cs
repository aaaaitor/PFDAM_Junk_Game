using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables para el movimiento del enemigo
    Transform jugador;
    EnemyStats enemigo;
    [HideInInspector]
    public float ultimoVectorHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<EnemyStats>();
        jugador = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // El enemigo se mueve constantemente hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, jugador.transform.position, enemigo.velocidadActual * Time.deltaTime);
        Vector2 direccionMovimiento = transform.position.normalized;

        if (direccionMovimiento.x != 0)
        {
            ultimoVectorHorizontal = direccionMovimiento.x;
        }
    }
}
