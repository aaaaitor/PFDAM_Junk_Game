using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    // Atributos base de un personaje
    [SerializeField]
    GameObject armaInicial;
    public GameObject ArmaInicial { get => armaInicial; private set => armaInicial = value; }

    [SerializeField]
    float saludMaxima;
    public float SaludMaxima { get => saludMaxima; private set => saludMaxima = value; }

    [SerializeField]
    float recuperacion;
    public float Recuperacion { get => recuperacion; private set => recuperacion = value; }

    [SerializeField]
    float velocidadMovimiento;
    public float VelocidadMovimiento { get => velocidadMovimiento; private set => velocidadMovimiento = value; }

    [SerializeField]
    float poder;
    public float Poder { get => poder; private set => poder = value; }

    [SerializeField]
    float velocidadProyectil;
    public float VelocidadProyectil { get => velocidadProyectil; private set => velocidadProyectil = value; }

    [SerializeField]
    float magnetismo;
    public float Magnetismo { get => magnetismo; private set => magnetismo = value; }
}
