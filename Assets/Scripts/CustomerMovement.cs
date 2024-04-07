using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

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
        if(destinationSeat != null)
        {
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

    IEnumerator MoveToSeatSpot(Transform chairTransform) {
        agent.isStopped = false;
        agent.updateRotation = true;
        animator.SetBool("isMoving", true);
        agent.SetDestination(chairTransform.position);

        // Wait until the NPC is close enough to the chair
        yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

        // Stop the agent and transition to sitting animation
        agent.isStopped = true;
        animator.SetBool("isMoving", false);
        animator.SetBool("isSitting", true);

        // Disable agent's control over movement and rotation
        agent.updatePosition = false;
        agent.updateRotation = false;

        // Manually adjust the NPC's position and rotation to match the chair's
        // Assume 'chairTransform' has a child named 'SitPosition' which indicates the exact sitting position and rotation
        Transform sitPosition = chairTransform.Find("SitPosition");
        // agent.transform.FindChild("SitCollider").gameObject.SetActive(true);
        // agent.GetComponent<BoxCollider>().enabled = false;
        if (sitPosition != null)
        {
            this.transform.position = new Vector3(sitPosition.position.x, 0, sitPosition.position.z);
            this.transform.rotation = sitPosition.rotation;
        } else {
            // Fallback to chair's position and rotation directly if 'SitPosition' is not set
            this.transform.position = chairTransform.position;
            this.transform.rotation = chairTransform.rotation;
        }
    }


    IEnumerator PickUpAndLeave() {
        // agent.transform.FindChild("SitCollider").gameObject.SetActive(false);
        // agent.GetComponent<BoxCollider>().enabled = true;
        agent.isStopped = false;
        agent.updateRotation = true;
        agent.updatePosition = true;
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