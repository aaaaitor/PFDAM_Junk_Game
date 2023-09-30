using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        // Instancia el arma creada
        GameObject cuchilloCreado = Instantiate(dataArma.Prefabricado);
        // Posiciona el arma en el mismo lugar que su padre (el jugador)
        cuchilloCreado.transform.position = transform.position;
        // Asigna en que direccion se tiene que mover el cuchillo
        cuchilloCreado.GetComponent<KnifeBehaviour>().DirectionChecker(pm.ultimaDireccionVectorial);
    }
}
