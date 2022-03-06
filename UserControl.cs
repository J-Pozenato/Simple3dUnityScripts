using UnityEngine;

public class UserControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 90f;
    private Transform thisTransform = null;

    // Start is called before the first frame update
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        thisTransform.position += thisTransform.forward * moveSpeed * Time.deltaTime * vert;
        thisTransform.rotation *= Quaternion.Euler(0, rotSpeed * Time.deltaTime * horz, 0);
    }
}
