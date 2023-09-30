using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    // Variables para las stats de las armas
    [SerializeField]
    GameObject prefabricado;
    public GameObject Prefabricado { get => prefabricado; private set => prefabricado = value; }
    [SerializeField]
    float danyo;
    public float Danyo { get => danyo; private set => danyo = value; }
    [SerializeField]
    float velocidad;
    public float Velocidad { get => velocidad; private set => velocidad = value; }
    [SerializeField]
    float duracionRecarga;
    public float DuracionRecarga { get => duracionRecarga; private set=> duracionRecarga = value;}
    [SerializeField]
    int penetracion;
    public int Penetracion { get => penetracion; private set => penetracion = value;}
}
