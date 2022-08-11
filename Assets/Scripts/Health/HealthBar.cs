using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnHealthChanged += ChangeBar;
        _health.OnDie += Die;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= ChangeBar;
        _health.OnDie -= Die;
    }

    private void ChangeBar(float healthPercent) 
    {
        DOTween.To(() => _bar.fillAmount, x => _bar.fillAmount = x, healthPercent, 1);
        DOTween.To(() => _bar.color, x => _bar.color = x, _gradient.Evaluate(healthPercent), 1);
    }

    private void Die() 
    {
        transform.DOScale(0.01f, 1).SetEase(Ease.InExpo).OnComplete(()=> Destroy(gameObject));
    }
}
