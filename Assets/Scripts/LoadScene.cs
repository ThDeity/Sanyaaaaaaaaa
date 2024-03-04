using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string nameOfScene) => SceneManager.LoadScene(nameOfScene);
}
