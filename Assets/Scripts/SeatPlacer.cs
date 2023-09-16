using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeatPlacer : MonoBehaviour
{
    public int price;
    public GameObject chairPrefab;

    void Update()
    {
        if (FundManager.Instance.funds <= 50) {
            GameManager.Instance.ToggleSeatPlacer();
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)&& hit.collider.CompareTag("Store Floor") && !EventSystem.current.IsPointerOverGameObject() && FundManager.Instance.funds > price)
            {
                FundManager.Instance.funds -= price;

                // Check if the clicked object has the specified tag.
                if (hit.collider.CompareTag("Store Floor"))
                {
                    // Get the world coordinates of the click point.
                    Vector3 clickPoint = hit.point;

                    Instantiate(chairPrefab, clickPoint, Quaternion.identity);
                }
            }
        }
    }
}
