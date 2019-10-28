using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private GameObject obj;

    public SaveObjScript saveObjScript;
    public SpawnScript spawnScript;

    public bool InitObject(){
        if (saveObjScript.ObjSelect==null){
            return false;
        }
        Debug.Log("OBJETO A ACCIONAR ES: " + saveObjScript.ObjSelect.name);
        obj = saveObjScript.ObjSelect;
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
            if(obj.name == "Cube 1"){
                Debug.Log("No se puede eliminar el nodo principal");
            }
            else{
                Destroy(obj);
                spawnScript.ContObj --;
            }
        }
        else{
            Debug.Log("No se ha seleccionado ningun objeto para eliminar.");
        }
    }
}
