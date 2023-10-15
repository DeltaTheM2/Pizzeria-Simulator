using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTraffic : MonoBehaviour
{
    public GameObject finishPoint;
    public float speed = 5.0f;
    bool isFrontClear = true;
    void MoveToFinish()
    {
        if (isFrontClear)
        {

            float distanceToFinish = Vector3.Distance(transform.position, finishPoint.transform.position);

            if(distanceToFinish < 0.1f)
                transform.position = Vector3.MoveTowards(transform.position, finishPoint.transform.position, speed * Time.deltaTime);


        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Customer" || other.tag == "Player" || other.tag == "Car")
        {
            isFrontClear = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Customer" || other.tag == "Player" || other.tag == "Car")
        {
            isFrontClear = true;
        }
    }
    private void FixedUpdate()
    {
        MoveToFinish();
    }








}
