using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2FootCollider : MonoBehaviour {

    bool isFloor(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<Player2Controller>().feetContact = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<Player2Controller>().feetContact = false;
        }
    }
}
