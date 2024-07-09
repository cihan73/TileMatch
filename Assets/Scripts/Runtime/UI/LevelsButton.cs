using DG.Tweening;
using UnityEngine;

public class LevelsButton : MonoBehaviour
{
    void OnEnable()
    {
        ClickMeAnimation();
    }

    void ClickMeAnimation()
    {
        DOTween.Sequence()
            .Append(transform.DOPunchScale(Vector3.one * .15f, .5f).SetEase(Ease.InOutExpo))
            .AppendInterval(.3f)
            .SetLoops(-1, LoopType.Restart)
            .OnKill(() =>
            {
                transform.localScale = Vector3.one;
            })
            .SetId(transform);
    }
}