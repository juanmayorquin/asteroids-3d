using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string escena;
    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }
}
