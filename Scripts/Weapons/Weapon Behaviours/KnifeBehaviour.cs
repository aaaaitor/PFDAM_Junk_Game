using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    //Variables para el comportamiento del cuchillo
    KnifeController kc;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Asigna el movimiento del cuchillo
        transform.position += direccion * velocidadActual * Time.deltaTime;
    }
}
