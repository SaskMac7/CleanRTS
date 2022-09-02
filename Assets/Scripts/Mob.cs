using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public bool isCollis;
    public bool isSelect;
    //Когда выделяешь второго моба - с первого слетает переменная.
    public static bool isSelectOther;
    private Outline outline;
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
    }

    void Update()
    {
        //Debug.Log(isSelectOther);
        if ((isCollis == true) && (Input.GetMouseButtonDown(0)))
        {
            isSelect = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSelectOther = true;
            }
            outline.OutlineWidth = 4;
        }

        if(isCollis == false && (Input.GetMouseButtonDown(0)) && isSelectOther == false)
        {
            isSelect = false;
            outline.OutlineWidth = 0;
        }

        if (isSelectOther == true)
        {
            if (isCollis == false && (Input.GetMouseButtonDown(0)))
            {
                isSelectOther = false;
            }
        }
        
        if (isSelect == true)
        {
            outline.OutlineWidth = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mouse")
        {
            isCollis = true;
            outline.OutlineWidth = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mouse")
        {
            isCollis = false;
            outline.OutlineWidth = 0;
        }
    }
}
