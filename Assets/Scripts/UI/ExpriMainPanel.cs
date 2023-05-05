using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Doozy.Engine.UI;
using HighlightPlus;
using UnityEngine.EventSystems;

namespace QFramework.Example
{

    public class ExpriMainPanelData : UIPanelData
    {
    }
    public partial class ExpriMainPanel : UIPanel, IController
    {
        [Header("单模的拖拽模型UI")]
        public List<GameObject> operatemodle;
        [Header("单模的步骤按钮")]
        public List<GameObject> buttonsClick;


        [Header("多模的拖拽模型UI")]
        public List<GameObject> operatemodleMone;
        [Header("多模的步骤按钮")]
        public List<GameObject> buttonsClickMone;
        private OperaModle operaModle;
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as ExpriMainPanelData ?? new ExpriMainPanelData();
            this.SendCommand<ExperOperaCommand>();
            TriggerOther.GetInstance().operatemodle = operatemodle;
            TriggerData.GetInstance().operaBigUI = operatemodleMone;
            TriggerOther.GetInstance().listBtns = buttonsClick;
            operaModle.operaNum = OperaModle.OperaStateID.MoZhong;
            TriggerOther.GetInstance().btnoperModles = buttonsClickMone;
            BtnEventInit();
            
        }

        private void BtnEventInit()
        {
            print(string.Format("<color=Yellow>{0}</color>", operaModle.experimentType + "-----------------") + operaModle.operaNum);
            if (operaModle.experimentType == OperaModle.ExperimentType.One)
            {
                StepContent.Content_D.gameObject.SetActive(true);
                StepContent.Content_Y.gameObject.SetActive(false);
                ToolContent.ContentlLittle.gameObject.SetActive(true);
                ToolContent.ContentlBig.gameObject.SetActive(false);
                StepContent.ScrollView.content = StepContent.Content_D;
                ClickEvent();
                print(string.Format("<color=Yellow>{0}</color>", operaModle.experimentState + "-----------------"));
                switch (operaModle.experimentState)
                {

                    case OperaModle.ExperimentState.None:
                        break;
                    case OperaModle.ExperimentState.Examine:
                        StepContent.MaskImage.raycastTarget = true;

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[0].gameObject.SetActive(true);
                            operatemodle[1].gameObject.SetActive(true);
                            operatemodle[0].transform.SetAsFirstSibling();
                            operatemodle[1].transform.SetAsFirstSibling();
                        }
                        for (int y = 0; y < TriggerOther.GetInstance().StepOneModle.Count; y++)
                        {
                            TriggerOther.GetInstance().StepOneModle[y].GetComponent<HighlightEffect>().highlighted = true;
                        }
                        break;
                    case OperaModle.ExperimentState.Practise:
                        StepContent.MaskImage.raycastTarget = false;

                        break;
                    default:
                        break;
                }

            }
            if (operaModle.experimentType == OperaModle.ExperimentType.Two)
            {
                StepContent.Content_Y.gameObject.SetActive(true);
                StepContent.Content_D.gameObject.SetActive(false);
                ToolContent.ContentlLittle.gameObject.SetActive(false);
                ToolContent.ContentlBig.gameObject.SetActive(true);
                StepContent.ScrollView.content = StepContent.Content_Y;
                ClickEventDuo();
                switch (operaModle.experimentState)
                {

                    case OperaModle.ExperimentState.None:
                        break;
                    case OperaModle.ExperimentState.Examine:
                        StepContent.MaskImage.raycastTarget = true;
                        break;
                    case OperaModle.ExperimentState.Practise:
                        StepContent.MaskImage.raycastTarget = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void HideView()
        {
            PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(false);
            PromptCollectionPanel.Text_Prochange.gameObject.SetActive(false);
            PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(false);
            PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(false);
            RemindImage.GetComponent<UIView>().SetVisibility(false);
            RemindImage.GetComponent<UIView>().SetVisibility(true);
            for (int i = 0; i < TriggerOther.GetInstance().OperationModel.Count; i++)
            {
                TriggerOther.GetInstance().OperationModel[i].SetActive(false);

            }

        }
        private void ClickEvent()
        {
            operatemodle[0].SetActive(true);
            operatemodle[1].SetActive(true);

            for (int i = 0; i < buttonsClick.Count; i++)
            {
     
                buttonsClick[0].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种（碗），拖拽至石膏地板上";
                        HideView();
                        operaModle.operaNum = OperaModle.OperaStateID.MoZhong;


                        for (int z = 0; z < TriggerOther.GetInstance().StepOneModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepOneModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepOneModle[z].GetComponent<HighlightEffect>().highlighted = true;
                        }
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[0].gameObject.SetActive(true);
                            operatemodle[1].gameObject.SetActive(true);
                            operatemodle[0].transform.SetAsFirstSibling();
                            operatemodle[1].transform.SetAsFirstSibling();


                        }
                    }
                    else
                    {
                        operaModle.operaNum = OperaModle.OperaStateID.MoZhong;


                        for (int z = 0; z < TriggerOther.GetInstance().StepOneModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepOneModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepOneModle[z].GetComponent<HighlightEffect>().highlighted = true;
                        }
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[0].gameObject.SetActive(true);
                            operatemodle[1].gameObject.SetActive(true);
                            operatemodle[0].transform.SetAsFirstSibling();
                            operatemodle[1].transform.SetAsFirstSibling();


                        }
                    }


                });
                buttonsClick[1].GetComponent<Button>().onClick.AddListener(() =>
                {
                    print(string.Format("<color=Yellow>{0}</color>", operaModle.experimentState + "-----------------"));
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥巴，拖拽至场景中";
                        HideView();
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[2].gameObject.SetActive(true);
                            operatemodle[3].gameObject.SetActive(true);
                            operatemodle[2].transform.SetAsFirstSibling();
                            operatemodle[3].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                        for (int z = 0; z < TriggerOther.GetInstance().StepTwoModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepTwoModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepTwoModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[2].gameObject.SetActive(true);
                            operatemodle[3].gameObject.SetActive(true);
                            operatemodle[2].transform.SetAsFirstSibling();
                            operatemodle[3].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.NiBa;
                        for (int z = 0; z < TriggerOther.GetInstance().StepTwoModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepTwoModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepTwoModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }


                });
                buttonsClick[2].GetComponent<Button>().onClick.AddListener(() =>
                {

                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择长方形软板，拖拽至场景中";
                        HideView();
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[4].gameObject.SetActive(true);
                            operatemodle[5].gameObject.SetActive(true);
                            operatemodle[4].transform.SetAsFirstSibling();
                            operatemodle[5].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.RuanBang;
                        for (int z = 0; z < TriggerOther.GetInstance().StepThreeModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepThreeModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepThreeModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[4].gameObject.SetActive(true);
                            operatemodle[5].gameObject.SetActive(true);
                            operatemodle[4].transform.SetAsFirstSibling();
                            operatemodle[5].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.RuanBang;
                        for (int z = 0; z < TriggerOther.GetInstance().StepThreeModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepThreeModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepThreeModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }

                });
                buttonsClick[3].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择水，拖拽至场景中";
                        HideView();
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[6].gameObject.SetActive(true);
                            operatemodle[7].gameObject.SetActive(true);
                            operatemodle[6].transform.SetAsFirstSibling();
                            operatemodle[7].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.Water;
                        for (int z = 0; z < TriggerOther.GetInstance().StepFourModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepFourModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepFourModle[0].GetComponent<HighlightEffect>().highlighted = false;
                            TriggerOther.GetInstance().StepFourModle[6].GetComponent<Animation>().Stop();
                            TriggerOther.GetInstance().StepFourModle[6].GetComponent<HighlightEffect>().highlighted = false;


                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[6].gameObject.SetActive(true);
                            operatemodle[7].gameObject.SetActive(true);
                            operatemodle[6].transform.SetAsFirstSibling();
                            operatemodle[7].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.Water;
                        for (int z = 0; z < TriggerOther.GetInstance().StepFourModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepFourModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepFourModle[0].GetComponent<HighlightEffect>().highlighted = false;
                            TriggerOther.GetInstance().StepFourModle[6].GetComponent<Animation>().Stop();
                            TriggerOther.GetInstance().StepFourModle[6].GetComponent<HighlightEffect>().highlighted = false;


                        }
                    }

                });
                buttonsClick[4].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择备制好的石膏，拖拽至场景中";
                        HideView();

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[8].gameObject.SetActive(true);
                            operatemodle[8].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                        for (int z = 0; z < TriggerOther.GetInstance().StepFiveModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepFiveModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepFiveModle[0].GetComponent<HighlightEffect>().highlighted = false;
                            TriggerOther.GetInstance().StepFiveModle[4].GetComponent<Animation>().Stop();
                            TriggerOther.GetInstance().StepFiveModle[4].GetComponent<HighlightEffect>().highlighted = false;

                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[8].gameObject.SetActive(true);
                            operatemodle[8].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                        for (int z = 0; z < TriggerOther.GetInstance().StepFiveModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepFiveModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepFiveModle[0].GetComponent<HighlightEffect>().highlighted = false;
                            TriggerOther.GetInstance().StepFiveModle[4].GetComponent<Animation>().Stop();
                            TriggerOther.GetInstance().StepFiveModle[4].GetComponent<HighlightEffect>().highlighted = false;

                        }
                    }

                });
                buttonsClick[5].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择刮刀，拖拽至场景中";
                        HideView();
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[9].gameObject.SetActive(true);
                            operatemodle[9].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                        for (int z = 0; z < TriggerOther.GetInstance().StepSixModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepSixModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepSixModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[9].gameObject.SetActive(true);
                            operatemodle[9].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                        for (int z = 0; z < TriggerOther.GetInstance().StepSixModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepSixModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepSixModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }

                });
                buttonsClick[6].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择木刀，拖拽至场景中";
                        HideView();

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[10].gameObject.SetActive(true);
                            operatemodle[10].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                        for (int z = 0; z < TriggerOther.GetInstance().StepSevenModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepSevenModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepSevenModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }
                    else
                    {

                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[10].gameObject.SetActive(true);
                            operatemodle[10].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                        for (int z = 0; z < TriggerOther.GetInstance().StepSevenModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepSevenModle[z].SetActive(true);
                            TriggerOther.GetInstance().StepSevenModle[0].GetComponent<HighlightEffect>().highlighted = false;
                        }
                    }

                });
                buttonsClick[7].GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择泥浆，拖拽至场景中";
                        HideView();
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[11].gameObject.SetActive(true);
                            operatemodle[11].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                        for (int z = 0; z < TriggerOther.GetInstance().StepEightModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepEightModle[z].SetActive(true);

                        }
                    }
                    else
                    {
                        for (int z = 0; z < operatemodle.Count; z++)
                        {
                            operatemodle[z].gameObject.SetActive(false);
                            operatemodle[11].gameObject.SetActive(true);
                            operatemodle[11].transform.SetAsFirstSibling();


                        }
                        operaModle.operaNum = OperaModle.OperaStateID.NiJiang;
                        for (int z = 0; z < TriggerOther.GetInstance().StepEightModle.Count; z++)
                        {
                            TriggerOther.GetInstance().StepEightModle[z].SetActive(true);

                        }
                    }


                });
            }
        }
        private void ClickEventDuo()
        {
            operatemodleMone[0].SetActive(true);
            operatemodleMone[1].SetActive(true);

            for (int i = 0; i < buttonsClickMone.Count; i++)
            {
                buttonsClickMone[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].time = TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].clip.length;
                    TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].speed = -1.0f;
                    TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu");
                    TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>().Play();
                    TriggerOther.GetInstance().operaBigModles[21].transform.localEulerAngles = new Vector3(-90, -90, -270);
                    TriggerOther.GetInstance().operaBigModles[21].transform.localPosition = new Vector3(0.002f, 1.0604f, 0.005f);
                    TriggerOther.GetInstance().operaBigModles[0].transform.localPosition = new Vector3(0.0089f, 1.0003f, 0.052f);
                    TriggerOther.GetInstance().operaBigModles[0].transform.localEulerAngles = new Vector3(90, 270, 90);
                    TriggerOther.GetInstance().operaBigModles[0].GetComponent<HighlightEffect>().highlighted = false;
                    PromptCollectionPanel.View_001.GetComponent<UIView>().SetVisibility(false);
                    PromptCollectionPanel.Text_Prochange.gameObject.SetActive(false);
                    PromptCollectionPanel.View_002.GetComponent<UIView>().SetVisibility(false);
                    PromptCollectionPanel.View_003.GetComponent<UIView>().SetVisibility(false);
                    switch (operaModle.experimentState)
                    {
                        case OperaModle.ExperimentState.None:
                            break;
                        case OperaModle.ExperimentState.Examine:
                            break;
                        case OperaModle.ExperimentState.Practise:
                            RemindImage.GetComponent<UIView>().SetVisibility(false);
                            RemindImage.GetComponent<UIView>().SetVisibility(true);
                            break;
                        default:
                            break;
                    }

                    for (int y = 0; y < TriggerOther.GetInstance().operaBigModles.Count; y++)
                    {
                        TriggerOther.GetInstance().operaBigModles[y].SetActive(false);


                    }
                    for (int x = 0; x < TriggerOther.GetInstance().StepOneModleDuo.Count; x++)
                    {
                        TriggerOther.GetInstance().StepOneModleDuo[x].GetComponent<HighlightEffect>().highlighted = false;


                    }
                });
                buttonsClickMone[0].GetComponent<Button>().onClick.AddListener(() =>
                {
                    operaModle.operaNum = OperaModle.OperaStateID.MoZhong;
                    for (int x = 0; x < TriggerOther.GetInstance().StepOneModleDuo.Count; x++)
                    {
                        TriggerOther.GetInstance().StepOneModleDuo[x].GetComponent<HighlightEffect>().highlighted = true;

                    }

                });
                buttonsClickMone[1].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.TuoMoJi;

                    for (int z = 0; z < TriggerOther.GetInstance().StepTwoModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepTwoModleDuo[z].SetActive(true);
                    }


                });
                buttonsClickMone[2].GetComponent<Button>().onClick.AddListener(() =>
                {
                    operaModle.isModelClickSix = true;
                    operaModle.operaNum = OperaModle.OperaStateID.Line;

                    for (int z = 0; z < TriggerOther.GetInstance().StepThreeModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepThreeModleDuo[z].SetActive(true);
                        if (operaModle.experimentState==OperaModle.ExperimentState.Practise)
                        {
                            TriggerOther.GetInstance().StepThreeModleDuo[3].GetComponent<HighlightEffect>().highlighted = true;
                        }
                        
                    }
                });
                buttonsClickMone[3].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.NiBa;

                    for (int z = 0; z < TriggerOther.GetInstance().StepFourModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepFourModleDuo[z].SetActive(true);

                    }
                });
                buttonsClickMone[4].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.YaKeLIBang;
                    for (int z = 0; z < TriggerOther.GetInstance().StepFiveModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepFiveModleDuo[z].SetActive(true);

                    }
                });
                buttonsClickMone[5].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.Water;
                    for (int z = 0; z < TriggerOther.GetInstance().StepSixModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepSixModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().Stop();
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().Stop();
                    }

                });
                buttonsClickMone[6].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.BeiZhiShiGao;
                    for (int z = 0; z < TriggerOther.GetInstance().StepSevenModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepSevenModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().Stop();
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().Stop();
                    }
                });
                buttonsClickMone[7].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.GuaDao;
                    for (int z = 0; z < TriggerOther.GetInstance().StepEightModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepEightModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepEightModleDuo[5].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepEightModleDuo[5].GetComponent<Animation>().Stop();

                    }

                });
                buttonsClickMone[8].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.OtherShiGao;
                    for (int z = 0; z < TriggerOther.GetInstance().StepNightModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepNightModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[4].GetComponent<Animation>().Stop();
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().playAutomatically = false;
                        TriggerOther.GetInstance().StepSixModleDuo[5].GetComponent<Animation>().Stop();
                    }

                });
                buttonsClickMone[9].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.MuDao1;
                    for (int z = 0; z < TriggerOther.GetInstance().StepTengModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepTengModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepTengModleDuo[0].transform.localPosition = new Vector3(0, 1f, 0);
                        TriggerOther.GetInstance().StepTengModleDuo[0].transform.localEulerAngles = new Vector3(270, 180, 180);
                        TriggerOther.GetInstance().StepTengModleDuo[1].SetActive(false);
                        TriggerOther.GetInstance().StepTengModleDuo[0].GetComponent<HighlightEffect>().highlighted = false;

                    }

                });
                buttonsClickMone[10].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.TangLiDai;
                    for (int z = 0; z < TriggerOther.GetInstance().StepTentingOneModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepTentingOneModleDuo[z].SetActive(true);
                        TriggerOther.GetInstance().StepTentingOneModleDuo[0].GetComponent<HighlightEffect>().highlighted = false;

                    }

                });
                buttonsClickMone[11].GetComponent<Button>().onClick.AddListener(() =>
                {

                    operaModle.operaNum = OperaModle.OperaStateID.JingShuDao;
                    for (int z = 0; z < TriggerOther.GetInstance().StepTentingTwoModleDuo.Count; z++)
                    {
                        TriggerOther.GetInstance().StepTentingTwoModleDuo[z].SetActive(true);

                    }

                });
            }
        }

        private void Awake()
        {
            operaModle = this.GetModel<OperaModle>();

        }
        protected override void OnOpen(IUIData uiData = null)
        {


        }
        protected override void OnShow()
        {


        }

        protected override void OnHide()
        {



        }

        protected override void OnClose()
        {
            operaModle.operaNum = OperaModle.OperaStateID.MoZhong;

            switch (operaModle.experimentType)
            {
                case OperaModle.ExperimentType.None:
                    break;
                case OperaModle.ExperimentType.One:
                    for (int i = 0; i < TriggerOther.GetInstance().OperationModel.Count; i++)
                    {
                        TriggerOther.GetInstance().OperationModel[i].SetActive(false);

                    }
                    for (int y = 0; y < operatemodle.Count; y++)
                    {
                        operatemodle[y].SetActive(false);
                        operatemodle[0].SetActive(true);
                        operatemodle[0].transform.AsFirstSibling();
                        operatemodle[1].SetActive(true);
                        operatemodle[1].transform.AsFirstSibling();

                    }

                    break;
                case OperaModle.ExperimentType.Two:

                    for (int y = 0; y < TriggerOther.GetInstance().operaBigModles.Count; y++)
                    {
                        TriggerOther.GetInstance().operaBigModles[y].SetActive(false);

                    }
                    for (int x = 0; x < operatemodleMone.Count; x++)
                    {
                        operatemodleMone[x].SetActive(false);
                        operatemodleMone[0].SetActive(true);
                        operatemodleMone[0].transform.AsFirstSibling();
                        operatemodleMone[1].SetActive(true);
                        operatemodleMone[1].transform.AsFirstSibling();
                    }

                    break;
                default:
                    break;
            }
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

