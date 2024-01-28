using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFundo : MonoBehaviour
{
    public AudioSource ficartriste;
    [SerializeField] private BarraOverheat barraOverheat;

    public void awake()
    {
        ficartriste = GetComponent<AudioSource>();
        
    } 

    public void PlayMusic()
    {
        if (barraOverheat.ReturnOverHeat() >= 50.0)
        {
            if (!ficartriste.isPlaying)
            {
                ficartriste.Play();
            }

        }
        else
        {
            if (ficartriste.isPlaying)
            {
                ficartriste.Stop();
            }

        }

        if (PauseMenu.GameIsPaused)
        {

        }
    }



}
