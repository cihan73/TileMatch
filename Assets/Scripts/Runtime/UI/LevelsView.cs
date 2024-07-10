using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsView : MonoBehaviour
{
    [SerializeField] GameObject levelPanel;
    [SerializeField] Button closeButton;
    [SerializeField] Transform levelsContainer;

    private void Awake()
    {
        CloseFast();
        UIEvents.OpenLevelsPanel += Appear;
        closeButton.onClick.AddListener(Disappear);
    }

    private void OnDestroy()
    {
        UIEvents.OpenLevelsPanel -= Appear;
        closeButton.onClick.RemoveListener(Disappear);
    }

    void Appear()
    {
        DOTween.Kill(levelsContainer);
        levelPanel.SetActive(true);

        levelsContainer.DOScale(1, .28f)
            .OnStart(() => levelsContainer.localScale = Vector3.one * .5f)
            .OnComplete(() => closeButton.interactable = true)
            .SetEase(Ease.OutBack);
    }

    void Disappear()
    {
        DOTween.Kill(levelsContainer);

        levelsContainer.DOScale(0, .28F)
            .OnStart(() => closeButton.interactable = false)
            .OnComplete(() => levelPanel.SetActive(false))
            .SetEase(Ease.InBack);
    }

    void CloseFast()
    {
        levelsContainer.localScale = Vector3.zero;
        closeButton.interactable = false;
        levelPanel.SetActive(false);
    }

}
