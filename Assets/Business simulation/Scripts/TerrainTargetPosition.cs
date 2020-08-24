using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTargetPosition : MonoBehaviour
{
    public GameObject Terrain;
    public float Distance = 1000;
    public RaycastHit TargetPosition;
    public bool IsPosition;
    
    private TerrainCollider TerrainCollider;
    private RaycastHit Hit;
    private Ray Ray;
    
    private void Start()
    {
        TerrainCollider = Terrain.GetComponent<TerrainCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        IsPosition = TerrainCollider.Raycast(Ray, out TargetPosition, Distance);
    }
}
