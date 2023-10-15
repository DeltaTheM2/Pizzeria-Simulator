using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
 public List<GameObject> carsPrefab = new List<GameObject>();
    public GameObject[] startingPoints, finishPoints;

    public void SpawnCars()
    {
        int randomIndex = Random.Range(0, startingPoints.Length);
        if (startingPoints[randomIndex].GetComponent<SpawnTrigger>().isFull())
        {
            GameObject randomCars = carsPrefab[Random.Range(0, carsPrefab.Count)];

            GameObject currentStart = startingPoints[randomIndex];
            Instantiate(randomCars, currentStart.transform.position, Quaternion.identity);
            randomCars.GetComponent<FollowTraffic>().finishPoint = finishPoints[randomIndex];
        }
        else
        {
            return;
        }
    }






}
