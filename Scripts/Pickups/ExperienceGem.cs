using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    public int experienciaRecibida;
    public void Collect()
    {
        // Incrementa la experiencia del objeto recogido al jugador
        PlayerStats jugador = FindObjectOfType<PlayerStats>();
        jugador.IncreaseExperience(experienciaRecibida);
    }
}
