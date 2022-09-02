using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMob : MonoBehaviour
{
    public bool isSelect;
    public Vector3 mousePos;
    //public MousePos MousePos;
    public Mob Mob;
    public GoldCounter GoldCounter;

    public GameObject MobObj;
    public GameObject MouseObj;

    public Vector3 targetVector;
    public Rigidbody rb;

    public bool permissMove;
    public bool permissToMining;
    public bool permissToMiningBack;

    public bool isCollisWithMain;
    public bool isCollisWithCastle;

    public static bool AddOneGold;

    public GameObject Castle;
    public GameObject Mine;
    void Start()
    {
        Castle = GameObject.Find("Castle");
        Mine = GameObject.Find("Mine");
        rb = GetComponent<Rigidbody>();
        //MobObj = GameObject.Find("Mob");
        //MobObj = GameObject.Find("Mouse");
    }

    void Update()
    {
        isSelect = Mob.isSelect;
        if (Input.GetMouseButtonDown(1) && isSelect == true)
        {
            mousePos = MousePos.mousePos;
            permissToMining = false;
            permissToMiningBack = false;
            permissMove = true;

        }
        if (permissMove == true)
        {
            Move(mousePos, transform.position);
        }

        if (isCollisWithMain == true)
        {
            permissMove = false;
            permissToMiningBack = false;
            permissToMining = true;
        }

        if (permissToMining == true)
        {
            Move(Castle.transform.position, transform.position);
        }

        if (isCollisWithCastle == true)
        {
            permissMove = false;
            permissToMining = false;
            permissToMiningBack = true;
        }

        if (permissToMiningBack == true)
        {
            Move(Mine.transform.position, transform.position);
        }
    }

    public void Move(Vector3 to, Vector3 from)
    {
        //to куда
        //from откуда

        targetVector = to - from;
        targetVector.Normalize();
        rb.velocity = targetVector * 5;

    }

    //Хах, непонятно куда засунуть эту коллизию, и моб может контактировать с разными объектами, и шахта с разными существами
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Main")
        {
            isCollisWithMain = true;
        }

        if (collision.gameObject.tag == "Castle")
        {
            isCollisWithCastle = true;
            AddOneGold = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Main")
        {
            isCollisWithMain = false;
        }

        if (collision.gameObject.tag == "Castle")
        {
            isCollisWithCastle = false;
            AddOneGold = false;
        }
    }
}
