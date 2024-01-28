using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TransicaoParaProximaScena();
        }
    }

    private void TransicaoParaProximaScena()
    {
        // Obt�m o �ndice da cena atual
        int indiceCenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Carrega a pr�xima cena na ordem da build
        SceneManager.LoadScene(indiceCenaAtual + 1);
    }
}
