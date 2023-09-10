using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float speed = 3.0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    
        LineManager.Instance.EnqueueCustomer(this);
    }

    public void MoveToSpotInLine(Vector3 spotPos, bool isFirstInLine) {
        StartCoroutine(MoveToLineSpot(spotPos, isFirstInLine));
    }

    public void MoveToSeat(Vector3 pos) {
        StartCoroutine(MoveToSeatSpot(pos));
    }

    public void RequestWaitingSeat() {
        Transform destinationSeat = WaitingManager.Instance.TakeSeat();
        if (destinationSeat == null) {
            //do something IDK
        } else {
            MoveToSeat(destinationSeat.position);
        }
    }

    public void NotifyOrderCompleted() {
        WaitingManager.Instance.FreeSeat();
        StartCoroutine(PickUpAndLeave());
    }

    IEnumerator MoveToLineSpot(Vector3 spotPos, bool isFirstInLine) {
        agent.isStopped = false;
        agent.SetDestination(spotPos);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    break;
                }
            } else {
                yield return null;
            }
        }

        agent.isStopped = true;

        if (isFirstInLine) {
            OrderManager.Instance.TakeOrder();
        }
    }

    IEnumerator MoveToSeatSpot(Vector3 spotPos) {
        agent.isStopped = false;
        agent.SetDestination(spotPos);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    break;
                }
            } else {
                yield return null;
            }
        }
    }

    IEnumerator PickUpAndLeave() {
        agent.isStopped = false;
        agent.SetDestination(OrderManager.Instance.pickUpSpot.position);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    break;
                }
            } else {
                yield return null;
            }
        }

        agent.isStopped = false;
        agent.SetDestination(OrderManager.Instance.exitSpot.position);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    break;
                }
            } else {
                yield return null;
            }
        }

        DayManager.Instance.OnCustomerCompleted(this);
        Destroy(this.gameObject);
    }
}