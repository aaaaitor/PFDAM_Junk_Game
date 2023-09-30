using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField]
    public GameObject jugador;
    [HideInInspector]
    public PlayerStats stats;

    [SerializeField]
    private TMP_Text textoNivelSalud;
    int nvlSalud = 1;
    [SerializeField]
    private TMP_Text textoNivelRecuperacion;
    int nvlRecuperacion = 1;
    [SerializeField]
    private TMP_Text textoNivelVelocidadMovimiento;
    int nvlVelocidadMovimiento = 1;
    [SerializeField]
    private TMP_Text textoNivelPoder;
    int nvlPoder = 1;
    [SerializeField]
    private TMP_Text textoNivelVelocidadProyectil;
    int nvlVelocidadProyectil = 1;
    [SerializeField]
    private TMP_Text textoNivelMagnetismo;
    int nvlMagnetismo = 1;

    public void UpgradeStat(string stat)
    {
        stats = jugador.GetComponent<PlayerStats>();
        // Gestiona la stat en concreto que se mejora
        switch (stat)
        {
            case "salud":
                stats.saludMaxActual += 100;
                nvlSalud++;
                textoNivelSalud.text = string.Format("Nvl {0}", nvlSalud);
                break;
            case "recuperacion":
                stats.recuperacionActual += (float)0.5;
                nvlRecuperacion++;
                textoNivelRecuperacion.text = string.Format("Nvl {0}", nvlRecuperacion);
                break;
            case "movimiento":
                stats.velocidadMovimientoActual += (float)0.5;
                nvlVelocidadMovimiento++;
                textoNivelVelocidadMovimiento.text = string.Format("Nvl {0}", nvlVelocidadMovimiento);
                break;
            case "poder":
                stats.poderActual += (float)0.5;
                nvlPoder++;
                textoNivelPoder.text = string.Format("Nvl {0}", nvlPoder);
                break;
            case "proyectil":
                stats.velocidadProyectilActual += (float)0.5;
                nvlVelocidadProyectil++;
                textoNivelVelocidadProyectil.text = string.Format("Nvl {0}", nvlVelocidadProyectil);
                break;
            case "magnetismo":
                stats.magnetismoActual += (float)0.2;
                nvlMagnetismo++;
                textoNivelMagnetismo.text = string.Format("Nvl {0}", nvlMagnetismo);
                break;
            default:
                break;
        }
        LevelManager.instance.LevelUp();
        Time.timeScale = 1f;
    }
}
