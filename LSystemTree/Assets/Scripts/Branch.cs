using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Branch
{
    public Vector3 Root { get; set; }
    public Vector3 End { get; set; }


    private LineRenderer lr;

    public Branch(Vector3 root, Vector3 end)
    {
        Root = root; End = end;
        lr = (new GameObject("branch")).AddComponent<LineRenderer>();
    }

    public void Draw()
    {
        lr.shadowCastingMode = ShadowCastingMode.On;
        var branchMaterial = new Material(Shader.Find("Standard"));
        branchMaterial.SetColor("_Color", new Color(0.2169811f, 0.172272f, 0.1543432f));
        lr.material = branchMaterial;
        lr.positionCount = 2;
        Vector3[] positions = new Vector3[2];
        positions[0] = Root;
        positions[1] = End;
        lr.SetPositions(positions);
        lr.startWidth= 0.3f;
        lr.endWidth= 0.2f;
    }
}
