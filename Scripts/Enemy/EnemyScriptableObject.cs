using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    // Stats base para los enemigos
    [SerializeField]
    float velocidadMovimiento;
    public float VelocidadMovimiento { get => velocidadMovimiento; private set => velocidadMovimiento = value; }
    [SerializeField]
    float vidaMax;
    public float VidaMax { get => vidaMax; private set => vidaMax = value; }
    [SerializeField]
    float danyo;
    public float Danyo { get => danyo; private set => danyo = value; }
}
