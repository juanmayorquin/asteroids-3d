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
        for (int x = 0; x < numAsteroidesPorEje; x++)
        {
            for(int y = 0; y < numAsteroidesPorEje; y++)
            {
                for(int z = 0; z < numAsteroidesPorEje; z++)
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
    
    float AsteroidOffset()
    {
        return Random.Range(-espacioEntreAsteroides / 2f, espacioEntreAsteroides / 2f);
    }
}
