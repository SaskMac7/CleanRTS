using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMining : MonoBehaviour
{
    public bool isCollis;
    public bool isCollisWithMob;
    public MoveMob MoveMob;
    public bool permissToMining;

    public GameObject Castle;
    public GameObject Mob;
    //public Mob Mob;
    void Start()
    {
        
    }

    void Update()
    {
        //Other в данном случае определ€ет какие-либо
        //¬роде как эту логику и не совсем в MoveMob стоит запихивать, и тут на долго оставл€ть тоже не стоит
        //Debug.Log(Mob.isSelectOther);
        Debug.Log(isCollisWithMob);
        if (isCollisWithMob == true)
        {
            MoveMob.rb.velocity = new Vector3(0, 0, 0);
            permissToMining = true;
        }

        if (permissToMining == true)
        {
            MoveMob.Move(Castle.transform.position, Mob.transform.position);
        }
    }

    void MoveToCastleAndBack()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mouse")
        {
            isCollis = true;
        }

/*        if (other.gameObject.tag == "Mob")
        {
            isCollisWithMob = true;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mouse")
        {
            isCollis = false;
        }
    }

    //’ах, непон€тно куда засунуть эту коллизию, и моб может контактировать с разными объектами, и шахта с разными существами
/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            isCollisWithMob = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            isCollisWithMob = false;
        }
    }*/
}
