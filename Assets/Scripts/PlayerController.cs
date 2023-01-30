using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 5f;
    public GameObject platform;
    public GameObject aimPlatform;
    public float gridSize = 3f;
    public float distToInit = 2f;
    public List<int[]> grid;
    Rigidbody rb;
    public GameObject currentPlatform;
    bool canInit = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = new Vector3(moveDir.x, 0, moveDir.z) * speed;
        if (moveDir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), rotateSpeed * Time.deltaTime);
        rb.AddForce(Physics.gravity * 10f, ForceMode.Acceleration);
        
        
        
        //if (currentPlatform && Vector3.Distance(transform.position, currentPlatform.transform.position) > distToInit)
        //if (true)
        //{
        //    aimPlatform.SetActive(true);
        //    //Vector3 spawnPos = (transform.position - currentPlatform.transform.position) + transform.position;
        //    //aimPlatform.transform.position = flat_hex_to_pixel(pixel_to_flat_hex(transform.position));
        //    //Debug.DrawLine(currentPlatform.transform.position, spawnPos);
        //    if (aimPlatform.GetComponent<AimPlatform>().col)
        //    {
        //        if (aimPlatform.GetComponent<AimPlatform>().col.tag == "Platform")
        //            canInit = false;
        //        else
        //            canInit = true;
        //    }
        //    else
        //    {
        //        canInit = true;
        //    }
        //}
        //else
        //{
        //    canInit = false;
        //    aimPlatform.SetActive(false);
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInit && currentPlatform)
        {
            Instantiate(platform, aimPlatform.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject;
        }
    }

    //Vector3 HexGridPos(Vector3 position)
    //{
    //    float alpha = Mathf.Sqrt(Mathf.Pow(gridSize / 1.5f, 2) - Mathf.Pow(gridSize / 3f, 2));

    //    //position.x += gridSize / 2;
    //    //x = (int)((position.x - position.x % gridSize) / gridSize);
    //    //position.z += alpha*Mathf.Sign(position.z);
    //    //z = (int)(x % 2 == 1 ? (position.z+2*alpha)- (position.z + 2 * alpha)%alpha:0);
    //    //z = (int)(((position.z - position.z % 2*alpha) - (x%2==1?0: alpha * Mathf.Sign(position.z))) / (2 * alpha));
    //    int column;
    //    int row;
    //    row = (int)(position.z / 0.87f);
    //    column = (int)(position.x / (gridSize + gridSize / 2));
    //    float dz = position.z - (float)row * 0.87f;
    //    float dx = position.x - (float)column * (gridSize + gridSize / 2);
    //    if (((row ^ column) & 1) == 0)
    //    {
    //        dz = 0.87f - dz;
    //    }
    //    int right = dz * (gridSize - gridSize / 2) < 0.87f * (dx - gridSize / 2) ? 1 : 0;
    //    row += (column ^ row ^ right) & 1;
    //    column += right;
    //    x = Mathf.RoundToInt(column);
    //    z = Mathf.RoundToInt(row / 2);
    //    print(x + "  " + z);
    //    //float zPos = 2 * alpha * z - alpha;
    //    return new Vector3(x * gridSize, 0, 2 * alpha - (x % 2 == 1 ? alpha : 0));
    //}
    //Vector2 pixel_to_flat_hex(Vector3 point)
    //{
    //    int q = (int)((2f / 3 * point.x) / gridSize);
    //    int r = (int)((-1f / 3 * point.x + Mathf.Sqrt(3) / 3 * point.y) / gridSize);
    //    return axial_round(new Vector2(q, r));
    //}
    //Vector3 flat_hex_to_pixel(Vector2 hex)
    //{
    //    var x = gridSize * (3f/ 2 * hex.x);
    //    var y = gridSize * (Mathf.Sqrt(3) / 2 * hex.x + Mathf.Sqrt(3) * hex.y);
    //    return new Vector3(x,0, y);
    //}
    //Vector2 axial_round(Vector2 hex)
    //{
    //    return cube_to_axial(cube_round(axial_to_cube(hex)));
    //}
    //Vector3 axial_to_cube(Vector3 hex)
    //{
    //    var q = hex.x;
    //    var r = hex.y;
    //    var s = -q - r;
    //    return new Vector3(q, r, s);
    //}
    //Vector2 cube_to_axial(Vector3 cube)
    //{ 
    //    var q = cube.x;
    //    var r = cube.y;
    //    return new Vector2(q, r);
    //}
    //Vector3 cube_round(Vector3 frac)
    //{
    //    var q = Mathf.Round(frac.x);
    //    var r = Mathf.Round(frac.y);
    //    var s = Mathf.Round(frac.z);

    //    var q_diff = Mathf.Abs(q - frac.x);
    //    var r_diff = Mathf.Abs(r - frac.y);
    //    var s_diff = Mathf.Abs(s - frac.z);

    //    if (q_diff > r_diff && q_diff > s_diff)
    //        q = -r - s;
    //    else if (r_diff > s_diff)
    //        r = -q - s;
    //    else
    //        s = -q - r;

    //    return new Vector3(q, r, s);
    //}
}