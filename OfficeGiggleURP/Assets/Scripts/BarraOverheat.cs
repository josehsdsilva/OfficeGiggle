using UnityEngine;
using UnityEngine.UI;

public class BarraOverheat : MonoBehaviour
{
    public Slider barraSlider;
    public GameObject Player;
    public float taxaDeEnchimento = 0.01f;
    public float taxaDeResfriamento = 0.02f;
    public float limiteOverheat = 100.0f;
    public AudioSource ficarfeliz;
    

    public static float nivelOverheat = 50.0f;
    public static bool frozen = false;

    void Update()
    {
        if (Weapon.apanhou)
        {
            if (!frozen)
            {
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

                // Atualiza a visualização da barra
                AtualizarBarraOverheat();

                if (nivelOverheat >= 50.0)
                {
                    if (!ficarfeliz.isPlaying)
                    {
                        ficarfeliz.Play();
                    }

                }
                else
                {
                    if (ficarfeliz.isPlaying)
                    {
                        ficarfeliz.Stop();
                    }

                }

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
        }
    }


void AtualizarBarraOverheat()
    {
        // Atualiza o valor da barra de overheat usando o Slider
        barraSlider.value = nivelOverheat;
    }

    void CongelarJogador()
    {
        frozen = true;
        Debug.Log("Jogador Congelado!");
        // Adicione aqui qualquer lógica adicional ao congelar o jogador
    }
    void ToTristeMorri()
    {
        Destroy(Player);
    }

    public float ReturnOverHeat()
    {
        return nivelOverheat;
    }
}
