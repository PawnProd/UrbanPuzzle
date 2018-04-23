using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject Credits;
    public bool show=false;

	public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        Destroy(MasterGameManager.Instance.gameObject);
    }
    public void Tuto()
    {
        SceneManager.LoadScene("Tuto");
    }

    public void Show()
    {
        if (show)
        {
            show = false;
            Credits.SetActive(false);
        }
        else
        {
            show = true;
            Credits.SetActive(true);
        }
    }
}
