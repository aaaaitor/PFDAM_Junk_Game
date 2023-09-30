using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField]
    private Slider deslizador;

    public void SetMaxExperience(float vidaMax)
    {
        deslizador.maxValue = vidaMax;
        deslizador.value = vidaMax;
    }

    public void SetExperience(float vida)
    {
        deslizador.value = vida;
    }
}
