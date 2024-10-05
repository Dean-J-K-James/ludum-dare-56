using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Couldnt find Unity standard Tile so had to make my own :(
[CreateAssetMenu(menuName = "Custom Tile")]
public class CustomTile : TileBase
{
    public Sprite[] sprites; //
    public Tile.ColliderType colliderType;

    /**
     * 
     */
    public override void GetTileData(Vector3Int p, ITilemap t, ref TileData d)
    {
        d.sprite = sprites[Random.Range(0, sprites.Length)];
        d.colliderType = colliderType;
    }
}
