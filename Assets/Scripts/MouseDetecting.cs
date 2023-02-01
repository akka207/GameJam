using UnityEngine;
using Cinemachine;

[DisallowMultipleComponent]
public class MouseDetecting : MonoBehaviour
{
    public Camera camera;
    public LayerMask outlineMask;
    public LayerMask NPCMask;
    public float detectRad = 3f;
    public Transform player;
    public CinemachineVirtualCamera Vcam;
    public GameObject shopCam;


    GameObject outlineObject;
    CinemachineTransposer transposer;

    private void Awake()
    {
        transposer = Vcam.GetCinemachineComponent<CinemachineTransposer>();
    }
    private void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, outlineMask))
        {
            if (hit.collider.gameObject.GetComponent<Outline>() == null)
            {
                hit.collider.gameObject.AddComponent<Outline>();
                outlineObject = hit.collider.gameObject;
                outlineObject.GetComponent<Outline>().enabled = true;
            }
        }
        else if (outlineObject != null)
            if (outlineObject.GetComponent<Outline>() != null)
                Destroy(outlineObject.GetComponent<Outline>());


        //if (Physics.Raycast(ray, out hit, 100f, NPCMask))
        //{
        //}



        Collider[] hitColliders = Physics.OverlapSphere(player.position, detectRad);
        bool flag = true;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "NPC")
            {
                if (hitCollider.gameObject.name == "Trader")
                    Vcam.Follow = shopCam.transform;
                else
                    Vcam.Follow = player;
                Vcam.LookAt = hitCollider.gameObject.transform;
                transposer.m_FollowOffset = new Vector3(0, 2, -2);
                flag = false;
                break;
            }
        }
        if (flag)
        {
            Vcam.LookAt = player;
            Vcam.Follow = player;
            transposer.m_FollowOffset = new Vector3(0, 4, -4);
        }
    }
}