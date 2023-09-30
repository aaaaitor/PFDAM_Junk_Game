using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider deslizador;

    public void SetMaxHealth(float vidaMax)
    {
        deslizador.maxValue = vidaMax;
        deslizador.value = vidaMax;
    }

    public void SetHealth(float vida)
    {
        deslizador.value = vida;
    }
}
