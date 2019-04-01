using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransitioner : MonoBehaviour
{
    [SerializeField]
    private string sceneToTransitionTo;

    private void Start()
    {
        Transition();
    }

    public void Transition()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(sceneToTransitionTo));
    }
}