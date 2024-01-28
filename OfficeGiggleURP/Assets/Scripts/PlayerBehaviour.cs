using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float velocidade = 5f;
    public static bool apanhou = false;
    Animator animator;
    bool isFacingLeft = false, moving = false;
    Vector2 facingRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
        facingRight = transform.localScale;
    }

    void FixedUpdate()
    {
        // Obtém as entradas do teclado
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        isFacingLeft = movimentoHorizontal < 0;
        moving = movimentoVertical > 0.01f || movimentoVertical < -0.01f || movimentoHorizontal > 0.01f || movimentoHorizontal < -0.01f;
        animator.SetFloat("moveX", movimentoHorizontal);
        animator.SetFloat("moveY", movimentoVertical);
        animator.SetBool("moving", moving);

        if (isFacingLeft)
        {
            transform.localScale = new Vector2(-facingRight.x, facingRight.y);
        }
        else
        {
            transform.localScale = facingRight;
        }
        // Calcula a direção do movimento
        Vector3 direcao = new Vector3(movimentoHorizontal, movimentoVertical, 0f).normalized;

        // Move o jogador na direção calculada
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
