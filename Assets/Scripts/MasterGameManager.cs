using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterGameManager : MonoBehaviour {

    public static MasterGameManager Instance { get; private set; }

    public int numLevel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            numLevel = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        ++numLevel;
        SceneManager.LoadScene("Level" + numLevel);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level" + numLevel);
    }
}
