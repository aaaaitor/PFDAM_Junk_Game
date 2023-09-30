using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoBasura;
    private int enemigosEliminados = 0;

    [System.Serializable]
    public class Wave
    {
        public string nombreOleada;
        public List<EnemyGroup> gruposEnemigos;
        public int cuotaOleada;             // Cantidad total de enemigos a spawnear
        public float intervaloAparicion;    // Intervalo de aparcicion de los enemigos
        public int cuentaAparicion;         // Cuantos enemigos han aparecido ya
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string nombreEnemigo;
        public int cuentaEnemigos;          // Cuenta de los enemigos a spawnear
        public int cuentaAparicion;         // Cantidad de enemigos de este tipo ya spawneados
        public GameObject prefabricadoEnemigo;
    }

    public List<Wave> oleadas;          // Lista de todas las oleadas
    public int cuentaOleadaActual = 1;  // Index de la oleada actual

    [Header("Atributos aparicion")]
    float tiempoAparicion;              // Determina cuando tiene que aparecer el siguiente enemigo
    Transform jugador;
    PlayerStats estadoJugador;
    public float intervaloOleada;               // Intervalo entre una oleada y otra
    public int enemigosVivos;                   // Cuantos enemigos vivos hay
    public int maxEnemigosPermitidos;           // Cuantos enemigos vivos pueden haber a la vez
    public bool maxEnemigosAlcanzados = false;  // Si se ha alcanzado el max. de enemigos permitidos

    [Header("Posiciones aparicion")]
    public List<Transform> posicionesAparicionRelativas;    // Lista de posiciones donde van a aparecer los enemigos

    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<PlayerStats>().transform;
        estadoJugador = FindObjectOfType<PlayerStats>();
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba que una oleada haya terminado antes de empezar otra
        if (cuentaOleadaActual < oleadas.Count && oleadas[cuentaOleadaActual].cuentaAparicion == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        // Comprueba si ha pasado el intervalo para spawnear otro enemigo
        tiempoAparicion += Time.deltaTime;
        if (tiempoAparicion >= oleadas[cuentaOleadaActual].intervaloAparicion)
        {
            tiempoAparicion = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        // Espera a que pasen los segundos de 'intervaloOleada' antes de iniciar una nueva oleada
        yield return new WaitForSeconds(intervaloOleada);

        if (cuentaOleadaActual < (oleadas.Count - 1))
        {
            cuentaOleadaActual++;
            CalculateWaveQuota();

        }
    }

    void CalculateWaveQuota()
    {
        // Calcula la cuota de la oleada
        int cuotaOleadaActual = 0;
        foreach (var grupoEnemgios in oleadas[cuentaOleadaActual].gruposEnemigos)
        {
            cuotaOleadaActual += grupoEnemgios.cuentaEnemigos;
        }

        oleadas[cuentaOleadaActual].cuotaOleada = cuotaOleadaActual;
    }

    void SpawnEnemies()
    {
        // Spawnea los enemigos dependiendo de la cuota de la oleada
        if (oleadas[cuentaOleadaActual].cuentaAparicion < oleadas[cuentaOleadaActual].cuotaOleada && !maxEnemigosAlcanzados)
        {
            foreach (var grupoEnemigos in oleadas[cuentaOleadaActual].gruposEnemigos)
            {
                if (grupoEnemigos.cuentaAparicion < grupoEnemigos.cuentaEnemigos)
                {
                    // Limita la cantidad de enemigos que pueden spawnear
                    if (enemigosVivos >= maxEnemigosPermitidos)
                    {
                        maxEnemigosAlcanzados = true;
                        return;
                    }

                    // Instancia a los enemigos en los puntos predefinidos aleatorios
                    if (estadoJugador.saludActual <= 0) return;
                    Instantiate(grupoEnemigos.prefabricadoEnemigo, jugador.position + posicionesAparicionRelativas[Random.Range(0, posicionesAparicionRelativas.Count)].position, Quaternion.identity);

                    grupoEnemigos.cuentaAparicion++;
                    oleadas[cuentaOleadaActual].cuentaAparicion++;
                    enemigosVivos++;
                }
            }
        }
        // Si los enemigos vivos son menos que los maximos permitidos
        // asigna la variable de maxEnemigosAlcanzados a falso
        if (enemigosVivos < maxEnemigosPermitidos)
        {
            maxEnemigosAlcanzados = false;
        }
    }

    public void OnEnemyKilled()
    {
        // Decrementa el numero de enemigos vivos cuando se mata a un enemigo
        enemigosVivos--;
        // Actualiza el texto
        enemigosEliminados++;
        textoBasura.text = string.Format("· Basura limpiada: {0}", enemigosEliminados);
    }
}
