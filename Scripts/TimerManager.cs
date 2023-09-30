using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    // Variable para la cuenta del tiempo
    private float tiempoTranscurrido;
    private int minutos;
    private int segundos;
    [SerializeField]
    private TMP_Text textoContador;
    PlayerStats estadoJugador;

    // Start is called before the first frame update
    void Start()
    {
        estadoJugador = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estadoJugador.saludActual <= 0) return;
        tiempoTranscurrido += Time.deltaTime;
        minutos = (int) (tiempoTranscurrido / 60f);
        segundos = (int) (tiempoTranscurrido - minutos * 60);

        textoContador.text = string.Format("· Tiempo actual: {0:00}:{1:00}", minutos, segundos);
    }
}
