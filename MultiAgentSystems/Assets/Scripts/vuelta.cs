using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class vuelta : MonoBehaviour
{
    GameObject car;
    List<Vector3> carOrigs;
    Vector3 pivot;
    Matrix4x4 tm, sm, rm, prm, mem;

    float dz;
    float rotY;
    float rotYCounter;
    float rotYLimit;
    // Start is called before the first frame update
    void Start()
    {
       dz = 0;
       rotY = 0;
       rotYCounter = 0;
       rotYLimit = 0;
       car = GameObject.CreatePrimitive(PrimitiveType.Cube);
       carOrigs = car.GetComponent<MeshFilter>().mesh.vertices.ToList();
       pivot = new Vector3(0, 0, 0);
       sm = VecOps.ScaleM(0.5f, 0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        dz = 0.5f;
        rotY = 0.1f;
        rotYCounter += rotY;
        if (rotYCounter > 90) rotYCounter = 0;
        tm = VecOps.TranslateM(0,0,dz);
        rm = VecOps.RotateY(rotY);
        Matrix4x4 PN = VecOps.TranslateM(-pivot.x, -pivot.y, -pivot.z);
        Matrix4x4 PP = VecOps.TranslateM(pivot.x, pivot.y, pivot.z);
        prm = VecOps.RotateY(rotYCounter);
        Matrix4x4 pivotOperation = PN * prm * PP;
        car.GetComponent<MeshFilter>().mesh.vertices = VecOps.ApplyTransform(carOrigs, pivotOperation * tm * rm * sm).ToArray();
        mem = mem * rm * tm;
    }
}
