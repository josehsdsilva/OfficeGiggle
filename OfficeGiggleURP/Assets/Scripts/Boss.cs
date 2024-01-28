using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int BossHealth = 100;
    public Slider barraDeVidaBoss; // Referência para a barra de vida no Unity

    void Start()
    {
        // Certifique-se de que a referência da barra de vida esteja configurada
        if (barraDeVidaBoss == null)
        {
            Debug.LogError("A referência da barra de vida não foi configurada no Unity.");
        }

        // Inicializa a barra de vida com a vida inicial do chefe
        AtualizarBarraDeVida();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            BossHealth -= 1;

            // Atualiza a barra de vida
            AtualizarBarraDeVida();

            if (BossHealth == 0)
            {
                // Destroi a bala ao colidir com o objeto "Wall"
                Destroy(gameObject);
            }
        }
    }

    // Atualiza a barra de vida com base na vida atual do chefe
    void AtualizarBarraDeVida()
    {
        // Certifica-se de que a barra de vida seja válida
        if (barraDeVidaBoss != null)
        {
            // Normaliza a vida para o intervalo [0, 1]
            float vidaNormalizada = Mathf.Clamp01((float)BossHealth / 100f);

            // Atualiza o valor da barra de vida
            barraDeVidaBoss.value = vidaNormalizada;
        }
    }
}
