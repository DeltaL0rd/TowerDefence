using UnityEngine;

public class SpaceFinder : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
   public GameObject pickedObject;
    public PowerUpManager pM;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, float.MaxValue))          
            {
            
                if (hit.transform.CompareTag("Weapon"))
                {
                    if (!GameManager.isInventryItem)
                    {
                        pickedObject = hit.transform.gameObject;
                    }
                }
                else if (hit.transform.CompareTag("SpawnPoint"))
                {
                    if (pickedObject != null)
                    {
                        PlaceAble(hit.transform.gameObject);
                    }
                }
                else if(hit.transform.CompareTag("Power_0"))
                {
                    pM.ActivatePowerUp(0);
                    hit.transform.gameObject.SetActive(false);

                }
                else if (hit.transform.CompareTag("Power_1"))
                {
                    pM.ActivatePowerUp(1);
                    hit.transform.gameObject.SetActive(false);
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void PlaceAble(GameObject placeable)
    {
        if (!pickedObject.activeInHierarchy)
        {
            pickedObject.SetActive(true);
        }
        pickedObject.transform.localPosition = placeable.transform.localPosition;
        GameManager.isInventryItem = false;
    }
}
