using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class SceneController
{
    public enum SceneEnum
    {
        Title, WorldStageSelect, 
        World_1,
        World_2,
        World_3,
        World_4
    }

    public static void AddEvent(Action action)
    {
    }

    public static SceneEnum sceneEnum 
    {
        get => (SceneEnum)activeSceneIndex;
    }

    public static int activeSceneIndex
    {
        get => SceneManager.GetActiveScene().buildIndex;
    }

    public static string activeSceneName
    {
        get => SceneManager.GetActiveScene().name;
    }

    public static void LoadNextScene()
    {
        int buildIndex = activeSceneIndex;

        if (buildIndex != SceneManager.sceneCountInBuildSettings-1)
            SceneManager.LoadScene(buildIndex+1);
    }

    public static void LoadPrevScene()
    {
        int buildIndex = activeSceneIndex;
        if(buildIndex != 0)
            SceneManager.LoadScene(buildIndex-1);
    }

    public static void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void LoadSceneByIndex(int index)
    {
        if (index < 0)
            return;

        if (index >= SceneManager.sceneCount)
            return;
    }

}