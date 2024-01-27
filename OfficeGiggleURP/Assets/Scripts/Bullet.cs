using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Wall"
        if (other.gameObject.CompareTag("Wall"))
        {
            // Destroi a bala ao colidir com o objeto "Wall"
            Destroy(gameObject);
        }

        // Verifica se a bala colidiu com um objeto chamado "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroi a bala ao colidir com o objeto "Wall"
            Destroy(gameObject);
        }
    }
}
