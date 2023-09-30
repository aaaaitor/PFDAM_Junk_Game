using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> chunksTerreno;
    public GameObject jugador;
    public float comprobador;
    Vector3 posicionSinTerreno;
    public LayerMask mascaraTerreno;
    public GameObject chunkActual;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> chunksCreados;
    public GameObject ultimoChunk;
    public float distanciaMaxima;
    float distanciaOptima;
    float recargaOptimizador;
    public float duracionRecargaOptimizador;


    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!chunkActual)
        {
            return;
        }

        // Comprueba que el jugador se mueva horizontalmente mientras no se mueve verticalmente
        // Derecha
        if (pm.direccionMovimiento.x > 0 && pm.direccionMovimiento.y == 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("Right").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        // Izquierda
        else if (pm.direccionMovimiento.x < 0 && pm.direccionMovimiento.y == 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("Left").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        // Comprueba que el jugador se mueva verticalmente mientras no se mueve horizontalmente
        // Arriba
        else if (pm.direccionMovimiento.y > 0 && pm.direccionMovimiento.x == 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("Up").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        // Abajo
        else if (pm.direccionMovimiento.y < 0 && pm.direccionMovimiento.x == 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("Down").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        // Comprueba que el jugador se mueva verticalmente mientras se mueve horizontalmente
        // Arriba derecha
        else if (pm.direccionMovimiento.y > 0 && pm.direccionMovimiento.x > 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("RightUp").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        // Abajo derecha
        else if (pm.direccionMovimiento.y < 0 && pm.direccionMovimiento.x > 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("RightDown").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        // Arriba izquierda
        else if (pm.direccionMovimiento.y > 0 && pm.direccionMovimiento.x < 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("LeftUp").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("LeftUp").position;
                SpawnChunk();
            }
        }
        // Abajo izquierda
        else if (pm.direccionMovimiento.y < 0 && pm.direccionMovimiento.x < 0)
        {
            // Comprueba si el jugador va a salir del chunk actual para generar otro
            if (!Physics2D.OverlapCircle(chunkActual.transform.Find("LeftDown").position, comprobador, mascaraTerreno))
            {
                posicionSinTerreno = chunkActual.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        // Crea un chunk aleatorio y lo instancia
        int rand = Random.Range(0, chunksTerreno.Count);
        ultimoChunk = Instantiate(chunksTerreno[rand], posicionSinTerreno, Quaternion.identity);
        chunksCreados.Add(ultimoChunk);
    }

    void ChunkOptimizer()
    {
        // Crea un control del optimizador para que no se ejecute todo el rato
        recargaOptimizador -= Time.deltaTime;
        if (recargaOptimizador <= 0f)
        {
            recargaOptimizador = duracionRecargaOptimizador;
        }
        else
        {
            return;
        }

        // Comprueba la distancia del jugador al chunk y si es mayor que la distancia maxima desactiva el chunk
        // y si es menor lo vuelve a activar
        foreach (GameObject chunk in chunksCreados)
        {
            distanciaOptima = Vector3.Distance(jugador.transform.position, chunk.transform.position);
            if (distanciaOptima > distanciaMaxima)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
