using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This works with both the game manager and gets the triggers from positionTrigger to set the state of the customers. 
 * The idea is to switch between customers animations based on the position they are in from the triggers.
 */
public class StateManager : MonoBehaviour
{
    public List<GameObject> nodes = new List<GameObject>();

    private void Start()
    {
        GameObject[] _nodes = GetComponentsInChildren<GameObject>();
        foreach (GameObject _node in _nodes)
        {
            nodes.Add(_node);
        }
    }
    //change the name if neccessary
    public Transform GetFirstEmpty()
    {
        for(int i = nodes.Count - 1; i >= 0; i--)
        {
            if (!nodes[i].GetComponent<PositionTrigger>().isFilled)
            {
                return nodes[i].transform;
            }
        }
        return null;
    }
    public Transform GetFirstEmptyWaitingNode()
    {
        //needs to be updated.
        return null;
    }
    public void MoveCustomerToFirstEmptyNode(Customer customer)
    {
        Transform firstEmpty = GetFirstEmpty();
        if (firstEmpty == null) return;

        if (customer.currentNodeIndex < nodes.IndexOf(firstEmpty.gameObject))
        {
            customer.MoveTowards(nodes[customer.currentNodeIndex].transform);
        }
    }
}
