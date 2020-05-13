using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HexGrid : MonoBehaviour
{

    public int width = 9;
    public int height = 9;
    public int numHexCells;
    

    private HexCell[] cells;
    

    private HexMesh hexMesh;
    [SerializeField]private HexCell hexCellPrefab;
    
    //Labels:
    public Text cellLabelPrefab;
	Canvas gridCanvas;

    // Awake gets called before any Start method! 
    private void Awake() 
    {
        //for square fields:
        numHexCells = width *height;
        cells = new HexCell[numHexCells];

        
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        drawHexGridSquare(width , height);
    }

     // Start is called before the first frame update
    void Start()
    {
        
        hexMesh.Triangulate(cells);


        
        
        
    }

    private void drawHexGridSquare(int width, int height)
    {
        for (int z = 0, i = 0 ; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell( x,  z, i++);
                
            }
        }
    }

    private void CreateCell(int x, int z, int i) 
    {
        //find worldcoordinates for this cell;
        Vector3 position;
		position.x = (x + z * 0.5f - z/2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

        //create cell
        HexCell cell = cells[i] = Instantiate<HexCell>(hexCellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);


        // create label

        Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = cell.coordinates.ToString();
    }

    



    /*
    // Update is called once per frame
    void Update()
    {
        
    } */
}
