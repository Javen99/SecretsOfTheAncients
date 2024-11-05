using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject flootTile;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon ()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(flootTile, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
}
