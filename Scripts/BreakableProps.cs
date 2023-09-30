using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    // Variables de los props que se pueden destruir
    public float vida;

    public void TakeDamage(float dmg)
    {
        // Resta vida al prop y si es igual o menor que 0
        // lo destruye
        vida -= dmg;

        if (vida <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
