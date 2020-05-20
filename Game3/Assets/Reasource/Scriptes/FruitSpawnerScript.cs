using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnerScript : MonoBehaviour
{
    public GameObject Apple;
    float randX;
    float randY;

    Vector3 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    public List<GameObject> apple_list = new List<GameObject>();
    void Start()
    {
        
    }


    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            randY = Random.Range(-5f, 4f);

            whereToSpawn = new Vector3(randX, randY, transform.position.y);
            GameObject _apple=Instantiate(Apple, whereToSpawn, Quaternion.identity);
            apple_list.Add(_apple);
        }
    }
}
