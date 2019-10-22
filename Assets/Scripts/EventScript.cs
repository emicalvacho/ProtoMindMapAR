using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private GameObject obj;

    public SaveObjScript saveObjScript;
    public SpawnScript spawnScript;

    public bool InitObject(){
        if (saveObjScript.getObject()==null){
            return false;
        }
        Debug.Log("OBJETO A ACCIONAR ES: " + saveObjScript.getObject().name);
        obj = saveObjScript.getObject();
        return true;
    }
    
    public void ChangeColor(){
        if(InitObject()){
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.color = Random.ColorHSV();
        }
        else{
            Debug.Log("No se ha seleccionado ningun objeto para pintar.");
        }
    }

    public void RemoveObj(){
        if(InitObject()){
            InitObject();
            Destroy(obj);
            spawnScript.ContObj --;
        }
        else{
            Debug.Log("No se ha seleccionado ningun objeto para eliminar.");
        }
    }
}
