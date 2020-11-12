using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 2f;
    [SerializeField] int damage = 50;
    public float speedSign;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update() => transform.Translate(speedSign * Vector2.right * Time.deltaTime * speed);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        var attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
    public int DealDamage => damage;
    public void SetDamageValue(int dmgValue) => damage = dmgValue;
}
