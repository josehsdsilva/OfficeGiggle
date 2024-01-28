using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int BossHealth = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            BossHealth -= 1;
            if (BossHealth == 0)
            {
                // Destroi a bala ao colidir com o objeto "Wall"
                Destroy(gameObject);
            }
        }
    }
}
