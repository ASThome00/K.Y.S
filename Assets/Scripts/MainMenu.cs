using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(240, 420, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) {
            SceneManager.LoadScene("Level");
        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
