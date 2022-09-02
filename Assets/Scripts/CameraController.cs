using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 mousePos;
    public float scrollWheelPos;
/*    public Camera miniMapCamera;
    [SerializeField] private LayerMask layerMask;*/

    void Update()
    {
        mousePos = Input.mousePosition;
        scrollWheelPos = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(mousePos);

        if (mousePos.x > 1665 && mousePos.y < 256 && Input.GetMouseButtonDown(0))
        {
            if(mousePos.x > 1793)
            {
                transform.position += Vector3.right * 50f * Time.deltaTime;
            }

            if (mousePos.x < 1793)
            {
                transform.position += Vector3.right * -50f * Time.deltaTime;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (transform.position.y < 15)
            {
                transform.position += Vector3.up * 20f * Time.deltaTime;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.y > 5)
            {
                transform.position += Vector3.up * -20f * Time.deltaTime;
            }
        }


        if (Input.GetKey(KeyCode.DownArrow) || mousePos.y <= 0)
        {
            transform.position += Vector3.forward * -5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) || mousePos.y >= 1080)
        {
            transform.position += Vector3.forward * 5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || mousePos.x <= 0)
        {
            transform.position += Vector3.right * -5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || mousePos.x >= 1920)
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }
    }
}
