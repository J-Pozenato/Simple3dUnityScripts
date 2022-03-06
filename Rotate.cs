using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotSpeed = 90f;
    private Transform thisTransform = null;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        thisTransform.rotation *= Quaternion.Euler(0f, rotSpeed * Time.deltaTime, 0f);
    }
}
