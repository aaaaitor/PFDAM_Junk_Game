using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject mapaObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        mc = FindAnyObjectByType<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mc.chunkActual = mapaObjetivo;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (mc.chunkActual == mapaObjetivo)
            {
                mc.chunkActual = null;
            }
        }
    }
}
