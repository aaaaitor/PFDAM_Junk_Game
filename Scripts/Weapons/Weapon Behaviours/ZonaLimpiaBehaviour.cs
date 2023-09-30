using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaLimpiaBehaviour : MeleeWeaponBehaviour
{
    // Lista de enemigos que entran al rango del arma
    List<GameObject> enemigosMarcados;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemigosMarcados = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba que el enemigo que este en el rango del arma no este ya
        // dentro de la lista de enemigos marcados
        if (collision.CompareTag("Enemy") && !enemigosMarcados.Contains(collision.gameObject))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(danyoActual);

            enemigosMarcados.Add(collision.gameObject);
        }

        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable) && !enemigosMarcados.Contains(collision.gameObject))
            {
                breakable.TakeDamage(danyoActual);

                enemigosMarcados.Add(collision.gameObject);
            }
        }
    }
}
