using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{

    public event UnityAction OnLaunch;
    public event UnityAction OnFinish;

    [SerializeField] private Point _finishPoint;

    private void OnEnable()
    {
        _finishPoint.OnComplite += Finish; 
    }

    private void OnDisable()
    {
        _finishPoint.OnComplite -= Finish;
    }

    public void Launch() 
    {
        OnLaunch?.Invoke();
    }

    public void Finish() 
    {
        OnFinish?.Invoke();
    }

}
