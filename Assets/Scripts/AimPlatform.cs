using UnityEngine;

public class AimPlatform : MonoBehaviour
{
    public GameObject col;


    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.up,out hit))
        {
            col = hit.collider.gameObject;
        }
    }
}
