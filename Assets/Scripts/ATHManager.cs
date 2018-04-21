using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ATHManager : MonoBehaviour {

    public GameObject cursor;
    public GameObject[] prefabsCell;

    [HideInInspector]
    public GameObject cell;

    public void SelectBatiment(string type)
    {
       
        cursor.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
        switch (type)
        {
            case "residence":
                cell = Instantiate(prefabsCell[0]);
                break;
            case "industrie":
                cell = Instantiate(prefabsCell[1]);
                break;
            case "commerce":
                cell = Instantiate(prefabsCell[2]);
                break;
            case "parc":
                cell = Instantiate(prefabsCell[3]);
                break;
            default:
                cell = null;
                break;
        }
    }

    void Update()
    {
        if(cell != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cell")
                {
                    cell.transform.position = new Vector3(hit.transform.position.x, 1.5f, hit.transform.position.z);
                }
            }
            else
            {
                cell.transform.position = new Vector3(1000, transform.position.y, 1000);
            }
        }
       
    }
}
