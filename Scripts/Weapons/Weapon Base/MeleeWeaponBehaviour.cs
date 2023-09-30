using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    // Variables para el comportamiento de las armas melee
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(danyoActual);
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(danyoActual);
            }
        }
    }
}
