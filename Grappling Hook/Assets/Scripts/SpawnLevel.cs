using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject finish;
    public GameObject[] buildings;
    public GameObject playerSpawner;
    public FinalScreen finalscreenScript;

    Transform lastBuilding;
    int i;

    void Start()
    {
        Starting();
        Middle(6);
        Finishing();

        playerSpawner.SetActive(true);
        finalscreenScript.enabled = true;
    }

    void Starting()
    {
        lastBuilding = gameObject.transform;
    }

    void Middle(int quantity)
    {
        while(i < quantity)
        {
            lastBuilding = Instantiate(buildings[Random.Range(0, buildings.Length)], transform.position + new Vector3(0, Random.Range(-1.3f, 1.3f), lastBuilding.position.z + 45), Quaternion.identity).transform;
            i++;
        }
    }

    void Finishing()
    {
        Instantiate(finish, transform.position + new Vector3(0, Random.Range(-1.3f, 1.3f), lastBuilding.position.z + 45), Quaternion.identity);
    }
}
