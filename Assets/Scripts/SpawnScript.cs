using UnityEngine;
using System.Collections;
 
public class SpawnScript : MonoBehaviour {    

    public GameObject obj;
    public int mTotalObjetos = 10;
    private GameObject[] mObjs;
    private int contObj;
    public int ContObj{get;set;}
    public bool inicio = false;
    public bool posInicial = true;

    public SaveObjScript saveObj;

    void Start () {
        mObjs = new GameObject[ mTotalObjetos ];
        contObj = 0;
        if(inicio){
            Spawn();
        }
    }
    
    private GameObject SpawnElement() 
    {
        bool selectObj = false;
        
        if(inicio){
            inicio = false;
            return confObj();
        }
        else{
            if(saveObj.ObjSelect){
                float posX = Random.Range(-2.4f,3.4f);
                float posZ = Random.Range(1.5f,-1.5f);
                return confObj(saveObj.ObjSelect.name, posX, posZ);
            }
            else{
                Debug.Log("No se ha seleccionado ningun objeto");
                return null;
            }
        }
    }    

    public GameObject confObj(string nameParent="Spawner", float posX = 0, float posZ = 0){
        GameObject objInstanciado = Instantiate(obj, new Vector3(0, 9, 0), Quaternion.identity) as GameObject;   
        objInstanciado.transform.SetParent(GameObject.Find(nameParent).transform);

        if(nameParent == "Spawner"){
            objInstanciado.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else{
            objInstanciado.transform.localScale = new Vector3(1,1,1);
            objInstanciado.transform.localPosition = new Vector3(posX, 0.09f, posZ);
            objInstanciado.transform.localRotation = Quaternion.identity;
        }
         
        ContObj ++;
        objInstanciado.name = "Cube " + ContObj;
        
        return objInstanciado;
    }

    public void Spawn(){
        if (ContObj == mTotalObjetos){
            Debug.Log("No se puede instanciar mas objetos");
        }
        else{
            SpawnElement();    
        }
    }
}