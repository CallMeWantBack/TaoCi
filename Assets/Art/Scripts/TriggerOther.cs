using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Example;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;
using HighlightPlus;
using System;
using System.IO;
using LitJson;
using System.Text.RegularExpressions;

[System.Serializable]
public class Root
{
    //实验步骤
    public string Steps;

    //开始时间
    public string StartTime;

    //结束时间
    public string EndTime;

    //实验用时
    public string TotalTime;

    //实验成绩
    public string Grade;

    //实验总分
    public string TotaGrade;
}
[System.Serializable]
public class RootList
{
    public int ID;//定义一个int类型的ID
    public string Name;//定义一个string类型Name
    public Root roots;

}
public class TriggerOther : MonoBehaviour, IController
{

    private static TriggerOther _instance;
    public static TriggerOther GetInstance()
    {
        if (_instance == null)
            _instance = new TriggerOther();
        return _instance;
    }
    [Header("单模的触发模型")]
    public List<GameObject> OperationModel;
    [Header("多模的触发模型")]
    public List<GameObject> operaBigModles;
    [Header("单模步骤一所需模型")]
    public List<GameObject> StepOneModle;
    [Header("单模步骤二所需模型")]
    public List<GameObject> StepTwoModle;
    [Header("单模步骤三所需模型")]
    public List<GameObject> StepThreeModle;
    [Header("单模步骤四所需模型")]
    public List<GameObject> StepFourModle;
    [Header("单模步骤五所需模型")]
    public List<GameObject> StepFiveModle;
    [Header("单模步骤六所需模型")]
    public List<GameObject> StepSixModle;
    [Header("单模步骤七所需模型")]
    public List<GameObject> StepSevenModle;
    [Header("单模步骤八所需模型")]
    public List<GameObject> StepEightModle;



    [Header("多模步骤一所需模型")]
    public List<GameObject> StepOneModleDuo;
    [Header("多模步骤二所需模型")]
    public List<GameObject> StepTwoModleDuo;
    [Header("多模步骤三所需模型")]
    public List<GameObject> StepThreeModleDuo;
    [Header("多模步骤四所需模型")]
    public List<GameObject> StepFourModleDuo;
    [Header("多模步骤五所需模型")]
    public List<GameObject> StepFiveModleDuo;
    [Header("多模步骤六所需模型")]
    public List<GameObject> StepSixModleDuo;
    [Header("多模步骤七所需模型")]
    public List<GameObject> StepSevenModleDuo;
    [Header("多模步骤八所需模型")]
    public List<GameObject> StepEightModleDuo;
    [Header("多模步骤九所需模型")]
    public List<GameObject> StepNightModleDuo;
    [Header("多模步骤十所需模型")]
    public List<GameObject> StepTengModleDuo;
    [Header("多模步骤十一所需模型")]
    public List<GameObject> StepTentingOneModleDuo;
    [Header("多模步骤十二所需模型")]
    public List<GameObject> StepTentingTwoModleDuo;
    private OperaModle operaModle;
    public GameObject nowGameobject;
    [Header("单模的模型UI")]
    public List<GameObject> operatemodle;
    [Header("单模的步骤按钮")]
    public List<GameObject> listBtns;
    [Header("多模的点击按钮")]
    public List<GameObject> btnoperModles;

    public List<RootList> rootLists;


    void Start()
    {
        operaModle = this.GetModel<OperaModle>();
        _instance = this;


    }

    public void HideOperaTion()
    {
        for (int i = 0; i < OperationModel.Count; i++)
        {
            OperationModel[i].SetActive(false);

        }
    }
    public void SetView()
    {
        UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(false);
        UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true);
    }

    private void OnDestroy()
    {
        operaModle = null;
    }
    public IArchitecture GetArchitecture()
    {
        return OperaApp.Interface;
    }

    private void Update()
    {


    }

    public void OnTriggerEnter(Collider collider)
    {
        switch (operaModle.experimentType)
        {
            case OperaModle.ExperimentType.None:
                break;
            case OperaModle.ExperimentType.One:
                print(collider.name);
                if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                {
                    if (collider.name == "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                    {
                    }
                    else
                    {
                        if (collider.name != "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {

                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                           .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                           .Callback(() => SetView())
                           .Delay(seconds: 2.0f)
                           .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                           .Callback(() => SetView())
                           .Start(monoBehaviour: this, onFinish: _ =>
                           {

                           });
                        }
                    }
                    if (collider.name == "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                    {
                        nowGameobject = OperationModel[0];
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------脱模剂----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => nowGameobject.SetActive(true))
                        .Callback(() => operatemodle[1].SetActive(false))
                        .Delay(seconds: 2.0f)
                        .Callback(() => ExecuteEvents.Execute(listBtns[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Callback(() => UIKit.GetPanel<ExpriMainPanel>().StepContent.Content_D.transform.DOLocalMoveY(50, 1))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            if (nowGameobject != null)
                            {
                                nowGameobject.SetActive(false);
                            }

                            print(string.Format("<color=Green>{0}</color>", operaModle.grade));
                            operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                            print("-----------------" + operaModle.operaNum);


                        });

                    }
                    else
                    {
                        if (collider.name != "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择脱模剂,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }



                    }
                    if (collider.name == "NiBa(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[1];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥巴----------------"))
                       .Delay(seconds: 1.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[2].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀，拖拽至场景中")
                       .Callback(() => SetView())
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           print(string.Format("<color=Green>{0}</color>", operaModle.grade));
                           operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                           operaModle.operaNum = OperaModle.OperaStateID.MuDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "NiBa(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥巴,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                            print(operaModle.grade);
                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                    {
                        nowGameobject = OperationModel[2];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[3].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => OperationModel[1].SetActive(false))
                      .Callback(() => OperationModel[16].SetActive(true))
                      .Delay(seconds: 3.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.RuanBang;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "RuanBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.RuanBang)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[3];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------软板----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[4].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => nowGameobject.SetActive(false))
                      .Callback(() => OperationModel[17].gameObject.SetActive(true))
                      .Delay(seconds: 1.0f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择绳子，拖拽至场景中")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(false))
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.ShengZi;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {

                        if (collider.name != "RuanBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.RuanBang)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择软板,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });

                        }

                    }
                    if (collider.name == "ShengZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                    {
                        nowGameobject = OperationModel[4];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------软板----------------"))
                      .Condition(() => operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[5].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.Water;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "ShengZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择绳子,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[5];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------水----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[6].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 1.0f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉，拖拽至场景中")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(false))
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {

                          operaModle.operaNum = OperaModle.OperaStateID.ShiGaoFen;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择水,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });


                        }

                    }
                    if (collider.name == "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                    {
                        nowGameobject = OperationModel[6];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------石膏粉----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[7].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                               OperationModel[5].SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                    {

                        nowGameobject = OperationModel[7];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------备制石膏----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[8].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 1.2f)
                       .Callback(() => OperationModel[25].SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => nowGameobject.SetActive(false))
                       .Callback(() => OperationModel[25].SetActive(false))
                       .Condition(() => operaModle.experimentState == OperaModle.ExperimentState.Practise)
                       .Callback(() => OperationModel[4].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击绳子，拆除绳子")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => OperationModel[17].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击围板，拆除围板")
                       .Callback(() => SetView())
                       .Callback(() => OperationModel[17].GetComponent<MeshCollider>().enabled = true)
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => ExecuteEvents.Execute(listBtns[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                           print("-----------------" + operaModle.operaNum);
                           OperationModel[22].gameObject.SetActive(true);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     .Callback(() => SetView())
                                     .Delay(seconds: 2.0f)
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     .Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }

                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                    {
                        nowGameobject = OperationModel[8];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                          print("-----------------" + operaModle.operaNum);

                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "MuDaoOne(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                    {
                        nowGameobject = OperationModel[9];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------木刀1----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => OperationModel[20].SetActive(true))
                       .Condition(() => operaModle.experimentState == OperaModle.ExperimentState.Practise)
                       .Callback(() => OperationModel[20].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击石膏模具以显示")
                       .Callback(() => SetView())
                       .Callback(() => OperationModel[22].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(false))
                       .Callback(() => operaModle.isModelClickThree = true)
                       .Condition(() => operaModle.isModelClickThree == false)
                       .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().StepContent.Content_D.transform.DOLocalMoveY(100, 1))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "MuDaoOne(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "ChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                    {

                        nowGameobject = OperationModel[10];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------泥浆----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Callback(() => nowGameobject.GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => nowGameobject.GetComponent<Animation>().Play())
                      .Delay(seconds: 1.7f)
                      .Callback(() => OperationModel[26].SetActive(true))
                      .Delay(seconds: 2.217f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(true))
                      .Callback(() => operatemodle[11].SetActive(false))
                      .Callback(() => nowGameobject.GetComponent<Animation>().playAutomatically = false)
                      .Callback(() => nowGameobject.GetComponent<Animation>().Stop())
                      //.Callback(() => nowGameobject.SetActive(false))
                      .Callback(() => nowGameobject.transform.localEulerAngles = new Vector3(-90, 60, -132))
                      .Callback(() => nowGameobject.transform.localPosition = new Vector3(0.966f, 1.041f, -0.3180785f))
                      .Callback(() => OperationModel[26].SetActive(false))
                      .Callback(() => OperationModel[19].SetActive(true))
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PI.GetComponent<TMP_Text>().text = "泥浆成型中")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PO.GetComponent<TMP_Text>().text = "时长约为:1:30min")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.Continu())
                      .Delay(seconds: 11.0f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击石膏模,将内部泥浆倒出")
                      .Callback(() => SetView())
                      .Callback(() => operaModle.isModelClickFour = true)
                      .Condition(() => operaModle.isModelClickFour == false)
                      .Callback(() => OperationModel[18].SetActive(true))
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击胚体,获得成型胚体")
                      .Callback(() => SetView())
                      .Callback(() => OperationModel[4].SetActive(false))
                      .Callback(() => OperationModel[24].SetActive(false))
                      .Callback(() => operaModle.isModelClickFive = true)
                      .Condition(() => operaModle.isModelClickFive == false)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.NullState;
                          print("-----------------" + operaModle.operaNum);
                          OperationModel[22].gameObject.SetActive(false);
                          print(string.Format("<color=Yellow>{0}</color>", operaModle.grade));

                      });
                    }
                }
                if (operaModle.experimentState == OperaModle.ExperimentState.Examine)
                {
                    if (collider.name == "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                    {
                    }
                    else
                    {
                        if (collider.name != "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {

                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                           //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                           //.Callback(() => SetView())
                           //.Delay(seconds: 2.0f)
                           //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                           //.Callback(() => SetView())
                           .Start(monoBehaviour: this, onFinish: _ =>
                           {

                           });
                        }
                    }
                    if (collider.name == "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                    {
                        nowGameobject = OperationModel[0];
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------脱模剂----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => nowGameobject.SetActive(true))
                        .Callback(() => operatemodle[1].SetActive(false))
                        .Delay(seconds: 2.0f)
                        .Callback(() => ExecuteEvents.Execute(listBtns[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Callback(() => UIKit.GetPanel<ExpriMainPanel>().StepContent.Content_D.transform.DOLocalMoveY(50, 1))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            if (nowGameobject != null)
                            {
                                nowGameobject.SetActive(false);
                            }
                            this.SendCommand<DanGradeCommand>();
                          
                            operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                            print(string.Format("<color=Green>{0}</color>", operaModle.grade));


                        });
                        Root rootMoZhong = new Root();
                        rootMoZhong.Steps = TriggerEvent.Instance.step;
                        rootMoZhong.StartTime = TriggerEvent.Instance.startTime;
                        rootMoZhong.EndTime = System.DateTime.Now.ToString();
                        print(string.Format("<color=Green>{0}</color>", rootMoZhong.Steps + "-------" + rootMoZhong.StartTime + "----------" + rootMoZhong.EndTime));
                        int totatime = GetSubSeconds(DateTime.Parse(rootMoZhong.StartTime), DateTime.Parse(rootMoZhong.EndTime));
                        print(string.Format("<color=Green>{0}</color>", totatime));
                        rootMoZhong.TotalTime = totatime.ToString();
                        rootMoZhong.Grade = operaModle.grade.ToString();
                        rootMoZhong.TotaGrade = "10";
                        print(string.Format("<color=Green>{0}</color>", operaModle.grade));                    
                        RootList rootListData = new RootList();
                        rootListData.roots = rootMoZhong;
                        rootLists.Add(rootListData);
                        string file = rootLists.ToString();
                        SaveJson();
                        print(string.Format("<color=Orange>{0}</color>", file));
                    }
                    else
                    {
                        if (collider.name != "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                        {
                            this.SendCommand<YiGradeCommand>();
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择脱模剂,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "NiBa(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[1];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥巴----------------"))
                       .Delay(seconds: 1.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[2].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           print(string.Format("<color=Green>{0}</color>", operaModle.grade));
                           operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                           operaModle.operaNum = OperaModle.OperaStateID.MuDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "NiBa(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥巴,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                            print(operaModle.grade);
                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                    {
                        nowGameobject = OperationModel[2];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[3].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => OperationModel[1].SetActive(false))
                      .Callback(() => OperationModel[16].SetActive(true))
                      .Delay(seconds: 3.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.RuanBang;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "RuanBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.RuanBang)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[3];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------软板----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[4].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => nowGameobject.SetActive(false))
                      .Callback(() => OperationModel[17].gameObject.SetActive(true))
                      .Delay(seconds: 1.0f)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.ShengZi;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {

                        if (collider.name != "RuanBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.RuanBang)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择软板,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });

                        }

                    }
                    if (collider.name == "ShengZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                    {
                        nowGameobject = OperationModel[4];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------软板----------------"))
                      .Condition(() => operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[5].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.Water;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "ShengZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择绳子,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                    {
                        operaModle.grade += 5;
                        nowGameobject = OperationModel[5];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------水----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => operatemodle[6].SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 1.0f)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {

                          operaModle.operaNum = OperaModle.OperaStateID.ShiGaoFen;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择水,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });


                        }

                    }
                    if (collider.name == "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                    {
                        nowGameobject = OperationModel[6];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------石膏粉----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[7].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                               OperationModel[5].SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                    {
                        nowGameobject = OperationModel[7];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------备制石膏----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => operatemodle[8].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 1.2f)
                       .Callback(() => OperationModel[25].SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => nowGameobject.SetActive(false))
                       .Callback(() => OperationModel[25].SetActive(false))
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => OperationModel[17].GetComponent<MeshCollider>().enabled = true)
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => ExecuteEvents.Execute(listBtns[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                           print("-----------------" + operaModle.operaNum);
                           OperationModel[22].gameObject.SetActive(true);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     //.Callback(() => SetView())
                                     //.Delay(seconds: 2.0f)
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     //.Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }

                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                    {
                        nowGameobject = OperationModel[8];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Delay(seconds: 2.0f)
                      .Callback(() => ExecuteEvents.Execute(listBtns[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                          print("-----------------" + operaModle.operaNum);

                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "MuDaoOne(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                    {
                        nowGameobject = OperationModel[9];
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------木刀1----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => nowGameobject.SetActive(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => OperationModel[20].SetActive(true))
                       .Callback(() => OperationModel[22].SetActive(false))
                       .Callback(() => nowGameobject.SetActive(false))
                       .Callback(() => operaModle.isModelClickThree = true)
                       .Condition(() => operaModle.isModelClickThree == false)
                       .Callback(() => ExecuteEvents.Execute(listBtns[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(listBtns[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "MuDaoOne(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "ChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                    {


                        nowGameobject = OperationModel[10];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------泥浆----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => nowGameobject.SetActive(true))
                      .Callback(() => nowGameobject.GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => nowGameobject.GetComponent<Animation>().Play())
                      .Delay(seconds: 1.7f)
                      .Callback(() => OperationModel[26].SetActive(true))
                      .Delay(seconds: 2.217f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(true))
                      .Callback(() => operatemodle[11].SetActive(false))
                      .Callback(() => nowGameobject.GetComponent<Animation>().playAutomatically = false)
                      .Callback(() => nowGameobject.GetComponent<Animation>().Stop())
                      .Callback(() => nowGameobject.transform.localEulerAngles = new Vector3(-90, 60, -132))
                      .Callback(() => nowGameobject.transform.localPosition = new Vector3(0.966f, 1.041f, -0.3180785f))
                      .Callback(() => OperationModel[26].SetActive(false))
                      .Callback(() => OperationModel[19].SetActive(true))
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PI.GetComponent<TMP_Text>().text = "泥浆成型中")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PO.GetComponent<TMP_Text>().text = "时长约为:1:30min")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.Continu())
                      .Delay(seconds: 11.0f)
                      .Callback(() => operaModle.isModelClickFour = true)
                      .Condition(() => operaModle.isModelClickFour == false)
                      .Callback(() => OperationModel[18].SetActive(true))
                      .Callback(() => OperationModel[4].SetActive(false))
                      .Callback(() => OperationModel[24].SetActive(false))
                      .Callback(() => operaModle.isModelClickFive = true)
                      .Condition(() => operaModle.isModelClickFive == false)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChang_Eexit.GetComponent<TMP_Text>().text = "对称型（单块模）")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChangeT_exit.GetComponent<TMP_Text>().text
                       = "当前对称型（单块模）实验已完成，再次进入会重新开始实验”确认考核界面")
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_004.GetComponent<UIView>().SetVisibility(true))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.NullState;
                          print("-----------------" + operaModle.operaNum);
                          OperationModel[22].gameObject.SetActive(false);
                          print(string.Format("<color=Yellow>{0}</color>", operaModle.grade));

                      });
                    }
                    else
                    {

                        if (collider.name != "ChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                }
                break;
            case OperaModle.ExperimentType.Two:
               
                if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                {
                    print(string.Format("<color=Yellow>{0}</color>", collider.name + "-----------------") + operaModle.operaNum);
                    if (collider.name == "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                    {
                    }
                    else
                    {
                        if (collider.name != "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {

                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                           .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                           .Callback(() => SetView())
                           .Delay(seconds: 2.0f)
                           .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                           .Callback(() => SetView())
                           .Start(monoBehaviour: this, onFinish: _ =>
                           {

                           });
                        }
                    }
                    if (collider.name == "ZhuJiang_KouZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ZhuJiangKou)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------注浆口----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.gameObject.transform.position = new Vector3(0, 0, 0))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 1.0f)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {

                            operaModle.operaNum = OperaModle.OperaStateID.TuoMoJi;
                            print("-----------------" + operaModle.operaNum);
                        });
                    }
                    else
                    {
                        if (collider.name != "ZhuJiang_KouZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ZhuJiangKou)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择注浆口,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------脱模剂----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.gameObject.transform.position = new Vector3(0, 0, 0))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 2.0f)
                        .Callback(() => operaBigModles[11].SetActive(false))
                        .Delay(seconds: 2.0f)
                        .Callback(() => operaBigModles[24].GetComponent<HighlightEffect>().highlighted = true)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            operaModle.operaNum = OperaModle.OperaStateID.Line;
                            print("-----------------" + operaModle.operaNum);


                        });

                    }
                    else
                    {
                        if (collider.name != "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择脱模剂,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "pen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Line)
                    {
                        collider.gameObject.SetActive(false);
                        ActionKit.Sequence()
                             .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                             .Callback(() => SetView())
                             .Delay(seconds: 2.0f)
                             .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择正确的裁缝线")
                             .Callback(() => SetView())
                             .Start(monoBehaviour: this, onFinish: _ =>
                             {

                             });
                    }
                    if (collider.name == "pen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.QiangBi)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------铅笔----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 2.0f)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            operaBigModles[1].SetActive(false);
                            operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                            print("-----------------" + operaModle.operaNum);
                        });
                    }
                    if (collider.name == "NiBaDuo(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                    {
                        operaModle.grade += 5;
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥巴----------------"))
                       .Delay(seconds: 1.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Delay(seconds: 3.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀，拖拽至场景中")
                       .Callback(() => SetView())
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {

                           operaModle.operaNum = OperaModle.OperaStateID.MuDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "NiBaDuo(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥巴,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                            print(operaModle.grade);
                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                    {
                        nowGameobject = operaBigModles[12];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Play())
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = false)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Stop())
                      .Callback(() => nowGameobject.SetActive(false))
                      .Callback(() => operaBigModles[16].SetActive(true))
                      .Callback(() => operaBigModles[10].SetActive(false))
                      .Delay(seconds: 3.0f)
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.YaKeLIBang;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "YaKeLiBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.YaKeLIBang)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------亚克力板----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[13].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[13].GetComponent<Animation>().Play())
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择固定金属，拖拽至场景中")
                      .Callback(() => SetView())
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.GuDingJingShu;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {

                        if (collider.name != "YaKeLiBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.YaKeLIBang)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择亚克力板,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "GuDingJingShu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuDingJingShu)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------固定金属----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => operaBigModles[14].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[14].GetComponent<Animation>().Play())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           operaModle.operaNum = OperaModle.OperaStateID.Water;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "GuDingJingShu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择固定金属,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------水----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉，拖拽至场景中")
                      .Callback(() => SetView())
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {

                          operaModle.operaNum = OperaModle.OperaStateID.ShiGaoFen;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择水,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });


                        }

                    }
                    if (collider.name == "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------石膏粉----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------备制石膏----------------"))
                       .Delay(seconds: 2.0f)
                       //倒入石膏 动画需添加
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 1.0f)
                       .Callback(() => operaBigModles[27].SetActive(true))
                       .Callback(() => operaBigModles[18].SetActive(true))
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().playAutomatically=true)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().Play())
                       .Callback(() => operaBigModles[19].SetActive(true))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaBigModles[27].SetActive(false))
                       .Callback(() => operaBigModles[13].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击亚克力板，拆除围板")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => operaBigModles[14].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击固定金属，拆除金属")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     .Callback(() => SetView())
                                     .Delay(seconds: 2.0f)
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     .Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }
                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().Play("GuaDaoDuo"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[6].SetActive(false))
                      .Callback(() => operaBigModles[19].SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Callback(() => operaBigModles[13].SetActive(true))
                      .Callback(() => operaBigModles[14].SetActive(true))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[19].transform.eulerAngles = new Vector3(90, 0, 0);
                          operaBigModles[19].SetActive(true);
                          operaBigModles[6].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[6].GetComponent<Animation>().Stop();
                          operaModle.operaNum = OperaModle.OperaStateID.OtherShiGao;
                          print("-----------------" + operaModle.operaNum);
                        //  operaBigModles[18].SetActive(false);
                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.OtherShiGao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------倒入另一侧石膏----------------"))
                       .Delay(seconds: 2.0f)
                       //倒入石膏 动画需添加
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => operaBigModles[18].SetActive(true))
                       .Delay(seconds: 1.0f)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().Play())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaBigModles[13].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击亚克力板，拆除围板")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => operaBigModles[14].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击固定金属，拆除金属")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaBigModles[20].SetActive(true))
                       .Callback(() => operaBigModles[16].SetActive(false))
                       .Callback(() => operaBigModles[18].SetActive(false))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[9], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[9], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaBigModles[19].SetActive(false);
                           operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.OtherShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     .Callback(() => SetView())
                                     .Delay(seconds: 2.0f)
                                     .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     .Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀扣洞----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Play("MuDaoDuoOne"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[10].SetActive(false))
                      .Callback(() => operaBigModles[10].SetActive(false))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀，拖拽至场景中")
                       .Callback(() => SetView())
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[10].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[10].GetComponent<Animation>().Stop();
                          operaBigModles[20].SetActive(false);
                          operaBigModles[21].SetActive(true);
                          operaModle.operaNum = OperaModle.OperaStateID.GuaDao1;

                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao1)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().Play("GuaDaoDuoOne"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 3.0f)
                      .Callback(() => operaBigModles[6].SetActive(false))
                      .Callback(() => operaBigModles[19].SetActive(false))
                      .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木锤，拖拽至场景中")
                       .Callback(() => SetView())
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[6].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[6].GetComponent<Animation>().Stop();
                          operaBigModles[19].SetActive(false);
                          operaBigModles[26].SetActive(false); 
                          operaBigModles[21].transform.localEulerAngles = new Vector3(-180, -180, 270);
                          operaBigModles[21].transform.localPosition = new Vector3(0, 1.1f, 0);
                          operaBigModles[0].transform.localEulerAngles = new Vector3(270, 180, 180);
                          operaBigModles[0].transform.localPosition = new Vector3(0, 1, 0);

                          operaModle.operaNum = OperaModle.OperaStateID.MuChui;
                          print("-----------------" + operaModle.operaNum);

                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao1)
                        {
                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                                      .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                    {

                        ActionKit.Sequence()
                       .Callback(() => print("----------------------木锤----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[0].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => operaBigModles[0].GetComponent<MeshCollider>().enabled = true)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>()["MoJu"].speed = 1.0f)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu"))
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu"))
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().Play())
                       .Callback(() => operaBigModles[5].SetActive(false))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,将模种取出")
                       .Callback(() => SetView())
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.TangLiDai;
                           print("-----------------" + operaModle.operaNum);

                       });
                    }
                    else
                    {
                        if (collider.name != "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木锤,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "TanLiDai(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TangLiDai)
                    {

                        ActionKit.Sequence()
                       .Callback(() => print("----------------------弹力带----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                       .Callback(()=>SetView())
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaBigModles[21].GetComponent<Animation>().playAutomatically = false;
                           operaBigModles[21].GetComponent<Animation>().Stop();
                           operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                           print("-----------------" + operaModle.operaNum);

                       });
                    }
                    else
                    {
                        if (collider.name != "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "ChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥浆----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.8f)
                       .Callback(() => operaBigModles[28].SetActive(true))
                       .Delay(seconds:2.0f)
                       .Callback(() => operaBigModles[28].SetActive(false))
                      // .Callback(() => operaBigModles[3].SetActive(false))
                       .Callback(() => operaBigModles[3].transform.localEulerAngles = new Vector3(270, -360, 90))
                       .Callback(() => operaBigModles[3].transform.localPosition = new Vector3(-0.891f, 1.041f, -0.01f))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(true))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PI.GetComponent<TMP_Text>().text = "泥浆成型中")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PO.GetComponent<TMP_Text>().text = "时长约为:1:30min")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.Continu())
                       .Delay(seconds: 11.0f)
                       .Callback(() => operaBigModles[21].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => operaBigModles[21].GetComponent<BoxCollider>().enabled = true)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击石膏模,将内部泥浆倒出")
                       .Callback(() => SetView())
                       .Callback(() => operaModle.isModelClickFour = true)
                       .Condition(() => operaModle.isModelClickFour == false)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "点击石膏模具，拆除石膏，获得成型后的胚体")
                       .Callback(() => SetView())
                      .Start(this);
                    }
                    else
                    {

                        if (collider.name != "ZhuJiangChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "JinShuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.JingShuDao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥浆----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 3.0f)
                       .Callback(() => operaBigModles[22].SetActive(false))
                       .Callback(() => operaBigModles[19].SetActive(false))
                       .Callback(() => operaBigModles[23].SetActive(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {

                           operaModle.operaNum = OperaModle.OperaStateID.NullState;

                       });
                    }
                    else
                    {

                        if (collider.name != "JinShuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.JingShuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 .Callback(() => SetView())
                                 .Delay(seconds: 2.0f)
                                 .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择金属刀,拖拽至场景中")
                                 .Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                }
                if (operaModle.experimentState == OperaModle.ExperimentState.Examine)
                {
                    print(string.Format("<color=Yellow>{0}</color>", collider.name + "-----------------") + operaModle.operaNum);
                    if (collider.name == "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                    {
                    }
                    else
                    {
                        if (collider.name != "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {

                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                           //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                           //.Callback(() => SetView())
                           //.Delay(seconds: 2.0f)
                           //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                           //.Callback(() => SetView())
                           .Start(monoBehaviour: this, onFinish: _ =>
                           {

                           });
                        }
                    }
                    if (collider.name == "ZhuJiang_KouZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ZhuJiangKou)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------注浆口----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.gameObject.transform.position = new Vector3(0, 0, 0))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 1.0f)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {

                            operaModle.operaNum = OperaModle.OperaStateID.TuoMoJi;
                            print("-----------------" + operaModle.operaNum);
                        });
                    }
                    else
                    {
                        if (collider.name != "ZhuJiang_KouZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ZhuJiangKou)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择注浆口,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------脱模剂----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.gameObject.transform.position = new Vector3(0, 0, 0))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 2.0f)
                        .Callback(() => operaBigModles[11].SetActive(false))
                        .Delay(seconds: 2.0f)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            operaModle.operaNum = OperaModle.OperaStateID.Line;
                            print("-----------------" + operaModle.operaNum);


                        });

                    }
                    else
                    {
                        if (collider.name != "TuoMoJi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TuoMoJi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择脱模剂,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "pen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Line)
                    {
                        collider.gameObject.SetActive(false);
                        ActionKit.Sequence()
                             .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                             .Callback(() => SetView())
                             .Delay(seconds: 2.0f)
                             .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择正确的裁缝线")
                             .Callback(() => SetView())
                             .Start(monoBehaviour: this, onFinish: _ =>
                             {

                             });
                    }
                    if (collider.name == "pen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.QiangBi)
                    {
                        ActionKit.Sequence()
                        .Callback(() => print("----------------------铅笔----------------"))
                        .Delay(seconds: 1.0f)
                        .Callback(() => collider.gameObject.SetActive(false))
                        .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                        .Delay(seconds: 2.0f)
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                        .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                        .Start(monoBehaviour: this, onFinish: _ =>
                        {
                            operaBigModles[1].SetActive(false);
                            operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                            print("-----------------" + operaModle.operaNum);
                        });
                    }
                    if (collider.name == "NiBaDuo(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                    {
                        operaModle.grade += 5;
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥巴----------------"))
                       .Delay(seconds: 1.0f)
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Delay(seconds: 3.0f)
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {

                           operaModle.operaNum = OperaModle.OperaStateID.MuDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "NiBaDuo(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiBa)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥巴,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                            print(operaModle.grade);
                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                    {
                        nowGameobject = operaBigModles[12];
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Play())
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = false)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Stop())
                      .Callback(() => nowGameobject.SetActive(false))
                      .Callback(() => operaBigModles[16].SetActive(true))
                      .Callback(() => operaBigModles[10].SetActive(false))
                      .Delay(seconds: 3.0f)
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[3], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaModle.operaNum = OperaModle.OperaStateID.YaKeLIBang;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "YaKeLiBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.YaKeLIBang)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------亚克力板----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[13].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[13].GetComponent<Animation>().Play())
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          operaModle.operaNum = OperaModle.OperaStateID.GuDingJingShu;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {

                        if (collider.name != "YaKeLiBang(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.YaKeLIBang)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择亚克力板,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }
                    }
                    if (collider.name == "GuDingJingShu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuDingJingShu)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------固定金属----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => operaBigModles[14].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[14].GetComponent<Animation>().Play())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[4], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[5], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           operaModle.operaNum = OperaModle.OperaStateID.Water;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "GuDingJingShu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShengZi)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择固定金属,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------水----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {

                          operaModle.operaNum = OperaModle.OperaStateID.ShiGaoFen;
                          print("-----------------" + operaModle.operaNum);
                      });
                    }
                    else
                    {
                        if (collider.name != "Water(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.Water)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择水,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });


                        }

                    }
                    if (collider.name == "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------石膏粉----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(true))
                       .Delay(seconds: 3.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.GetComponent<UIView>().SetVisibility(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "ShiGaoFen(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.ShiGaoFen)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择石膏粉,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------备制石膏----------------"))
                       .Delay(seconds: 2.0f)
                       //倒入石膏 动画需添加
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 1.0f)
                       .Callback(() => operaBigModles[27].SetActive(true))
                       .Callback(() => operaBigModles[18].SetActive(true))
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().Play())
                       .Callback(() => operaBigModles[19].SetActive(true))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaBigModles[27].SetActive(false))
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[6], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.BeiZhiShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     //.Callback(() => SetView())
                                     //.Delay(seconds: 2.0f)
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     //.Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }
                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().Play("GuaDaoDuo"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[6].SetActive(false))
                      .Callback(() => operaBigModles[19].SetActive(false))
                      .Delay(seconds: 1.0f)
                      .Callback(() => operaBigModles[13].SetActive(true))
                      .Callback(() => operaBigModles[14].SetActive(true))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[7], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                      .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[19].transform.eulerAngles = new Vector3(90, 0, 0);
                          operaBigModles[19].SetActive(true);
                          operaBigModles[6].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[6].GetComponent<Animation>().Stop();
                          operaModle.operaNum = OperaModle.OperaStateID.OtherShiGao;
                          print("-----------------" + operaModle.operaNum);
                          //  operaBigModles[18].SetActive(false);
                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.OtherShiGao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------倒入另一侧石膏----------------"))
                       .Delay(seconds: 2.0f)
                       //倒入石膏 动画需添加
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => operaBigModles[18].SetActive(true))
                       .Delay(seconds: 1.0f)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[18].GetComponent<Animation>().Play())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(true))
                       .Condition(() => operaModle.isClick == true)
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaModle.isModelClick = true)
                       .Condition(() => operaModle.isModelClick == false)
                       .Callback(() => operaModle.isModelClickTwo = true)
                       .Condition(() => operaModle.isModelClickTwo == false)
                       .Callback(() => operaBigModles[7].SetActive(false))
                       .Callback(() => operaBigModles[20].SetActive(true))
                       .Callback(() => operaBigModles[16].SetActive(false))
                       .Callback(() => operaBigModles[18].SetActive(false))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[8], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[9], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                       .Callback(() => ExecuteEvents.Execute(btnoperModles[9], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.isClick = false;
                           operaBigModles[19].SetActive(false);
                           operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                           print("-----------------" + operaModle.operaNum);
                       });
                    }
                    else
                    {
                        if (collider.name != "BeiZhiShiGao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.OtherShiGao)
                        {
                            if (collider.name == "WeiBan_WeiBan")
                            {

                            }
                            else
                            {
                                collider.gameObject.SetActive(false);
                                ActionKit.Sequence()
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                     //.Callback(() => SetView())
                                     //.Delay(seconds: 2.0f)
                                     //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制石膏,拖拽至场景中")
                                     //.Callback(() => SetView())
                                     .Start(monoBehaviour: this, onFinish: _ =>
                                     {

                                     });
                            }

                        }
                    }
                    if (collider.name == "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------木刀扣洞----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[10].GetComponent<Animation>().Play("MuDaoDuoOne"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 2.0f)
                      .Callback(() => operaBigModles[10].SetActive(false))
                      .Callback(() => operaBigModles[10].SetActive(false))
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[10].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[10].GetComponent<Animation>().Stop();
                          operaBigModles[20].SetActive(false);
                          operaBigModles[21].SetActive(true);
                          operaModle.operaNum = OperaModle.OperaStateID.GuaDao1;

                      });
                    }
                    else
                    {
                        if (collider.name != "MuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuDao1)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao1)
                    {
                        ActionKit.Sequence()
                      .Callback(() => print("----------------------刮刀----------------"))
                      .Delay(seconds: 2.0f)
                      .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().playAutomatically = true)
                      .Callback(() => operaBigModles[6].GetComponent<Animation>().Play("GuaDaoDuoOne"))
                      .Callback(() => collider.gameObject.SetActive(false))
                      .Delay(seconds: 3.0f)
                      .Callback(() => operaBigModles[6].SetActive(false))
                      .Callback(() => operaBigModles[19].SetActive(false))
                      .Delay(seconds: 2.0f)
                      .Start(monoBehaviour: this, onFinish: _ =>
                      {
                          if (nowGameobject != null)
                          {
                              nowGameobject.SetActive(false);
                          }
                          operaBigModles[6].GetComponent<Animation>().playAutomatically = false;
                          operaBigModles[6].GetComponent<Animation>().Stop();
                          operaBigModles[19].SetActive(false);
                          operaBigModles[26].SetActive(false);
                          operaBigModles[21].transform.localEulerAngles = new Vector3(-180, -180, 270);
                          operaBigModles[21].transform.localPosition = new Vector3(0, 1.1f, 0);
                          operaBigModles[0].transform.localEulerAngles = new Vector3(270, 180, 180);
                          operaBigModles[0].transform.localPosition = new Vector3(0, 1, 0);

                          operaModle.operaNum = OperaModle.OperaStateID.MuChui;
                          print("-----------------" + operaModle.operaNum);

                      });
                    }
                    else
                    {
                        if (collider.name != "GuaDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.GuaDao1)
                        {
                            collider.gameObject.SetActive(false);

                            ActionKit.Sequence()
                                      .Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                    {

                        ActionKit.Sequence()
                       .Callback(() => print("----------------------木锤----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[0].GetComponent<HighlightEffect>().highlighted = true)
                       .Callback(() => operaBigModles[0].GetComponent<MeshCollider>().enabled = true)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().playAutomatically = true)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>()["MoJu"].speed = 1.0f)
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu"))
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu"))
                       .Callback(() => operaBigModles[21].GetComponent<Animation>().Play())
                       .Callback(() => operaBigModles[5].SetActive(false))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaModle.operaNum = OperaModle.OperaStateID.TangLiDai;
                           print("-----------------" + operaModle.operaNum);

                       });
                    }
                    else
                    {
                        if (collider.name != "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木锤,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "TanLiDai(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.TangLiDai)
                    {

                        ActionKit.Sequence()
                       .Callback(() => print("----------------------弹力带----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.0f)
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {
                           if (nowGameobject != null)
                           {
                               nowGameobject.SetActive(false);
                           }
                           operaBigModles[21].GetComponent<Animation>().playAutomatically = false;
                           operaBigModles[21].GetComponent<Animation>().Stop();
                           operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                           print("-----------------" + operaModle.operaNum);

                       });
                    }
                    else
                    {
                        if (collider.name != "MuChui(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MuChui)
                        {
                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "ChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥浆----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 2.8f)
                       .Callback(() => operaBigModles[28].SetActive(true))
                       .Delay(seconds: 2.0f)
                       .Callback(() => operaBigModles[28].SetActive(false))
                       // .Callback(() => operaBigModles[3].SetActive(false))
                       .Callback(() => operaBigModles[3].transform.localEulerAngles = new Vector3(270, -360, 90))
                       .Callback(() => operaBigModles[3].transform.localPosition = new Vector3(-0.891f, 1.041f, -0.01f))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(true))
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PI.GetComponent<TMP_Text>().text = "泥浆成型中")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChange_PO.GetComponent<TMP_Text>().text = "时长约为:1:30min")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.Continu())
                       .Delay(seconds: 11.0f)
                       .Callback(() => operaModle.isModelClickFour = true)
                       .Condition(() => operaModle.isModelClickFour == false)
                      .Start(this);
                    }
                    else
                    {

                        if (collider.name != "ZhuJiangChengXing_Hu(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.NiJiang)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                    if (collider.name == "JinShuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.JingShuDao)
                    {
                        ActionKit.Sequence()
                       .Callback(() => print("----------------------泥浆----------------"))
                       .Delay(seconds: 2.0f)
                       .Callback(() => collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle())
                       .Callback(() => collider.gameObject.SetActive(false))
                       .Delay(seconds: 3.0f)
                       .Callback(() => operaBigModles[22].SetActive(false))
                       .Callback(() => operaBigModles[19].SetActive(false))
                       .Callback(() => operaBigModles[23].SetActive(true))
                       .Delay(seconds:1.0f)
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChang_Eexit.GetComponent<TMP_Text>().text = "异型（多块模）")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.TextChangeT_exit.GetComponent<TMP_Text>().text
                       = "当前异型（多块模）实验已完成，再次进入会重新开始实验”确认，返回考核界面")
                       .Callback(() => UIKit.GetPanel<ExpriMainPanel>().PromptCollectionPanel.View_004.GetComponent<UIView>().SetVisibility(true))
                       .Start(monoBehaviour: this, onFinish: _ =>
                       {

                           operaModle.operaNum = OperaModle.OperaStateID.NullState;

                       });
                    }
                    else
                    {

                        if (collider.name != "JinShuDao(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.JingShuDao)
                        {

                            collider.gameObject.SetActive(false);
                            ActionKit.Sequence()
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                                 //.Callback(() => SetView())
                                 //.Delay(seconds: 2.0f)
                                 //.Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择金属刀,拖拽至场景中")
                                 //.Callback(() => SetView())
                                 .Start(monoBehaviour: this, onFinish: _ =>
                                 {

                                 });
                        }

                    }
                }
                break;
            default:
                break;
        }

    }
    /// <summary>
    /// 获取间隔秒数
    /// </summary>
    /// <param name="startTimer"></param>
    /// <param name="endTimer"></param>
    /// <returns></returns>
    public int GetSubSeconds(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

        TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

        TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

        //返回间隔秒数（不算差的分钟和小时等，仅返回秒与秒之间的差）
        //return subTimer.Seconds;

        //返回相差时长（算上分、时的差值，返回相差的总秒数）
        return (int)subTimer.TotalSeconds;
    }

    /// <summary>
    /// 获取两个时间的相差多少分钟
    /// </summary>
    /// <param name="startTimer"></param>
    /// <param name="endTimer"></param>
    /// <returns></returns>
    public int GetSubMinutes(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

        TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

        TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

        //返回相差时长（仅返回相差的分钟数）
        //return subTimer.Minutes;
        //返回相差时长（仅返回相差的总分钟数）
        return (int)subTimer.TotalMinutes;
    }


    /// <summary>
    /// 获取两个时间的相差多少小时
    /// </summary>
    /// <param name="startTimer"></param>
    /// <param name="endTimer"></param>
    /// <returns></returns>
    public int GetSubHours(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

        TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

        TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

        //返回相差时长（仅返回相差的小时）
        //return subTimer.Hours;
        //返回相差时长（返回相差的总小时数）
        return (int)subTimer.TotalHours;
    }

    /// <summary>
    /// 获取两个时间的相差多少天
    /// </summary>
    /// <param name="startTimer"></param>
    /// <param name="endTimer"></param>
    /// <returns></returns>
    public int GetSubDays(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

        TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

        TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

        //返回相差时长（仅返回相差的天数）
        //return subTimer.Days;
        //返回相差时长（返回相差的总天数）
        return (int)subTimer.TotalDays;
    }
    public void SaveJson()
    {
        string filePath = Application.streamingAssetsPath+"/Json.json";//json文件路径

        if (File.Exists(filePath))//判断该文件是否存在
        {
            File.Delete(filePath);//删除这个文件
        }
        //找到当前路径
        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //ToJson接口将你的列表类传进去，，并自动转换为string类型  
        //string json = JsonConvert.SerializeObject(rosters);
        string saveJsonStr = JsonMapper.ToJson(rootLists);
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        saveJsonStr = reg.Replace(saveJsonStr, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });

        //将转换好的字符串存进文件，
        sw.WriteLine(saveJsonStr);
        sw.Close();//关闭文件
        sw.Dispose();
    }


}
