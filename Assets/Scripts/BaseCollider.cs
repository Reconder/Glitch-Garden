using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    BaseHealth baseHealth;
    void Start() => baseHealth = FindObjectOfType<BaseHealth>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
            baseHealth.DealtDamage(1);
            Destroy(collision.gameObject);
    }

}
