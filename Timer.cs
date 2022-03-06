using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text myText = null;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        myText.text = timeElapsed.ToString("00");
    }
}
