using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    public CustomTile path; //
    public CustomTile wall; //
    public Tilemap tilemap;
    public List<GameObject> companions;

    void Start()
    {
        int room_count_x = 3;
        int room_count_y = 3;

        for (int x = 0; x < room_count_x; x++)
            for (int y = 0; y < room_count_y; y++)
            {
                //Fill out the paths on each chunk.
                RandomWalk(x * 16, y * 16, 8);

                //Connect each chunk with a straight path.
                if (Mathf.Clamp(x - 1, 0, room_count_x - 1) == x - 1) { DrawLine(x * 16, y * 16, (x - 1) * 16, y * 16); }
                if (Mathf.Clamp(x + 1, 0, room_count_x - 1) == x + 1) { DrawLine(x * 16, y * 16, (x + 1) * 16, y * 16); }
                if (Mathf.Clamp(y - 1, 0, room_count_y - 1) == y - 1) { DrawLine(x * 16, y * 16, x * 16, (y - 1) * 16); }
                if (Mathf.Clamp(y + 1, 0, room_count_y - 1) == y + 1) { DrawLine(x * 16, y * 16, x * 16, (y + 1) * 16); }
            }



        //Surround paths with walls.
        SurroundWalls();
        PlaceCompanions();
    }

    void RandomWalk(int sx, int sy, int range)
    {
        int x = sx;
        int y = sy;

        for (int i = 0; i < 500; i++)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), path);

            switch (Random.Range(0, 4))
            {
                case 0: { y++; break; }
                case 1: { x--; break; }
                case 2: { y--; break; }
                case 3: { x++; break; }
            }

            x = Mathf.Clamp(x, sx - range, sx + range);
            y = Mathf.Clamp(y, sy - range, sy + range);
        }
    }

    void DrawLine(int sx, int sy, int ex, int ey)
    {
        int x1 = Mathf.Min(sx, ex);
        int x2 = Mathf.Max(sx, ex);
        int y1 = Mathf.Min(sy, ey);
        int y2 = Mathf.Max(sy, ey);

        for (int x = x1; x <= x2; x++)
        {
            for (int y = y1; y <= y2; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), path);
            }
        }
    }

    void SurroundWalls()
    {
        var bounds = tilemap.localBounds;

        var minx = Mathf.RoundToInt(bounds.min.x) - 1;
        var miny = Mathf.RoundToInt(bounds.min.y) - 1;
        var maxx = Mathf.RoundToInt(bounds.max.x) + 1;
        var maxy = Mathf.RoundToInt(bounds.max.y) + 1;

        for (int x = minx; x < maxx; x++)
        {
            for (int y = miny; y < maxy; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) == null)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), wall);
                }
            }
        }
    }

    void PlaceCompanions()
    {
        var bounds = tilemap.localBounds;

        var minx = Mathf.RoundToInt(bounds.min.x);
        var miny = Mathf.RoundToInt(bounds.min.y);
        var maxx = Mathf.RoundToInt(bounds.max.x);
        var maxy = Mathf.RoundToInt(bounds.max.y);

        for (int i = 0; i < companions.Count; i++)
        {
            bool placed = false;

            while (placed == false)
            {
                int tryx = Random.Range(minx, maxx);
                int tryy = Random.Range(miny, maxy);

                if (tilemap.GetTile(new Vector3Int(tryx, tryy, 0)) == path)
                {
                    var c = Instantiate(companions[i]);
                    c.transform.position = new Vector2(tryx, tryy);
                    placed = true;
                }
            }
        }
    }
}
