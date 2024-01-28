using UnityEngine;

public class SHOOT : MonoBehaviour
{
    public GameObject projetilPrefab;
    public float velocidadeDisparo = 10f;
    Animator animator;
    float cooldown = 0.5f;
    bool shooting;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ApontarEAtirar();
    }

    void ApontarEAtirar()
    {
        if (Weapon.apanhou)
        {
            if (shooting) cooldown -= Time.deltaTime;

            // Obtém a posição do mouse em relação ao mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Disparo ao pressionar o botão esquerdo do mouse
            if (Input.GetMouseButtonDown(0))
            {
                Disparar(mousePosition);
                shooting = true;
                cooldown = 1f;
                animator.SetBool("shooting", true);
            }
            else if (shooting && cooldown < 0)
            {
                shooting = false;
                animator.SetBool("shooting", false);
            }
        }
    }

    void Disparar(Vector3 direcaoDoMouse)
    {
        if (!BarraOverheat.frozen)
        {
            // Instancia o projetil no ponto de disparo (cursor do mouse)
            GameObject projetil = Instantiate(projetilPrefab, transform.position, Quaternion.identity);

            // Calcula a direção do disparo
            Vector3 direcaoDisparo = (direcaoDoMouse - transform.position).normalized;

            // Aplica velocidade ao projetil
            projetil.GetComponent<Rigidbody2D>().velocity = direcaoDisparo * velocidadeDisparo;
        }
    }
}
