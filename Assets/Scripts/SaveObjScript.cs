using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveObjScript : MonoBehaviour
{
    private GameObject objSelect;
    private GameObject objCollider;
    private GameObject objLine;

    public GameObject ObjSelect { get => objSelect; set => objSelect = value; }
    public GameObject ObjCollider { get => objCollider; set => objCollider = value; }
    public GameObject ObjLine { get => objLine; set => objLine = value; }

    void OnEnable() {
        SelectScript.OnObject += HandlerOnObject;
        DetectCollisionScript.OnColl += HandlerOnCollider;
        DragScript.OnLine += HandlerOnLine;
    }   

    void OnDisable() {
        SelectScript.OnObject -= HandlerOnObject;
        DetectCollisionScript.OnColl -= HandlerOnCollider;
        DragScript.OnLine -= HandlerOnLine;
    }

    void HandlerOnObject(GameObject obj){
        Debug.Log("OBJETO SELECCIONADO: " + obj.name);
        ObjSelect = obj;
    }

    void HandlerOnCollider(GameObject obj){
        Debug.Log("OBJETO COLISIONADOR: " + obj.name);
        ObjCollider = obj;
    }

    void HandlerOnLine(GameObject obj){
        Debug.Log("OBJETO MOVIDO: " + obj.name);
        ObjLine = obj;
    }
}
