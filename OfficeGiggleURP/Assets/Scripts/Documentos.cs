using UnityEngine;

public class Documentos : MonoBehaviour
{
    private Vector3 alvo;
    private float tempoDeVida;
    private Rigidbody2D rbDocumentos; // Adicionado componente Rigidbody2D
    public int DocumentHealth = 2;
    public int damage = 1000;

    public void Inicializar(Vector3 novoAlvo, float novoTempoDeVida)
    {
        alvo = novoAlvo;
        tempoDeVida = novoTempoDeVida;

        // Configura a destruição após o tempo de vida
        Destroy(gameObject, tempoDeVida);

        // Obtém ou adiciona o componente Rigidbody2D
        rbDocumentos = GetComponent<Rigidbody2D>();
        if (rbDocumentos == null)
        {
            rbDocumentos = gameObject.AddComponent<Rigidbody2D>();
            rbDocumentos.gravityScale = 0; // Desativa a gravidade
        }
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

        // Verifica se colidiu com um objeto parede
        if (other.gameObject.CompareTag("Wall"))
        {
            Repelir(other.transform.position);
        }
    }

    void Repelir(Vector3 pontoDeColisao)
    {
        // Calcula a direção oposta ao ponto de colisão
        Vector3 direcaoRepelir = transform.position - pontoDeColisao;

        // Aplica uma força para repelir o objeto
        if (rbDocumentos != null)
        {
            rbDocumentos.AddForce(direcaoRepelir.normalized * 5f, ForceMode2D.Impulse);
        }
    }
}
