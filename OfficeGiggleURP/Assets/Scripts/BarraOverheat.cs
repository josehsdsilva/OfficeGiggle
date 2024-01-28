using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraOverheat : MonoBehaviour
{
    public Slider barraSlider;
    public GameObject player;
    public float taxaDeEnchimento = 0.01f;
    public float taxaDeResfriamento = 0.02f;
    public float limiteOverheat = 100.0f;

    public static float nivelOverheat = 50.0f;
    public static bool frozen = false;
    Animator animator;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        animator.SetBool("dead", false);
        nivelOverheat = 50f;
        frozen = false;
    }

    void Update()
    {
        if (!Weapon.apanhou) return;
        
        if (frozen) return;
            
        // Enche a barra de overheat quando o jogador clica
        if (Input.GetMouseButtonDown(0))
        {
            nivelOverheat += taxaDeEnchimento;
            nivelOverheat = Mathf.Clamp(nivelOverheat, 0f, limiteOverheat);
        }
        // Resfria a barra de overheat quando não está atirando
        else
        {
            nivelOverheat -= taxaDeResfriamento * Time.deltaTime;
            nivelOverheat = Mathf.Clamp(nivelOverheat, 0f, limiteOverheat);
        }

        animator.SetBool("sad", nivelOverheat < 50f);

        // Atualiza a visualização da barra
        AtualizarBarraOverheat();

        // Verifica se atingiu o limite de overheat
        if (nivelOverheat >= limiteOverheat)
        {
            CongelarJogador();
        }
        // Verifica se atingiu o limite de overheat
        if (nivelOverheat <= 0)
        {
            ToTristeMorri();
        } 
    }

    void AtualizarBarraOverheat()
    {
        // Atualiza o valor da barra de overheat usando o Slider
        barraSlider.value = nivelOverheat;
    }

    void CongelarJogador()
    {
        // Adicione aqui qualquer lógica adicional ao congelar o jogador
        StartCoroutine("FreezePlayer");
    }

    IEnumerator FreezePlayer()
    {
        frozen = true;
        animator.SetBool("happy", true);

        yield return new WaitForSeconds(3);

        frozen = false;
        animator.SetBool("happy", false);
    }

    void ToTristeMorri()
    {
        StartCoroutine("DeadPlayer");
    }

    IEnumerator DeadPlayer()
    {
        frozen = true;
        animator.SetBool("dead", true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
