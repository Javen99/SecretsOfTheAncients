using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private int RoomCount = 5;

    [SerializeField] private int xBound = 30;
    [SerializeField] private int yBound = 30;

    [SerializeField] private List<GameObject> roomPrefabs;
    private List<GameObject> roomsInDungeon = new ();

    [SerializeField] private GameObject corridor, corner, tjunction;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        PlaceRooms();
        // Create path between room joins
        // Populate paths with transit blocks
    }

    void PlaceRooms()
    {
        for (int r = 0; r < RoomCount; r++)
        {
            GameObject thisRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
            roomsInDungeon.Add(thisRoom);

            // Ensure rooms are given adequate buffer space away from each other so they don't collide, block joins or fail to leave enough room for transit blocks
            thisRoom.transform.SetLocalPositionAndRotation(new Vector3(Random.Range(0, xBound), Random.Range(0, yBound)),
                                                           Quaternion.Euler(0, 0, transform.localRotation.z + (90 * Random.Range(0, 4))));

            // Verify that there are an even number of joins in the map (at least until TJunctions work) and replace some rooms if needed

            thisRoom.transform.SetParent(this.transform);
        }
    }

    void CreatePaths()
    {
        // Find optimal path to the nearest unallocated join on a different room, straight lines only
        // Do not create corners in the path within 1 tile of a join due to size of corner blocks

        // Unsure atm how to make this generate TJunctions tho
    }

    void BuildMapAlongPaths()
    {
        // Add tiles to path
    }

    Transform GetClosestRoom()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in roomsInDungeon)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
