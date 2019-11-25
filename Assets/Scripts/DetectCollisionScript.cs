using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Este script esta pensado para que los nodos no
se solapen entre si entonces, si detecta una colision
se separan, funciona pero el problema que tiene es 
que al usar fisicas los nodos se empiezan a exparsir por
si solos, por ende no está implementado */

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
