using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        // Variables del objecto recogible
        public string nombre;
        public GameObject prefabricado;
        public float ratioAparicion;
    }

    public List<Drops> objetosRecogibles;

    private void OnDestroy()
    {
        // Cuando un objeto es destruido genera un numero aleatorio (0-100)
        // y si el numero es mas pequeño o igual q el ratio de aparicion del
        // objeto instancia un objeto en la localizacion del objeto destruido
        float numeroAleatorio = UnityEngine.Random.Range(0f, 100f);
        List<Drops> objetosRecogiblesPosibles = new List<Drops>();

        foreach (Drops objeto in objetosRecogibles)
        {
            if (numeroAleatorio <= objeto.ratioAparicion)
            {
                objetosRecogiblesPosibles.Add(objeto);
            }
        }

        // Elige un objeto recogible de todos los objetos recogibles posibles
        if (objetosRecogiblesPosibles.Count > 0)
        {
            Drops objeto = objetosRecogiblesPosibles[UnityEngine.Random.Range(0, objetosRecogiblesPosibles.Count)];
            // Solamente instancia objetos si la escena está activa, para evitar errores
            if (!gameObject.scene.isLoaded) return;
            Instantiate(objeto.prefabricado, transform.position, Quaternion.identity);
        }
    }
}
