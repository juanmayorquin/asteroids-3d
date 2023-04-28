using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeDefeat : MonoBehaviour
{
    [SerializeField] private Text score;

    private void Update()
    {
        score.text = $"Score: {PlayerInfo.score.ToString("00000")}";
    }
}
