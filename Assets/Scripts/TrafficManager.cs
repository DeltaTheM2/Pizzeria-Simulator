using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
 public List<GameObject> carsPrefab = new List<GameObject>();
    public GameObject[] startingPoints, finishPoints;
    public float timePassed = 0;

    public void SpawnCars()
    {
        int randomIndex = Random.Range(0, startingPoints.Length);
        if (!startingPoints[randomIndex].GetComponent<SpawnTrigger>().isFull())
        {
            GameObject randomCars = carsPrefab[Random.Range(0, carsPrefab.Count)];
            GameObject currentStart = startingPoints[randomIndex];

            // Set the car's rotation to the starting point's rotation
            Quaternion startRotation = currentStart.transform.rotation;

            Instantiate(randomCars, currentStart.transform.position, startRotation);
            randomCars.GetComponent<FollowTraffic>().finishPoint = finishPoints[randomIndex];
        }
        else
        {
            return;
        }
    }


    private void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > 5) {
            SpawnCars();
            timePassed = 0;
        }
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(5);
        SpawnCars();
        timePassed = 0;
    }


}
