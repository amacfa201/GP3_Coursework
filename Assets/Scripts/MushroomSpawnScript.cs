using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawnScript : MonoBehaviour
{


    public GameObject ground;

    public ArrayList obstacles;

    public GameObject mushroomPrefab;

    public int spawnNum;

    float worldSizeX;

    float worldSizeZ;

    void Start()
    {
        ground = GameObject.Find("Ground");
        obstacles = new ArrayList();
        worldSizeX = GetWorldSize(0);
        worldSizeZ = GetWorldSize(1);
        FillList();
        SpawnBlackHole();

    }

    ArrayList FillList() // Fills array list by calling create method to populate list with gameobjects, returns full array list
    {
        ArrayList obstacles = new ArrayList();
        for (int i = 0; i < spawnNum; i++)
        {
            obstacles.Add(Create(i));
        }

        return obstacles;
    }


    GameObject Create(int i) //Instatiates obstacle and applies appropriate attributes 
    {

        GameObject mushroom = Instantiate(mushroomPrefab);
        mushroom.transform.position = new Vector3(Random.Range(-worldSizeX, worldSizeX), 0.5F, Random.Range(-worldSizeZ, worldSizeZ));
        Renderer rend = mushroom.GetComponent<Renderer>();
        rend.material.color = Color.yellow;
        mushroom.name = "Mushroom" + i;
        return mushroom;

    }


    float GetWorldSize(int axis) // Finds worlds size to ensure obstacles spawn on the world plane 
    {

        if (axis == 0)
        {
            return ground.GetComponent<Renderer>().bounds.size.x / 2;
        }
        else
        {
            return ground.GetComponent<Renderer>().bounds.size.z / 2;
        }



    }


    void SpawnBlackHole() // Spawns enemy which kills player on impact, performs similar task to the Create() method 
    {
        GameObject blackHole = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        blackHole.transform.position = new Vector3(Random.Range(-worldSizeX, worldSizeX), 0.5F, Random.Range(-worldSizeZ, worldSizeZ));
        Renderer rend = blackHole.GetComponent<Renderer>();
        rend.material.color = Color.black;
        blackHole.name = "blackHole";
    }
}
