using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Variables para el estado de los enemigos
    public EnemyScriptableObject dataEnemigo;
    [HideInInspector]
    public float velocidadActual;
    [HideInInspector]
    public float danyoActual;
    [HideInInspector]
    public float vidaActual;

    public float distanciaDesaparicion = 20f;
    Transform jugador;
    PlayerStats estadoJugador;

    void Awake()
    {
        // Asigna las propiedades al ser instanciado
        velocidadActual = dataEnemigo.VelocidadMovimiento;
        danyoActual = dataEnemigo.Danyo;
        vidaActual = dataEnemigo.VidaMax;
    }
    void Start()
    {
        if (!gameObject.scene.isLoaded) return;
        jugador = FindObjectOfType<PlayerStats>().transform;
        estadoJugador = FindObjectOfType<PlayerStats>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, jugador.position) >= distanciaDesaparicion)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg)
    {
        // Comprueba el daño que recibe el enemigo y si no le queda vida lo destruye
        vidaActual -= dmg;

        if (vidaActual <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Comprueba si el enemigo se esta tocando con el jugador
        // y si es asi le aplica daño
        if (collision.CompareTag("Player"))
        {
            if (estadoJugador.saludActual <= 0) return;
            estadoJugador.TakeDamage(danyoActual);
        }
    }

    void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        if (!gameObject.scene.isLoaded) return;
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        // Si el enemigo esta mas lejos que la distancia de desaparicion se mueve
        // al enemigo a un punto de aparicion predefinido aleatorio
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = jugador.position + es.posicionesAparicionRelativas[Random.Range(0, es.posicionesAparicionRelativas.Count)].position;
    }
}
