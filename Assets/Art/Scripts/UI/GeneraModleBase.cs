using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public partial class GeneraModleBase : MonoBehaviour
{

    /// <summary>
    /// 添加CanvasGroup
    /// </summary>
    /// <param name="target">目标</param>
    /// <param name="isRaycasts">是否可接受射线</param>
    /// <param name="isIgnoreParent">是否忽略父题控制</param>
    private CanvasGroup AddCanvasGroup(GameObject target, bool isRaycasts = true, bool isIgnoreParent = false/*,bool isChild = false*/)
    {
        if (!target.GetComponent<CanvasGroup>())
        {
            target.AddComponent<CanvasGroup>();
        }

        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();

        canvasGroup.interactable = isRaycasts;
        canvasGroup.blocksRaycasts = isRaycasts;
        canvasGroup.ignoreParentGroups = isIgnoreParent;

        return canvasGroup;
    }

    /// <summary>
    /// 添加CanvasGroup
    /// </summary>
    /// <param name="cp">目标</param>
    /// <param name="isRaycasts">是否可接受射线</param>
    /// <param name="isIgnoreParent">是否忽略父题控制</param>
    private CanvasGroup AddCanvasGroup(Component cp, bool isRaycasts = true, bool isIgnoreParent = false/*,bool isChild = false*/)
    {
        GameObject target = cp.gameObject;

        if (!target.GetComponent<CanvasGroup>())
        {
            target.AddComponent<CanvasGroup>();
        }

        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();

        canvasGroup.interactable = isRaycasts;
        canvasGroup.blocksRaycasts = isRaycasts;
        canvasGroup.ignoreParentGroups = isIgnoreParent;

        return canvasGroup;
    }

    /// <summary>
    /// 显示隐藏UI
    /// </summary>
    /// <param name="target">目标</param>
    /// <param name="isShow">是否展示</param>
    /// <param name="time">缓动时长（默认0.3f）</param>
    /// <param name="isIgnoreParent">是否受父体控制</param>
    public void ShowOrHideUI(GameObject target, bool isShow, float time = 0.3f, Action<GameObject> done = null, bool isIgnoreParent = false)
    {
        CanvasGroup canvasGroup = AddCanvasGroup(target, isShow, isIgnoreParent);

        canvasGroup.DOFade(isShow ? 1 : 0, time).SetEase(Ease.InSine).OnComplete(delegate { done?.Invoke(target); });
    }

    /// <summary>
    /// 显示隐藏UI
    /// </summary>
    /// <param name="cp">目标</param>
    /// <param name="isShow">是否展示</param>
    /// <param name="time">缓动时长（默认0.3f）</param>
    /// <param name="isIgnoreParent">是否受父体控制</param>
    public void ShowOrHideUI(Component cp, bool isShow, float time = 0.3f, Action<Component> done = null, bool isIgnoreParent = false)
    {
        GameObject target = cp.gameObject;
        CanvasGroup canvasGroup = AddCanvasGroup(target, isShow, isIgnoreParent);

        canvasGroup.DOFade(isShow ? 1 : 0, time).SetEase(Ease.InSine).OnComplete(delegate { done?.Invoke(cp); });
    }

    /// <summary>
    /// 显示隐藏UI
    /// </summary>
    /// <param name="cp">目标</param>
    /// <param name="isShow">是否展示</param>
    /// <param name="time">缓动时长（默认0.3f）</param>
    /// <param name="isIgnoreParent">是否受父体控制</param>
    public void ShowOrHideUI(Component cp, float time, bool isShow, bool isRaycasts = false, bool isIgnoreParent = false)
    {
        GameObject target = cp.gameObject;
        CanvasGroup canvasGroup = AddCanvasGroup(target, isRaycasts, isIgnoreParent);

        canvasGroup.DOFade(isShow ? 1 : 0, time).SetEase(Ease.InSine);
    }

    public bool GetUIAlpha(GameObject target)
    {
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        return canvasGroup && !(canvasGroup.alpha <= 0);
    }

    public bool GetUIAlpha(Component target)
    {
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        return canvasGroup && !(canvasGroup.alpha <= 0);
    }

    /// <summary>
    /// 进度条设置
    /// </summary>
    /// <param name="slider"></param>
    /// <param name="num">进度号</param>
    /// <param name="description">描述（Tips）</param>
    /// <param name="text"></param>
    public void ProgressSet(Slider slider, float num, string description = null, Text text = null)
    {
        DOTween.To(() => slider.value, x => slider.value = x, num, 0.5f);
        if (text != null && description != null)
        {
            text.text = description;
        }
    }

    /// <summary>
    /// 显示警告
    /// </summary>
    /// <param name="currentText">当前text</param>
    /// <param name="des">描述</param>
    /// <param name="time">时长</param>
    public void ShowWarning(Text currentText, string des, float time = 1f)
    {

        currentText.color = Color.red;
        currentText.text = des;

        Sequence myWarningSeq = DOTween.Sequence();

        myWarningSeq.AppendCallback(() =>
        {
            SetActive(currentText, true);
            currentText.DOColor(Color.black, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("warningTween");
        }).AppendInterval(time).OnComplete(() =>
        {
            SetActive(currentText, false);
            DOTween.Kill("warningTween");
        });

    }

    /// <summary>
    /// 更改text内容
    /// </summary>
    /// <param name="text">目标Text</param>
    /// <param name="content">内容</param>
    public void TextTips(Text text, object content)
    {
        if (text == null)
            return;
        text.text = content.ToString();
    }
    /// <summary>
    /// 更改text内容
    /// </summary>
    /// <param name="text">目标Text</param>
    /// <param name="content">内容</param>
    public void TextTips(TMP_Text text, object content)
    {
        if (text == null)
            return;
        text.text = content.ToString();
    }

    public IEnumerator UpdateLayout(RectTransform rect)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        yield return new WaitForEndOfFrame();
        if (rect.childCount <= 0)
            yield break;
        SetAllRect(rect);
    }

    public void SetAllRect(RectTransform go)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(go);
        if (go.childCount != 0)
        {
            for (int i = 0; i < go.childCount; i++)
            {
                RectTransform rect = go.transform.GetChild(i).GetComponent<RectTransform>();
                LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
                if (rect.childCount != 0)
                {
                    SetAllRect(rect);
                }
            }
        }
    }
    /// <summary>
    /// 设置物体显示还是隐藏
    /// </summary>
    /// <param name="go">目标物体</param>
    /// <param name="active">显示状态</param>
    public void SetActive(GameObject go, bool active)
    {
        go.SetActive(active);
    }

    /// <summary>
    /// 设置物体显示还是隐藏
    /// </summary>
    /// <param name="cp">目标组件</param>
    /// <param name="active">显示状态</param>
    public void SetActive(Component cp, bool active)
    {
        cp.gameObject.SetActive(active);
    }

    /// <summary>
    /// 获取物体当前隐藏还是显示
    /// </summary>
    /// <param name="go">目标物体</param>
    /// <returns></returns>
    public bool GetActive(GameObject go)
    {
        return go.activeInHierarchy;
    }

    /// <summary>
    /// 获取物体当前隐藏还是显示
    /// </summary>
    /// <param name="cp">目标组件</param>
    /// <returns></returns>
    public bool GetActive(Component cp)
    {
        return cp.gameObject.activeInHierarchy;
    }

}

