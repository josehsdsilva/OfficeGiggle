using UnityEngine;

public class SHOOT : MonoBehaviour
{
    public GameObject projetilPrefab;
    public float velocidadeDisparo = 10f;
    public static bool apanhou = false;


    void Update()
    {
        ApontarEAtirar();
    }

    void ApontarEAtirar()
    {
        if (Weapon.apanhou == true)
        {
            // Obtém a posição do mouse em relação ao mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Disparo ao pressionar o botão esquerdo do mouse
            if (Input.GetMouseButtonDown(0))
            {
                Disparar(mousePosition);
            }
        }
    }

    void Disparar(Vector3 direcaoDoMouse)
    {

        // Instancia o projetil no ponto de disparo (cursor do mouse)
        GameObject projetil = Instantiate(projetilPrefab, transform.position , Quaternion.identity);

        // Calcula a direção do disparo
        Vector3 direcaoDisparo = (direcaoDoMouse - transform.position).normalized;

        // Aplica velocidade ao projetil
        projetil.GetComponent<Rigidbody2D>().velocity = direcaoDisparo * velocidadeDisparo;
    }
}
