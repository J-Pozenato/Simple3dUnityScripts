using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Text UIText = null;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        UIText.enabled = true;
        UIText.text = "Checkpoint Reached!";


    }
}



