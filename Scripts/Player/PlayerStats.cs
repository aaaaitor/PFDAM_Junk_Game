using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStats : MonoBehaviour
{
    // Stats base del personaje
    CharacterScriptableObject dataPersonaje;
    //[HideInInspector]
    public float saludActual;
    [HideInInspector]
    public float saludMaxActual;
    [HideInInspector]
    public float recuperacionActual;
    [HideInInspector]
    public float velocidadMovimientoActual;
    [HideInInspector]
    public float poderActual;
    [HideInInspector]
    public float velocidadProyectilActual;
    [HideInInspector]
    public float magnetismoActual;

    [SerializeField]
    private HealthBar barraDeVida;
    [SerializeField]
    private ExperienceBar barraExperiencia;
    [SerializeField]
    private TMP_Text textoNivel;

    // Armas del jugador
    public List<GameObject> armas;

    // Sistema de experiencia
    [Header("Experiencia/Nivel")]
    public int experiencia = 0;
    public int nivel = 1;
    public int limiteExperiencia;

    // Clase para asignar el nivel y los limites de experiencia al jugador
    [System.Serializable]
    public class LevelRange
    {
        public int nivelInicial;
        public int nivelFinal;
        public int aumentoLimiteExperiencia;
    }

    // I-Frames
    [Header("I-Frames")]
    public float duracionInvencible;
    float invincibilidadActual;
    bool esInvencible;

    public List<LevelRange> rangosNiveles;

    void Awake()
    {
        Time.timeScale = 1f;

        // Data del personaje seleccionado
        dataPersonaje = CharacterSelector.GetData();
        CharacterSelector.instancia.DestroySingleton();

        // Valores de las variables actuales al principio de la partida
        saludActual = dataPersonaje.SaludMaxima;
        saludMaxActual = dataPersonaje.SaludMaxima;
        recuperacionActual = dataPersonaje.Recuperacion;
        velocidadMovimientoActual = dataPersonaje.VelocidadMovimiento;
        poderActual = dataPersonaje.Poder;
        velocidadProyectilActual = dataPersonaje.VelocidadProyectil;
        magnetismoActual = dataPersonaje.Magnetismo;
        esInvencible = false;

        // Asigna el arma incial
        SpawnWeapon(dataPersonaje.ArmaInicial);

        // Asigna la vida maxima en la barra visual
        barraDeVida.SetMaxHealth(saludActual);
        barraDeVida.SetHealth(saludActual);
        // Asigna la experiencia inicial
        barraExperiencia.SetExperience(0);
    }

    void Start()
    {
        // inicializa el limite de experiencia en el primer nivel
        limiteExperiencia = rangosNiveles[0].aumentoLimiteExperiencia;
        barraExperiencia.SetMaxExperience(limiteExperiencia);
        barraExperiencia.SetExperience(0);
    }

    void Update()
    {
        if (invincibilidadActual > 0)
        {
            invincibilidadActual -= Time.deltaTime;
        }
        // Si la duracion de la invincibilidad llega a 0 el jugador se vuelve vencible
        else if (esInvencible && invincibilidadActual <= 0)
        {
            esInvencible = false;
        }

        Recover();
    }

    public void IncreaseExperience(int xp)
    {
        experiencia += xp;
        LevelUpChecker();
        barraExperiencia.SetExperience(experiencia);
    }

    public void LevelUpChecker()
    {
        // Comprueba la experiencia que gana el jugador y si es necesario lo sube de nivel,
        // al subirle de nivel tambien incrementa el limite de experiencia necesario para
        // pasar al siguiente nivel.
        if (experiencia >= limiteExperiencia)
        {
            nivel++;
            experiencia -= limiteExperiencia;
            barraExperiencia.SetExperience(experiencia);
            textoNivel.text = string.Format("Nvl. {0}", nivel);
            int incrementoLimiteExperiencia = 0;
            foreach (LevelRange rango in rangosNiveles)
            {
                if (nivel >= rango.nivelInicial && nivel <= rango.nivelFinal)
                {
                    incrementoLimiteExperiencia = rango.aumentoLimiteExperiencia;
                    break;
                }
            }
            limiteExperiencia += incrementoLimiteExperiencia;
            barraExperiencia.SetMaxExperience(limiteExperiencia);
            ManageUpgradeStat();
        }
    }

    public void ManageUpgradeStat()
    {
        // Gestiona las stats mejoradas al subir de nivel
        Time.timeScale = 0f;
        LevelManager.instance.LevelUp();
    }

    public void TakeDamage(float dmg)
    {
        // Comprueba que el jugador no este dentro del tiempo de invincibilidad
        if (!esInvencible) {
            // Aplica la funcionalidad de que el jugador pueda recibir daño
            saludActual -= dmg;

            invincibilidadActual = duracionInvencible;
            esInvencible = true;

            if (saludActual <= 0)
            {
                Kill();
            }

            // Actualiza la barra de vida
            barraDeVida.SetHealth(saludActual);
        }
    }

    public void Kill()
    {
        // Mata al jugador
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    public void RestoreHealth(float saludRecuperada)
    {
        // Cura al jugador si no tiene la salud maxima
        // y si la salud que recupera es mayor que la maxima
        // le asigna la salud maxima
        if (saludActual < saludMaxActual)
        {
            saludActual += saludRecuperada;

            if (saludActual > saludMaxActual)
            {
                saludActual = saludMaxActual;
            }

            barraDeVida.SetHealth(saludActual);
        }
    }

    void Recover()
    {
        // Aplica la funcionalidad de que el jugador se pueda curar con el tiempo
        if (saludActual < saludMaxActual) {
            saludActual += recuperacionActual * Time.deltaTime;

            // Asegura que cuando se recupera salud la salud actual nunca sea mayor que la maxima
            if (saludActual > saludMaxActual)
            {
                saludActual = saludMaxActual;
            }

            barraDeVida.SetHealth(saludActual);
        }
    }

    public void SpawnWeapon(GameObject arma)
    {
        // Spawnea el arma inicial
        GameObject armaSpawneada = Instantiate(arma, transform.position, Quaternion.identity);
        armaSpawneada.transform.SetParent(transform);
        armas.Add(armaSpawneada);
    }
}
