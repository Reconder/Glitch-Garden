using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Attacker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gravestone"))
        {
            Jump();
        }
        else if (collision.GetComponent<Defender>())
        {
            Attack(collision.gameObject);
        }
        else if (collision.name == "Base")
        {

        }
    }

    private void Jump() => animator.SetTrigger("jumpTrigger");
}
