using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This works with both the game manager and gets the triggers from positionTrigger to set the state of the customers. 
 * The idea is to switch between customers animations based on the position they are in from the triggers.
 */

 //TODO: Make this a singleton.
public class LineManager : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();
    
    //not meant to be used to manage customer behavior; just where they are placed within the line
    public Queue<CustomerMovement> customerPositions = new Queue<CustomerMovement>();

    private static LineManager _instance;
    public static LineManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void EnqueueCustomer(CustomerMovement c) {
        customerPositions.Enqueue(c);
        c.MoveToSpotInLine(nodes[customerPositions.Count - 1].position, customerPositions.Count - 1 == 0);
    }

    public void DequeueCustomer() {
        CustomerMovement customerWhoJustOrdered = customerPositions.Dequeue();
        customerWhoJustOrdered.RequestWaitingSeat();

        for (int i = 0; i < customerPositions.Count; i++)
        {
            //there are probably a few better ways to do this
            customerPositions.ToArray()[i].MoveToSpotInLine(nodes[i].position, i == 0);
        }
    }

    public bool LineIsEmpty() {
        return customerPositions.Count == 0;
    }
}
