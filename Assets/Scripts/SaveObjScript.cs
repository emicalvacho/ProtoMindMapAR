using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjScript : MonoBehaviour
{
    private GameObject obj;

    void OnEnable() {
        SelectScript.OnObject += HandlerOnObject;
    }   

    void OnDisable() {
        SelectScript.OnObject -= HandlerOnObject;
    }

    void HandlerOnObject(GameObject obj){
        Debug.Log("NOMBRE DEL OBJETO SETEADO: " + obj.name);
        this.obj = obj;
    }

    public GameObject getObject(){
        return obj;
    }
}
