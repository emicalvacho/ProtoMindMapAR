using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLineScript : MonoBehaviour
{
    public GameObject obj;
    private Vector3 beginPosOffset;
    private Vector3 endPosOffset;   
    private Transform dentiny;
    private LineRenderer line;
    
    void Start() 
    {
        line = obj.GetComponent<LineRenderer>();
        
        Vector3[] pos = new Vector3[line.positionCount];
        line.GetPositions(pos);

        //Get offset
        beginPosOffset = transform.position - pos[0];
        endPosOffset = transform.position - pos[1];
    }

    void Update()
    {
        Vector3 newBeginPos = transform.position + beginPosOffset;
        Vector3 newEndPos = transform.position + endPosOffset;

        //Apppy new position with offset
        line.SetPosition(0, newBeginPos);
        line.SetPosition(1, newEndPos);
    }
}
