using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // Referencias
    EnemyMovement em;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteDirectionChecker();
    }

    void SpriteDirectionChecker()
    {
        if (em.ultimoVectorHorizontal < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
