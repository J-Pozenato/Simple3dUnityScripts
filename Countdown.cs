using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public string[] Messages; //3, 2, 1 Go
    public float Interval = 1f;
    private Text UIText = null;
    public Rigidbody carbody = null;
    public IEnumerator Start()
    {
        UIText = GetComponent<Text>();
        carbody.isKinematic = true;

        int messageDisplay = Messages.Length - 1;

        while (messageDisplay >= 0)
        {
            //print(Messages[messageDisplay]);
            UIText.text = Messages[messageDisplay];
            yield return new WaitForSeconds(Interval);
            messageDisplay -= 1;
        }


        carbody.isKinematic = false;


    }
}
