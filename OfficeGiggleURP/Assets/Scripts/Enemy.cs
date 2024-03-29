using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    public static int EnemyHealth = 5;

    NavMeshAgent agent;

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
        agent.SetDestination(target.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            Enemy.EnemyHealth -= 1;
            if (Enemy.EnemyHealth == 0)
            {
                // Destroi a bala ao colidir com o objeto "Wall"
                Destroy(gameObject);
            }
        }
    }
}
