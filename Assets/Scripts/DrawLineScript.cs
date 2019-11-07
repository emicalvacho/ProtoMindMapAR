using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineScript : MonoBehaviour
{
    public GameObject obj;

    public void DrawLine(GameObject parent, GameObject child){
        GameObject newLineGen = Instantiate(obj);   
        newLineGen.transform.SetParent(GameObject.Find("SpawnerLine").transform);
        LineRenderer line = newLineGen.GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.SetPosition(0, parent.transform.position);
        line.SetPosition(1, child.transform.position);
    }
}

//     private void SpawnLineGenerator(Vector3[] linePoints)
//     {
//         // Create new LineHolder object.
//         GameObject newLineGen = Instantiate(lineGeneratorPrefab);
//         // Get reference to newLineGen's LineRenderer.
//         LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

//         // Set amount of LineRenderer positions = amount of line point positions.
//         lRend.positionCount = linePoints.Length;
//         // Set positions of LineRenderer using linePoints array.
//         lRend.SetPositions(linePoints);

//         // Destroy line after 5 seconds.
//         Destroy(newLineGen, 5);
//     }