using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionScript : MonoBehaviour
{
    public delegate void _OnColliderDetect (GameObject obj);
    public static event _OnColliderDetect OnColl;

    private void OnTriggerEnter(Collider collider) {
        Debug.Log(gameObject.name + " colisiono con " + collider.gameObject.name);

        if(gameObject != null)
            OnColl(gameObject);
    }
}
