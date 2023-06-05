using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class GridManager : MonoBehaviour
{
    public bool placing;

    [SerializeField] private Grid grid;
    [SerializeField] private Camera mainCam;
    [SerializeField] private TurretPreview turretPreview;
    [SerializeField] private GameObject turretPref;

    private Quaternion rotationCurrent;

    private HashSet<Vector2Int> usedTiles;

    private void Awake()
    {
        usedTiles = new HashSet<Vector2Int>();
    }

    private void Update()
    {
        if (ModeSwitcher.Instance.IsAttackMode())
            return;

            UpdateTurretPreview();
    }

    private void UpdateTurretPreview()
    {
        if (Input.GetMouseButtonDown(1))
        {
            turretPreview.transform.Rotate(Vector3.forward * 90);
        }

        rotationCurrent = turretPreview.transform.rotation;

        Vector3 worldMousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2Int currentCell = (Vector2Int)grid.WorldToCell(worldMousePos);

        turretPreview.SetPos(grid.CellToWorld((Vector3Int)currentCell) + new Vector3(0.5f, 0.5f));

        turretPreview.SetValid(!usedTiles.Contains(currentCell));

        if (Input.GetMouseButtonDown(0) && !usedTiles.Contains(currentCell)) 
        {
            PlaceTurret(currentCell);
        }
    }

    private void PlaceTurret(Vector2Int currentCell)
    {
        usedTiles.Add(currentCell);
        Instantiate(turretPref, grid.CellToWorld((Vector3Int)currentCell) + new Vector3(0.5f, 0.5f), rotationCurrent);
    }
}
