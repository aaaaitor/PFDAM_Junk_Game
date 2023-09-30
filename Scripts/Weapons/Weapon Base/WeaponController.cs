using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Variables para el control de las armas
    [Header("Weapons Stats")]
    public WeaponScriptableObject dataArma;
    float recargaActual;

    protected PlayerMovement pm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Recoge el movimiento del jugador
        pm = FindObjectOfType<PlayerMovement>();
        // Asigna la duracion de la recarga a la recarga actual para que no se utilice un arma
        // mas de una vez al mismo tiempo.
        recargaActual = dataArma.DuracionRecarga;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Cuando la recarga llega a 0 ataca
        recargaActual -= Time.deltaTime;
        if (recargaActual <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        // Actualiza la recarga actual
        recargaActual = dataArma.DuracionRecarga;
    }
}
