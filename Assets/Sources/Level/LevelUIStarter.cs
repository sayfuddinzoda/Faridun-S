using UnityEngine;
using UnityEngine.UI;

public class LevelUIStarter : MonoBehaviour
{

    [SerializeField] private Button _buttonStart;
    [SerializeField] private Level _level;

    private void OnEnable()
    {
        _buttonStart?.onClick.AddListener(LevelStart);
    }

    private void OnDisable()
    {
        _buttonStart?.onClick.RemoveListener(LevelStart);
    }


    private void LevelStart()
    {
        _level?.Launch();
    }

}