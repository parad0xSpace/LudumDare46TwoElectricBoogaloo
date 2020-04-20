using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject ctrlCanvas;

    public void Start()
    {
        ctrlCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenControls()
    {
        ctrlCanvas.gameObject.SetActive(true);
    }

    public void CloseControls()
    {
        ctrlCanvas.gameObject.SetActive(false);
    }
}
