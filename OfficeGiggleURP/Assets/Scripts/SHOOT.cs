using UnityEngine;

public class SHOOT : MonoBehaviour
{
    public GameObject projetilPrefab;
    public float velocidadeDisparo = 10f;

    void Update()
    {
        ApontarEAtirar();
    }

    void ApontarEAtirar()
    {
        // Obt�m a posi��o do mouse em rela��o ao mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Atualiza a rota��o do jogador para apontar na dire��o do mouse
        //transform.up = (mousePosition - transform.position).normalized;

        // Disparo ao pressionar o bot�o esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Disparar(mousePosition);
        }
    }

    void Disparar(Vector3 direcaoDoMouse)
    {
        // Instancia o projetil no ponto de disparo (cursor do mouse)
        GameObject projetil = Instantiate(projetilPrefab, transform.position , Quaternion.identity);

        // Calcula a dire��o do disparo
        Vector3 direcaoDisparo = (direcaoDoMouse - transform.position).normalized;

        // Aplica velocidade ao projetil
        projetil.GetComponent<Rigidbody2D>().velocity = direcaoDisparo * velocidadeDisparo;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bala colidiu com um objeto chamado "Wall"
        if (other.gameObject.CompareTag("Wall"))
        {
            // Destroi a pr�pria bala
            Destroy(gameObject);
        }
    }
}
