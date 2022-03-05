using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        //make a background for the button

        GUI.Box(new Rect(10, 10, 100, 160), "Menu");

        //make a clickkable button, when clicked return something

        if (GUI.Button(new Rect(30, 30, 70, 30), "clickMe"))
        {
            Debug.Log("Button Click");
        }
        if (GUI.Button(new Rect(30, 30, 70, 30), "LoadLevel"))
        {
            Debug.Log("LevelLoaded");
            SceneManager.LoadScene(2);
        }
    }
}
