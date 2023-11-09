using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshExtents : MonoBehaviour
{
    [SerializeField] private MeshFilter upRoad;
    [SerializeField] private MeshFilter downRoad;
    public bool hasPrinted;
    void Start()
    {
        
    }

    void calculateMesh(Vector3 position,Vector3 point, Vector3 axis, float angle)
    {
        Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
        Vector3 vector2 = position - point;
        vector2 = quaternion * vector2;
        Debug.Log($"Position: {position + vector2 + point}");
    }
    void Update()
    {
        Vector3 upCentre = upRoad.mesh.bounds.center;
        Vector3 upExtents = upRoad.mesh.bounds.extents;
        Vector3 downCentre = downRoad.mesh.bounds.center;
        Vector3 downExtents = downRoad.mesh.bounds.extents;
        


        if (!hasPrinted)
        {

            //upRoad.gameObject.transform.RotateAround(upCentre, Vector3.up, 180);
            //downRoad.gameObject.transform.position = ;
            calculateMesh(upRoad.gameObject.transform.position, upCentre, Vector3.up, 180);
            //Debug.Log(upCentre + upRoad.gameObject.transform.position);
            //Debug.Log(upExtents + upRoad.gameObject.transform.position);
            //Debug.Log(downCentre + downRoad.gameObject.transform.position);
            //Debug.Log(downExtents + downRoad.gameObject.transform.position);
            hasPrinted = true;
        }
    }
}
