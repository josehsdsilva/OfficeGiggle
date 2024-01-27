using UnityEngine;
using UnityEngine.UI;

public class BarraOverheat : MonoBehaviour
{
    public Slider barraSlider;
    public float taxaDeEnchimento = 0.01f;
    public float taxaDeResfriamento = 0.02f;
    public float limiteOverheat = 1.0f;

    private float nivelOverheat = 0.0f;
    private bool congelado = false;

    void Update()
    {
        if (!congelado)
        {
            // Enche a barra de overheat quando o jogador clica
            if (Input.GetMouseButtonDown(0))
            {
                nivelOverheat += taxaDeEnchimento * Time.deltaTime;
                nivelOverheat = Mathf.Clamp01(nivelOverheat); // Garante que o valor esteja entre 0 e 1
            }
            // Resfria a barra de overheat quando não está atirando
            else
            {
                nivelOverheat -= taxaDeResfriamento * Time.deltaTime;
                nivelOverheat = Mathf.Clamp01(nivelOverheat); // Garante que o valor esteja entre 0 e 1
            }

            // Atualiza a visualização da barra
            AtualizarBarraOverheat();

            // Verifica se atingiu o limite de overheat
            if (nivelOverheat >= limiteOverheat)
            {
                CongelarJogador();
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
        congelado = true;
        Debug.Log("Jogador Congelado!");
        // Adicione aqui qualquer lógica adicional ao congelar o jogador
    }
}
