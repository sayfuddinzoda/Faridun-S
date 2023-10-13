using UnityEngine;
using UnityEngine.Events;

public sealed class Level : MonoBehaviour
{

    public event UnityAction OnLaunch;
    public event UnityAction OnFinish;

    [SerializeField] private Point _finishPoint;

    private void OnEnable()
    {
        _finishPoint.OnComplete += Finish; 
    }

    private void OnDisable()
    {
        _finishPoint.OnComplete -= Finish;
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
