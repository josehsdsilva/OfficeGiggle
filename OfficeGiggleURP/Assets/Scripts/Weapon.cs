using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static bool apanhou = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            apanhou = true;
            // Destroi o weapon ao colidir com o objeto "Player"
            Destroy(gameObject);
        }
    }

}
