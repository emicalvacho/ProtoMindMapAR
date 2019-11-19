using UnityEngine;
using System.Collections;
 
public class SpawnScript : MonoBehaviour {    

    public GameObject obj;
    public int mTotalObjetos = 10;
    private GameObject[] mObjs;
    private int contObj;
    public bool inicio = false;
    public bool posInicial = true;

    public SaveObjScript saveObj;
    public DrawLineScript drawLine;

    public int ContObj { get => contObj; set => contObj = value; }

    void Start () {
        mObjs = new GameObject[ mTotalObjetos ];
        ContObj = 0;
        if(inicio){
            Spawn();
        }
    }
    
    private GameObject SpawnElement() 
    {        
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
        objInstanciado.name = "Nodo " + ContObj;

        if(objInstanciado.name == "nodo 1"){
            Debug.Log("El primer nodo no tiene padre");
        }
        else{
            drawLine.DrawLine(objInstanciado.transform.parent.gameObject, objInstanciado);
            Debug.Log("Objeto instanciado tiene padre? " + objInstanciado.transform.parent.gameObject.name);
        }
        
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