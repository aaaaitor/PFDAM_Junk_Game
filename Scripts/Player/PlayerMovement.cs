using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    // Movimiento
    Rigidbody2D rb;
    PlayerStats jugador;

    [HideInInspector]
    public float ultimoVectorHorizontal;
    [HideInInspector]
    public float ultimoVectorVertical;
    [HideInInspector]
    public Vector2 direccionMovimiento;
    [HideInInspector]
    public Vector2 ultimaDireccionVectorial;

    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        // Asigna un valor por defecto para que el arma tenga movimiento aunque el jugador no se mueva
        ultimaDireccionVectorial = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    // Metodo de actualizacion que no depende en los frames
    void FixedUpdate()
    {
        Movement();
    }

    // Controla los inputs del usuario
    void InputManagement()
    {
        // Recoge los ejes horizontal y vertical
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Crea el vector de movimiento
        direccionMovimiento = new Vector2(moveX, moveY).normalized;

        // Asigna los ultimos vectores de movimiento recibidos
        if (direccionMovimiento.x != 0)
        {
            ultimoVectorHorizontal = direccionMovimiento.x;
            // Ultimo moviemiento vector x
            ultimaDireccionVectorial = new Vector2(ultimoVectorHorizontal, 0f);
        }
        if (direccionMovimiento.y != 0)
        {
            ultimoVectorVertical = direccionMovimiento.y;
            // Ultimo movimiento vector y
            ultimaDireccionVectorial = new Vector2(0f, ultimoVectorVertical);
        }
        if (direccionMovimiento.x != 0 && direccionMovimiento.y != 0)
        {
            // Ultimo movimiento diagonal
            ultimaDireccionVectorial = new Vector2(ultimoVectorHorizontal, ultimoVectorVertical);
        }
    }

    // Controla el movimiento
    void Movement()
    {
        rb.velocity = new Vector2(direccionMovimiento.x * jugador.velocidadMovimientoActual, direccionMovimiento.y * jugador.velocidadMovimientoActual);
    }
}
