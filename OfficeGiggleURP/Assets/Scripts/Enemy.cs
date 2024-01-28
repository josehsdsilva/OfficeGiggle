using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    private int EnemyHealth = 5;

    NavMeshAgent agent;
    public bool happy = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (happy) return;

        agent.SetDestination(target.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyHealth -= 1;
            if (EnemyHealth <= 0)
            {
                //EnemyHealth = 5;
                // Destroi a bala ao colidir com o objeto "Wall"
                agent.isStopped = true;
                happy = true;
            }
        }
    }
}
