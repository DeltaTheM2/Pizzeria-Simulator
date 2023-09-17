using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    Animator animator;
    public float speed = 3.0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        LineManager.Instance.EnqueueCustomer(this);
    }

    public void MoveToSpotInLine(Vector3 spotPos, bool isFirstInLine) {
        StartCoroutine(MoveToLineSpot(spotPos, isFirstInLine));
    }

    public void MoveToSeat(Transform pos) {
        StartCoroutine(MoveToSeatSpot(pos));
    }

    public void RequestWaitingSeat() {
        Transform destinationSeat = WaitingManager.Instance.TakeSeat();
        if (destinationSeat == null) {
            //do something IDK
        } else {
            MoveToSeat(destinationSeat);
        }
    }

    public void NotifyOrderCompleted() {
        if (agent.isOnNavMesh) {
            agent.isStopped = true;
            agent.updateRotation = true;
            agent.ResetPath();
        }
        WaitingManager.Instance.FreeSeat();
        StartCoroutine(PickUpAndLeave());
    }

    IEnumerator MoveToLineSpot(Vector3 spotPos, bool isFirstInLine) {
        agent.isStopped = false;
        agent.updateRotation = true;
        animator.SetBool("isMoving", true);
        agent.SetDestination(spotPos);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.isOnNavMesh && agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    animator.SetBool("isMoving", false);
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

    IEnumerator MoveToSeatSpot(Transform spotPos) {
        agent.isStopped = false;
        agent.updateRotation = true;
        animator.SetBool("isMoving", true);
        agent.SetDestination(spotPos.position);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.isOnNavMesh && agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    animator.SetBool("isMoving", false);
                    animator.SetBool("isSitting", true);
                    print(transform.rotation.x + " " + spotPos.transform.rotation.y + " " + spotPos.transform.rotation.z);
                    agent.updateRotation = false;
                    transform.rotation = Quaternion.Euler(transform.rotation.x, spotPos.transform.rotation.y, spotPos.transform.rotation.z);

                    break;
                }
            } else {
                yield return null;
            }
        }

        
        animator.SetBool("isSitting", true);
    }

    IEnumerator PickUpAndLeave() {
        agent.isStopped = false;
        agent.updateRotation = true;
        animator.SetBool("isMoving", true);
        animator.SetBool("isSitting", false);
        agent.SetDestination(OrderManager.Instance.pickUpSpot.position);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.isOnNavMesh && agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    animator.SetBool("isMoving", false);
                    break;
                }
            } else {
                yield return null;
            }
        }

        agent.isStopped = false;
        animator.SetBool("isMoving", true);
        animator.SetBool("isSitting", false);
        agent.SetDestination(OrderManager.Instance.exitSpot.position);

        while (true) {
            if (!agent.pathPending) {
                //if the agent is pretty close
                if (agent.isOnNavMesh && agent.remainingDistance > agent.stoppingDistance) {
                    //continue moving as normal
                    yield return null;
                } else {
                    //stop
                    animator.SetBool("isMoving", false);
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