using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;


    private Transform _t;

    // Start is called before the first frame update
    void Start()
    {
        _t = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_t)
        {
            transform.position = new Vector3(_t.position.x, _t.position.y + 5, _t.position.z - 10);
        }
    }
}
