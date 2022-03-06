using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;
    private Transform thisTransform = null;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        thisTransform.position += this.transform.forward * speed * Time.deltaTime;

    }
}
