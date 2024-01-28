using UnityEngine;

public class BossAtaquesAleatorios : MonoBehaviour
{
    public GameObject espadaPrefab;
    public float velocidadeMovimento = 1f;
    public float intervaloEntreAtaques = 5f;
    public float tempoDeVidaEspada = 3f;

    private float tempoUltimoAtaque = 0f;
    private Transform jogador;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        // Remove a espada original (caso exista)
        Documentos espadaOriginal = GetComponentInChildren<Documentos>();
        if (espadaOriginal != null)
        {
            Destroy(espadaOriginal.gameObject);
        }
    }

    void Update()
    {
        // Move o boss em direção ao jogador
        transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidadeMovimento * Time.deltaTime);

        // Verifica se tempo suficiente passou desde o último ataque
        if (Time.time - tempoUltimoAtaque > intervaloEntreAtaques)
        {
            // Executa o ataque
            ExecutarAtaque();
            tempoUltimoAtaque = Time.time; // Atualiza o tempo do último ataque
        }
    }

    void ExecutarAtaque()
    {
        // Instancia a espada no local do chefe
        GameObject espada = Instantiate(espadaPrefab, transform.position, Quaternion.identity);

        // Configura a espada para flutuar continuamente em direção ao jogador
        Documentos espadaFlutuante = espada.GetComponent<Documentos>();
        if (espadaFlutuante != null)
        {
            espadaFlutuante.Inicializar(jogador.position, tempoDeVidaEspada);
        }
    }
}
