using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{

    static string ultimaScene = "Welcome";

    [SerializeField]
    bool circularNavigation = true;


    /// <summary>
    /// Return current scene Index.
    /// </summary>
    /// <returns>Current scene Index.</returns>
    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public int GetLastScene()
    {
        return SceneManager.sceneCountInBuildSettings - 1;
    }

    /// <summary>
    /// Navigates to the first scene
    /// </summary>
    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Navigates to the last scene
    /// </summary>
    public void LastScene()
    {
        ultimaScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(GetLastScene());
    }

    /// <summary>
    /// Navigares to next scen from current one
    /// </summary>
    public void NextScene()
    {
        ultimaScene = SceneManager.GetActiveScene().name;
        //Almacena el valor del indice de la escena actual
        int currentScene = GetCurrentScene();

        //Almacena el valor del indice de la ultima escena
        int lastScene = GetLastScene();

        //Si la escena actual No es la ultima escena
        if (currentScene < lastScene)
        {

            //Cargue la siguiente escena
            SceneManager.LoadScene(currentScene + 1);
        }
        //Si esta permitido navegar circularmente
        else if (circularNavigation)
        {
            ultimaScene = SceneManager.GetActiveScene().name;
            //Cargue la primera escena
            FirstScene();
        }
    }


    /// <summary>
    /// Navigates to Previous scene from current one.
    /// </summary>
    public void PreviousScene()
    {
        int currentScene = GetCurrentScene();

        if (currentScene > 0)
        {
            ultimaScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene - 1);
        }
    }

    public void GetScene(string escena)
    {
        try
        {
            ultimaScene = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(escena);

        }
        catch (Exception)
        {

        }

    }
    public void SceneLast()
    {
        try
        {
            SceneManager.LoadScene(ultimaScene);
        }
        catch (Exception)
        {

        }
    }
    public string getLastSceneName()
    {
        return ultimaScene;
    }

}
