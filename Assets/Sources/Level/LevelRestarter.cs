using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{

    [SerializeField] private Level _level;

    private void OnEnable()
    {
        _level.OnFinish += Restart;
    }

    private void OnDisable()
    {
        _level.OnFinish -= Restart;
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
