using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaLimpiaController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject zonaLimpiaCreada = Instantiate(dataArma.Prefabricado);
        zonaLimpiaCreada.transform.position = transform.position;
        zonaLimpiaCreada.transform.parent = transform;
    }

}
