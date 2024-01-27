using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float velocidade = 5f;
    public static bool apanhou = false;

    void Update()
    {
        // Obtém as entradas do teclado
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula a direção do movimento
        Vector3 direcao = new Vector3(movimentoHorizontal, movimentoVertical, 0f).normalized;

        // Move o jogador na direção calculada
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
