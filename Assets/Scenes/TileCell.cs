using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour
{

    [SerializeField] List<TileCell> borderOnTiles;
    [SerializeField] int needStep = 1;
    [ContextMenu("Žq‚ÌBOX‚ÉTileCell‚ð’Ç‰Á")]
    [ContextMenu("TileCell‚ÉSetRelation")]
    public void SetStep(int count)
    {
        if (count <= 0)
        {
            return;
        }
        foreach (var tile in borderOnTiles)
        {
            tile.SetStep(count - needStep);
        }
    }
    public void Setting()
    {
        var boxlist = GetComponentsInChildren<BoxCollider>();
        foreach (var box in boxlist)
        {
            box.gameObject.AddComponent<TileCell>();
        }
    }
    public void SetRelation(TileCell[] cells)
    {
        borderOnTiles.Clear();
        foreach (var cell in cells)
        {
            if (cell == this)
            {
                continue;
            }
            float distance = Vector3.Distance(cell.transform.position, this.transform.position);
            if (distance < 1.1f)
            {
                borderOnTiles.Add(cell);
            }
        }
    }

    public void SetRelationAll()
    {
        var tileCellList = GetComponentsInChildren<TileCell>();
        foreach (var cell in tileCellList)
        {
            cell.SetRelation(tileCellList);
        }
    }
}