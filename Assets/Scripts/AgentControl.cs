using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _camera;
    RaycastHit tempHit;
    bool goPlant=false;
    void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if(Input.GetMouseButton(0) && !goPlant)//���� ���� ������ �� ������� �����������
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out tempHit))
            {
                _agent.SetDestination(tempHit.point);
            }
        }
        else
        if (Input.GetMouseButtonDown(1) && !goPlant)//�������� � �������� �����
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out tempHit))
            {
                _agent.SetDestination(tempHit.point);
                goPlant = true;
            }
        }
        else if((Input.GetMouseButtonDown(1) || Input.GetMouseButton(0)) && goPlant)//������ �������
        {
            _agent.SetDestination(transform.position);//����������
            goPlant=false;
        }
        if(goPlant && (_agent.destination-transform.position).magnitude <= 1)
        {
            //�������� �������� � ���
            Debug.Log("Plant");
            goPlant = false;
        }

    }
}
