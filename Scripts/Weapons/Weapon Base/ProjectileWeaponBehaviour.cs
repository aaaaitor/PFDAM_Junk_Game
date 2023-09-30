using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Variables del comportamiento de los proyetiles
    protected Vector3 direccion;
    public float tiempoParaDestruccion;
    public WeaponScriptableObject dataArma;

    // Stats actuales del arma
    protected float danyoActual;
    protected float velocidadActual;
    protected float duracionRecargaActual;
    protected int penetracionActual;

    void Awake()
    {
        danyoActual = dataArma.Danyo;
        velocidadActual = dataArma.Velocidad;
        duracionRecargaActual = dataArma.DuracionRecarga;
        penetracionActual = dataArma.Penetracion;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, tiempoParaDestruccion);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direccion = dir;

        float dirx = direccion.x;
        float diry = direccion.y;

        Vector3 escala = transform.localScale;
        Vector3 rotacion = transform.rotation.eulerAngles;

        // Cambia la direccion en la que apunta el sprite del arma dependiendo de a donde se mueve el jugador
        // Izquierda
        if (dirx < 0 && diry == 0)
        {
            escala.x = escala.x * -1;
            escala.y = escala.y * -1;
        }
        // Abajo
        else if (dirx == 0 && diry < 0)
        {
            escala.y = escala.y * -1;
        }
        // Arriba
        else if (dirx == 0 && diry > 0)
        {
            escala.x = escala.x * -1;
        }
        // Arriba derecha
        else if (dir.x > 0 && dir.y > 0)
        {
            rotacion.z = 0f;
        }
        // Abajo derecha
        else if (dir.x > 0 && dir.y < 0)
        {
            rotacion.z = -90f;
        }
        // Arriba izquierda
        else if (dir.x < 0 && dir.y > 0)
        {
            escala.x = escala.x * -1;
            escala.y = escala.y * -1;
            rotacion.z = -90f;
        }
        // Abajo izquierda
        else if (dir.x < 0 && dir.y < 0)
        {
            escala.x = escala.x * -1;
            escala.y = escala.y * -1;
            rotacion.z = 0f;
        }

        transform.localScale = escala;
        transform.rotation = Quaternion.Euler(rotacion);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el arma ha colisionado con el enemigo y le quita el daño actual del arma
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(danyoActual);
            ReducePierce();
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(danyoActual);
                ReducePierce();
            }
        }
    }

    void ReducePierce()
    {
        // Reduce la penetracion del arma y comprueba si ha llegado a 0, en ese caso destruye el arma;
        penetracionActual--;
        if (penetracionActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
