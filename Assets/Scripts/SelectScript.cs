using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectScript : MonoBehaviour
{
    public GameObject cube;
    private GameObject findObj;

    public delegate void _OnObject (GameObject obj);
    public static event _OnObject OnObject;

    private bool band;

    public void OnMouseDown()
    {
        findObj = FindInactiveObject("Canvas");
        if(findObj != null){
            if(band){
                findObj.SetActive(true);
                band = false;
            }
            else{
                findObj.SetActive(false);
                band = true;
            } 
        }
        if(OnObject != null)
            OnObject(cube);
    }

    private GameObject FindInactiveObject(string findObj){
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach(GameObject o in objs){
            if(o.name == findObj){
                return o;
            }
        }
        Debug.Log("EL OBJECTO A BUSCAR NO EXISTE");
        return null;
    }
}
