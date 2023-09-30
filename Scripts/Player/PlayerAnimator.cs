using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Referencias
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador se esta moviendo aplica la animacion
        if (pm.direccionMovimiento.x != 0 || pm.direccionMovimiento.y != 0)
        {
            am.SetBool("Move", true);
        }
        // Si el jugador se queda quieto la quita
        else
        {
            am.SetBool("Move", false);
        }

        SpriteDirectionChecker();
    }

    void SpriteDirectionChecker()
    {
        if (pm.ultimoVectorHorizontal < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
