/****************************************************************************
 * 2023.3 ADMIN-20230222X
 ****************************************************************************/
using Doozy.Engine.UI;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;
using HighlightPlus;
using System;
using UnityEngine.UI;

namespace QFramework.Example
{

    public partial class PromptCollectionPanel : UIElement, IController
    {
        public string valueText;

        public string endValue;

        public string valueTextC;

        public string endValueC;

        public string truString;

        private int index;

        private OperaModle operaModle;
        private void Awake()
        {
            InputEvent();
            truString = "1:1.4";
            operaModle = this.GetModel<OperaModle>();
        }
        private void PanelDiscru()
        {
            switch (operaModle.experimentType)
            {
                case OperaModle.ExperimentType.None:
                    break;
                case OperaModle.ExperimentType.One:

                    ExecuteEvents.Execute(TriggerOther.GetInstance().listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                    ExecuteEvents.Execute(TriggerOther.GetInstance().listBtns[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                    ExecuteEvents.Execute(TriggerOther.GetInstance().listBtns[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    break;
                case OperaModle.ExperimentType.Two:
                    TriggerOther.GetInstance().operaBigModles[8].SetActive(false);
                    TriggerOther.GetInstance().operaBigModles[9].SetActive(false);
                    ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                    ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                    ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    break;
                default:
                    break;
            }
        }
        private void InputEvent()
        {
            InputFieldOne.onValueChanged.AddListener(ChangedValue);
            InputFieldOne.onEndEdit.AddListener(EndValue);

            InputFieldTwo.onValueChanged.AddListener(ChangedValueC);
            InputFieldTwo.onEndEdit.AddListener(EndValueC);

            SureButton_P.onClick.AddListener(() =>
            {
                if (endValue == "1" && endValueC == "1.4")
                {
                    Text_Prochange.Show();
                    ActionKit.Sequence().Callback(() => Text_Prochange.GetComponent<TMP_Text>().text = "配比正确")
                    .Delay(seconds: 1.0f)
                    .Callback(() => this.View_001.GetComponent<UIView>().SetVisibility(false))
                    .Callback(() => this.View_002.GetComponent<UIView>().SetVisibility(true))
                    .Callback(() => this.TextChange_PI.GetComponent<TMP_Text>().text = "正在搅拌中.......")
                    .Callback(() => this.TextChange_PO.GetComponent<TMP_Text>().text = "搅拌时长50s，请耐心等待")
                    .Callback(() => StartCoroutine(ImageUpdate()))
                    .Delay(seconds: 11.0f)
                    .Callback(() => Text_Prochange.Hide())
                    .Callback(() => PanelDiscru())
                    .Callback(() => this.View_002.GetComponent<UIView>().SetVisibility(false))
                    .Start(this);
                  
                }
                else
                {
                    Text_Prochange.Show();
                }
            });
            Btn_TimeT.onClick.AddListener(() =>
            {
                index = 1;
            });
            Btn_TimeO.onClick.AddListener(() =>
            {
                index = 2;
            });
            Btn_TimeN.onClick.AddListener(() =>
            {
                index = 3;
            });
            int count = 0;
            SurBtn_PT.onClick.AddListener(() =>
            {
                print(string.Format("<color=red>{0}</color>", index + "-----------------"));
                count++;
                if (index == 3)
                {
                    this.TextChangeT.Show();
                    ActionKit.Sequence().Callback(() => this.TextChangeT.GetComponent<TMP_Text>().text = "选择时间正确")
                   .Delay(seconds: 2.0f)
                   .Callback(() => this.View_003.GetComponent<UIView>().SetVisibility(false))
                   .Callback(() => UIKit.GetPanel<ExpriMainPanel>().StepContent.Content_D.transform.DOLocalMoveY(200, 1))
                   .Start(this);
                    index++;
                   
                }
                if (index == 4)
                {
                    this.TextChange_PI.GetComponent<TMP_Text>().text = "正在固化中";
                    this.TextChange_PO.GetComponent<TMP_Text>().text = "固化时长50s,请耐心等待";
                    this.View_002.GetComponent<UIView>().SetVisibility(true);
                    ActionKit.Sequence().Callback(() => StartCoroutine(ImageUpdate()))
                   .Delay(seconds: 11.0f)
                   .Callback(() => this.View_002.GetComponent<UIView>().SetVisibility(false))
                   .Callback(() => TextChangeT.Hide())
                   .Callback(() => operaModle.isClick = true)
                   .Start(this);



                }
                else
                {
                    this.TextChangeT.Show();
                }
            });

            SurBtn_ExIt.onClick.AddListener(() =>
            {
                View_004.GetComponent<UIView>().SetVisibility(false);
                for (int i = 0; i < TriggerData.GetInstance().operaNeedClone.Count; i++)
                {
                    Destroy(TriggerData.GetInstance().operaNeedClone[i]);
                }
                UIKit.HideAllPanel();
                UIKit.ClosePanel<ExpriMainPanel>();
                UIKit.GetPanel<TittlePanel>().transform.GetChild(1).gameObject.SetActive(false);
                UIKit.GetPanel<TittlePanel>().transform.GetChild(0).gameObject.SetActive(true);
                UIKit.GetPanel<TittlePanel>().transform.GetComponent<Image>().color = new Color(247, 247, 247, 255);
               
                UIKit.OpenPanelAsync<MainMenuPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<MainMenuPanel>().AsLastSibling();
                });
               
                UIKit.OpenPanelAsync<TittlePanel>().ToAction().Start(this);
               
            });
        }
        public void Continu()
        {
            ActionKit.Sequence().Callback(() => StartCoroutine(ImageUpdate()))
                   .Delay(seconds: 11.0f)
                   .Callback(() => this.View_002.GetComponent<UIView>().SetVisibility(false))
                   .Callback(() => operaModle.isSecond = true)
                   .Start(this);

        }
        IEnumerator ImageUpdate()
        {
            float value = 0;
            while (value <= 1)
            {
                yield return new WaitForSeconds(0.1f);
                value += 0.01f;
                ImageSlider_P.fillAmount = value;
            }
        }
        private void ChangedValue(string value)
        {
            valueText = value;//将用户输入的值赋值给内部的空字符串，我们可以将其来进行后续的操作
            print("输入了" + value);

        }
        private void EndValue(string value)
        {
            endValue = value;//捕捉数据，方便后续操作
            print("最终内容" + value);
        }
        private void ChangedValueC(string value)
        {
            valueTextC = value;//将用户输入的值赋值给内部的空字符串，我们可以将其来进行后续的操作
            print("输入了" + value);
        }
        private void EndValueC(string value)
        {
            endValueC = value;//捕捉数据，方便后续操作
            print("最终内容" + value);
        }
        protected override void OnBeforeDestroy()
        {
        }

        public IArchitecture GetArchitecture()
        {
            return OperaApp.Interface;
        }
        private void OnDestroy()
        {
            operaModle = null;
        }
    }
}