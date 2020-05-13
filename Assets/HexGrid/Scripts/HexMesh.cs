using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    //References
                    private Mesh hexMesh;
                    List<Vector3> vertices;
                    List<int> triangles;
                    MeshCollider meshCollider;

    


    private void Awake() 
    {
        //Mesh Render
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();

        //Mesh Collider
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        meshCollider = gameObject.AddComponent<MeshCollider>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Triangulate(HexCell[] cells)
    {
        //clear old data on rewrite
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        //Create the things anew

        for (int i = 0; i < cells.Length; i++) {
			Triangulate(cells[i]);
		}

        //read new Data
        hexMesh.vertices = vertices.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
        //update the collider
        meshCollider.sharedMesh = hexMesh;

    }

    public void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        
        for (int i = 0; i < 5; i++)
        {
            AddTriangle(
                center, 
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
        }

        AddTriangle(
            center,
            center + HexMetrics.corners[5],
            center + HexMetrics.corners[0]
        );
        
    }

    private void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }
}
