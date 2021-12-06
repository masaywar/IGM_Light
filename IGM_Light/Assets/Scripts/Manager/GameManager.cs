using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public WorldsLoader WorldsLoader;
    public SpriteDatabaseLoader SpriteDatabase;

    [SerializeField] private Image _fadePanel;
    [SerializeField, Range(0.0f, 1.0f)] private float _fadeSpeed;

    private Coroutine _fadeCoroutine = null;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(_fadePanel.transform.parent.gameObject);
        
        SceneManager.activeSceneChanged += FadeIn;
        //StartCoroutine(fadeIn());
    }

    private void Update()
    {
        switch(SceneController.activeSceneIndex)
        {
            case 0: // Title
            #if UNITY_EDITOR
                if(Input.anyKeyDown)
                {
                    FadeOut();
                }
            #else
                if(Input.touchCount > 0)
                {
                    FadeOut();
                }
                #endif
                break;
            case 1: //World, Stage Select.
            case 2:
            case 3:
            case 4:
            case 5:
            default:
                break;
        }
    }

    private void FadeIn(Scene scene1, Scene scene2)
    {
        FadeIn();
    }

    public void FadeIn()
    {
        if(_fadePanel == null)
            return;

        _fadeCoroutine = StartCoroutine(fadeIn());
    }

    public void FadeOut()
    {
        if(_fadePanel == null)
            return;

        if(_fadeCoroutine == null)
        {
            _fadeCoroutine = StartCoroutine(fadeOut());
        }
    }

    public void FadeOut(int buildIndex)
    {
        if(_fadePanel == null)
            return;

        if(_fadeCoroutine == null)
        {
            _fadeCoroutine = StartCoroutine(fadeOut(buildIndex));
        }
    }

    public void FadeOut(string sceneName)
    {
        if(_fadePanel == null)
            return;

        if(_fadeCoroutine == null)
        {
            _fadeCoroutine = StartCoroutine(fadeOut(sceneName));
        }
    }

    private IEnumerator fadeIn()
    {
        while(_fadePanel.color.a >= 0)
        {
            _fadePanel.color -= new Color(0, 0, 0, _fadeSpeed);
            yield return new WaitForSeconds(0.02f);
        }

        _fadeCoroutine = null;
    }

    private IEnumerator fadeOut()
    {
        while(_fadePanel.color.a < 1)
        {
            _fadePanel.color += new Color(0, 0, 0, _fadeSpeed);
            yield return new WaitForSeconds(0.02f);
        }

        _fadeCoroutine = null;
        SceneController.LoadNextScene();
    }

    private IEnumerator fadeOut(int index)
    {
        while(_fadePanel.color.a < 1)
        {
            _fadePanel.color += new Color(0, 0, 0, _fadeSpeed);
            yield return new WaitForSeconds(0.02f);
        }
        _fadeCoroutine = null;
        SceneController.LoadSceneByIndex(index);
    }

    private IEnumerator fadeOut(string sceneName)
    {
        while(_fadePanel.color.a < 1)
        {
            _fadePanel.color += new Color(0, 0, 0, _fadeSpeed);
            yield return new WaitForSeconds(0.02f);
        }

        SceneController.LoadSceneByName(sceneName);
    }
}
