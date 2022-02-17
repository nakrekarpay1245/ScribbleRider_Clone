using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    public GameObject meshPartPrefab;
    public GameObject wheel;

    public List<Vector3> meshPartPositions;

    float nextTimeToMousePosition = 0;
    float mousePositionRate = 0.025f;

    public static MeshCreator instance;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }
    public  void SetPoint(Vector2 mousePosition)
    {
        if (Time.time > nextTimeToMousePosition)
        {
            nextTimeToMousePosition = Time.time + mousePositionRate;

            meshPartPositions.Add(mousePosition);

            for (int i = 0; i < meshPartPositions.Count; i++)
            {
                Debug.Log("Mesh Parts : " + meshPartPositions[i]);
            }
        }
    }

    public void CreateMesh()
    {
        for (int i = 0; i < meshPartPositions.Count; i++)
        {
           GameObject currentMeshPart = Instantiate(meshPartPrefab,wheel.transform);
            currentMeshPart.transform.localPosition = new Vector3(
                meshPartPositions[i].x,
                meshPartPositions[i].y,
                wheel.transform.position.z);
        }
    }
}
