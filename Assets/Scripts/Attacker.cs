using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    private float speed = 1f;
    GameObject currentTarget;
    protected Animator animator;
    [SerializeField] int attackDamage = 20;
    [SerializeField] int score = 100;

    public delegate void AttackerSpawnedEventHandler();

    public event AttackerSpawnedEventHandler OnAttackerSpawned;

    public delegate void AttackerDestroyedEventHandler(int score);

    public event AttackerDestroyedEventHandler OnAttackerDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        OnAttackerSpawned?.Invoke();
        OnAttackerDestroyed += FindObjectOfType<ScoreText>().AddScore;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float newSpeed) => speed = newSpeed;

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) {  return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(attackDamage);
        }
    }

    private void OnDestroy() => OnAttackerDestroyed?.Invoke(score);

}
