using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int currentLevel;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GameManager");
                gm.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {

    }

    public void Load(int scene)
    {
        Debug.Log("Loading scene " + scene);
        SceneManager.LoadScene(scene);

        currentLevel = scene;
    }

    public void LevelComplete()
    {
        GameObject.Find("Player UI").GetComponent<PlayerUI>().Congratulations(currentLevel);
    }
}
