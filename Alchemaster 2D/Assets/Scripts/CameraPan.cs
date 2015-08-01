using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

    public GameObject table;

    public bool dragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction, Color.red);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if (hits.Length > 0)
            {
                GameObject dragTarget = hits[0].transform.gameObject;
                Debug.Log(dragTarget.name);
                if (dragTarget == table)
                {
                    dragging = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            //Debug.Log("Dragging table");
            Vector3 cameraMovement = Vector3.zero;
            float distanceToScreen = Camera.main.WorldToScreenPoint(table.transform.position).z;
            Vector3 cameraDelta = new Vector3(Input.GetAxis("Mouse X"), 0f, 0f);
            cameraMovement.x -= Camera.main.ScreenToWorldPoint(cameraDelta).x;
            //cameraMovement = Camera.main.WorldToScreenPoint(cameraMovement);

            transform.position += cameraMovement;
            Debug.Log("camera moved " + cameraMovement.x + " pixels");
        }
    }
}
