using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFinder : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject pickedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, float.MaxValue))
            {
                if (hit.transform.CompareTag("SpawnPoint"))
                {
                    if (hit.transform.GetComponent<TowerPlacementStatus>().isOccupied)
                    {
                        pickedObject = hit.transform.gameObject;
                    }
                    else
                    {
                        if (pickedObject != null)
                        {
                            PlaceAble(hit.transform.gameObject);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void PlaceAble(GameObject placeable)
    {
        pickedObject.transform.localPosition = placeable.transform.localPosition;
    }
}
