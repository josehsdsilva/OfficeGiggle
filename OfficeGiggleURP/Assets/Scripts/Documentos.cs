using UnityEngine;

public class Documentos : MonoBehaviour
{
    private Vector3 alvo;
    private float tempoDeVida;
    public int DocumentHealth = 2;
    public int damage = 1000;

    public void Inicializar(Vector3 novoAlvo, float novoTempoDeVida)
    {
        alvo = novoAlvo;
        tempoDeVida = novoTempoDeVida;

        // Configura a destruição após o tempo de vida
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Move suavemente em direção ao alvo
        transform.position = Vector3.Lerp(transform.position, alvo, Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            DocumentHealth -= 1;
            if (DocumentHealth == 0)
            {
                // Destroi a bala ao colidir com o objeto "Wall"
                Destroy(gameObject);
            }
        }
        // Verifica se a bala colidiu com um objeto chamado "Enemy"
        if (other.gameObject.CompareTag("Player"))
        {
            BarraOverheat.nivelOverheat -= damage * Time.deltaTime;
            BarraOverheat.nivelOverheat = Mathf.Clamp(BarraOverheat.nivelOverheat, 0f, 100);
        }
    }
}
