using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projetilPrefab;
    public float velocidadeDisparo = 5f;
    public float taxaDeDisparo = 1f; // Quantos segundos entre cada disparo

    private Transform jogador;
    private float tempoDesdeUltimoDisparo = 0f;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Verifica se o jogador est� no campo de vis�o do inimigo
        if (jogador != null && PodeAtirar())
        {
            Atirar();
        }
    }

    bool PodeAtirar()
    {
        // Verifica se tempo suficiente passou desde o �ltimo disparo
        tempoDesdeUltimoDisparo += Time.deltaTime;
        if (tempoDesdeUltimoDisparo >= taxaDeDisparo)
        {
            tempoDesdeUltimoDisparo = 0f;
            return true;
        }
        return false;
    }

    void Atirar()
    {
        // Instancia o projetil no ponto de disparo (posi��o do inimigo)
        GameObject projetil = Instantiate(projetilPrefab, transform.position, Quaternion.identity);

        // Calcula a dire��o do disparo em rela��o ao jogador
        Vector3 direcaoDisparo = (jogador.position - transform.position).normalized;

        // Aplica velocidade ao projetil
        projetil.GetComponent<Rigidbody2D>().velocity = direcaoDisparo * velocidadeDisparo;
    }
}
