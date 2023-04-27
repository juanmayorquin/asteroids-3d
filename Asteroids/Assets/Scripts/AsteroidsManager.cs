using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] private Asteroid asteroide;
    [SerializeField] private int numAsteroidesPorEje, espacioEntreAsteroides;

    void Start()
    {
        PlaceAsteroids();
    }

    void PlaceAsteroids()
    {
        for (int x = -numAsteroidesPorEje / 2; x < numAsteroidesPorEje / 2; x++)
        {
            for(int y = -numAsteroidesPorEje / 2; y < numAsteroidesPorEje / 2; y++)
            {
                for(int z = -numAsteroidesPorEje / 2; z < numAsteroidesPorEje / 2; z++)
                {
                    InstatiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstatiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroide, new Vector3(transform.position.x + (espacioEntreAsteroides*x) + AsteroidOffset(), transform.position.y + (espacioEntreAsteroides * y) + AsteroidOffset(), transform.position.z + (espacioEntreAsteroides * z) + AsteroidOffset()), Quaternion.identity, transform);
        

    }

    void ThrowAsteroid(Asteroid asteroid)
    {
        asteroid.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)) * 20);
    }
    
    float AsteroidOffset()
    {
        return Random.Range(-espacioEntreAsteroides / 2f, espacioEntreAsteroides / 2f);
    }
}
