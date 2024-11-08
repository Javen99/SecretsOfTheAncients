using UnityEngine;

public class Join : MonoBehaviour
{
    public bool Allocated;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
        Gizmos.DrawIcon(transform.position, "join.png", true);
    }
}
