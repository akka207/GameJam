using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _camera;
    private RaycastHit tempHit;
    void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out tempHit))
            {
                _agent.SetDestination(tempHit.point);
            }
        }
    }
}
