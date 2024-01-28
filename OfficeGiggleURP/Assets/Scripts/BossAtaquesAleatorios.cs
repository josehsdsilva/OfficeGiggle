using UnityEngine;
using UnityEngine.UI;

public class BossAtaquesAleatorios : MonoBehaviour
{
    public GameObject espadaPrefab;
    public float velocidadeMovimento = 1f;
    public float intervaloEntreAtaques = 5f;
    public float tempoDeVidaEspada = 3f;
    public float forcaLancamento = 10f; // Ajuste conforme necess�rio
    //public Sprite novaSprite;
    //private Image imagemDoObjeto;

    private float tempoUltimoAtaque = 0f;
    private Transform jogador;

    void Start()
    {
        //imagemDoObjeto = GetComponent<Image>();

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
        // Move o boss em dire��o ao jogador
        transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidadeMovimento * Time.deltaTime);
        // Verifica se tempo suficiente passou desde o �ltimo ataque
        if (Time.time - tempoUltimoAtaque > intervaloEntreAtaques)
        {
            // Executa o ataque
            ExecutarAtaque();
            tempoUltimoAtaque = Time.time; // Atualiza o tempo do �ltimo ataque
        }
    }

    void ExecutarAtaque()
    {
        //MudarSprite();
        // Instancia a espada no local do chefe
        GameObject espada = Instantiate(espadaPrefab, transform.position, Quaternion.identity);

        // Adiciona for�a ao Rigidbody da espada
        Rigidbody2D rbEspada = espada.GetComponent<Rigidbody2D>();
        if (rbEspada != null)
        {
            Vector2 direcaoLancamento = (jogador.position - transform.position).normalized;
            rbEspada.AddForce(direcaoLancamento * forcaLancamento, ForceMode2D.Impulse);
        }

        // Configura a espada para flutuar continuamente em dire��o ao jogador
        Documentos espadaFlutuante = espada.GetComponent<Documentos>();
        if (espadaFlutuante != null)
        {
            espadaFlutuante.Inicializar(jogador.position, tempoDeVidaEspada);
        }
    }
    // Fun��o para mudar a sprite de uma imagem
    /*void MudarSprite()
    {
        // Atribui a nova sprite � imagem
        imagemDoObjeto.sprite = novaSprite;
    }*/
}
