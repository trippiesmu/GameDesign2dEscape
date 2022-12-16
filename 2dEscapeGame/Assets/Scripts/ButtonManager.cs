using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public AudioSource ButtonSound; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        ButtonSound.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        ButtonSound.Play();
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        ButtonSound.Play();
    }
}
