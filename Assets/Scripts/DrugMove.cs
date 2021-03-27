using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugMove : MonoBehaviour
{

    Plane plane;
    bool isGrabbing;
    Transform cube;
    bool inGame = true;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up, Vector3.up);
    }

    private void FixedUpdate()
    {
        if (inGame)
        {
            if (isGrabbing)
            {
                GameManager.Instance.StartGame();
                Koma_Rotate.StartRotate();
                inGame = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Obi")
                {
                    isGrabbing = true;
                    cube = hit.transform;
                }
            }
        }


        if (!inGame)
        {
            transform.Translate(-0.5f, 0, 0);
            Koma_Rotate.StartRotate();
        }


        /*
        if (isGrabbing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            plane.Raycast(ray, out rayDistance);

            cube.position = ray.GetPoint(rayDistance);

            if (Input.GetMouseButtonUp(0))
            {
                isGrabbing = false;
            }
        }
        */

    }

}