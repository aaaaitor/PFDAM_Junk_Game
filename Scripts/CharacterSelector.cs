using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instancia;
    public CharacterScriptableObject dataPersonaje;

    void Awake()
    {
        // Guarda la instancia del personaje seleccionado
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CharacterScriptableObject GetData()
    {
        // Recoge la instancia del personaje seleccionado
        return instancia.dataPersonaje;
    }

    public void SelectCharacter(CharacterScriptableObject personaje)
    {
        dataPersonaje = personaje;
    }

    public void DestroySingleton()
    {
        instancia = null;
        Destroy(gameObject);
    }
}
