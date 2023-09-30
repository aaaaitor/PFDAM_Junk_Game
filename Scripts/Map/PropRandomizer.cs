using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> puntosAparicionObjetos;
    public List<GameObject> preCreacionObjetos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        // Crea los objetos de forma aleatoria
        foreach (GameObject punto in puntosAparicionObjetos)
        {
            int rand = Random.Range(0, preCreacionObjetos.Count);
            // Instancia los objetos
            GameObject objeto = Instantiate(preCreacionObjetos[rand], punto.transform.position, Quaternion.identity);
            objeto.transform.parent = punto.transform;
        }
    }
}
