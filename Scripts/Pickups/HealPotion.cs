using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Pickup, ICollectible
{
    public int cantidadCuracion;
    public void Collect()
    {
        PlayerStats jugador = FindObjectOfType<PlayerStats>();
        jugador.RestoreHealth(cantidadCuracion);
    }
}
