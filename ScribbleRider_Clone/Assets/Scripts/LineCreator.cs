using UnityEngine;
using System.Collections.Generic;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    private Line activeLine;

    public MeshCreator meshCreator;

    public static LineCreator instance;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab);
            activeLine = currentLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            meshCreator.CreateMesh();
            //Destroy(currentLine);
            activeLine = null;
        }

        if (activeLine != null)
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("Hit Point : " + hit.point);
                Vector3 mousePosition = hit.point;
                activeLine.UpdateLine(mousePosition);
                meshCreator.SetPoint(mousePosition);
            }
        }
    }
}
