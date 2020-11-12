using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Attacker
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>())
        {
            Attack(collision.gameObject);
        }
    }
}
