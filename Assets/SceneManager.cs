using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Sikp(PlayableDirector playableDirector)
    {
        playableDirector.time=23f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
