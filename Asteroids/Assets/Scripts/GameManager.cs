using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int level;
    [SerializeField] private Text scoreText, vidasUI;
    [SerializeField] private Player player;
    [SerializeField] private AsteroidsManager asteroidsManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo.vidas = 3;
        PlayerInfo.score = 0;
        level = 2;
        asteroidsManager.numAsteroidesPorEje = level + 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerInfo.score.ToString("00000");
        vidasUI.text = PlayerInfo.vidas.ToString("00");
        asteroidsManager.numAsteroidesPorEje = level;

        if(PlayerInfo.vidas <= 0)
        {
            player.death.Play();
            SceneManager.LoadScene("Defeat");
        }

        if(FindObjectsOfType<Asteroid>().Length == 0 )
        {
            level++;
            asteroidsManager.PlaceAsteroids(level + 1);
            player.ResetPosition();
        }
    }


}
