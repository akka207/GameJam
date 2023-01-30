using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject FOVCamera;
    private float x, y;
    [SerializeField]
    private Vector2 xRotationRange = new Vector2(90f,90f);
    public  Vector2 sensivity      = new Vector2(1f,1f);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, -y* sensivity.y, 0);
        x = Mathf.Clamp(x, xRotationRange.x, xRotationRange.y);
        FOVCamera.
transform.eulerAngles = FOVCamera.transform.eulerAngles - new Vector3(x*sensivity.x, 0, 0);

    }

}
