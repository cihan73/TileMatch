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

    void Appear()
    {
        levelPanel.SetActive(true);

        levelsContainer.DOScale(1, .28f)
            .OnStart(() => levelsContainer.localScale = Vector3.one * .5f)
            .OnComplete(() => closeButton.interactable = true)
            .SetEase(Ease.OutBack);
    }

    void DisAppear()
    {

    }
}
