using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderScript : MonoBehaviour {

    bool isFloor(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<PlayerController>().bodyContact = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<PlayerController>().bodyContact = false;
        }
    }
}
