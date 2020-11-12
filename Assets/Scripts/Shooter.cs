using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] Spawner myLaneSpawner;
    [SerializeField] int attackDamage;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        
    }

    private void SetLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough) //Is close enough?
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane
    {
        get
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
    private void Update()
    {
        if (IsAttackerInLane)
        {
            animator.SetBool("isAttacking", true);
            //Attack Animation
        }
        else
        {
            animator.SetBool("isAttacking", false);
            //Idle Animation
        }
    }



    //Called in animation
    public void Fire()
    {
        var bullet = Instantiate(projectile, transform.GetChild(0).position, transform.rotation);//
        bullet.SetDamageValue(attackDamage);
        bullet.transform.parent = transform;
        bullet.speedSign = gameObject.transform.localScale.x;
    }
}
