using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using QFramework;
using QFramework.Example;
using TMPro;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour, IController
{

    private OperaModle operaModle;
    private static MouseClick _instance;
    public static MouseClick GetInstance()
    {
        if (_instance == null)
            _instance = new MouseClick();
        return _instance;
    }
    private void Awake()
    {
        operaModle = this.GetModel<OperaModle>();
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //15+种重载:射线，碰撞 ，射程，开启的层级
            if (Physics.Raycast(ray, out hit, 1000))
            {
                switch (operaModle.experimentType)
                {
                    case OperaModle.ExperimentType.None:
                        break;
                    case OperaModle.ExperimentType.One:
                        if (hit.collider.name == "ShengZi" && operaModle.isModelClick == true)
                        {
                            hit.collider.GetComponent<HighlightEffect>().highlighted=false;
                            hit.collider.gameObject.SetActive(false);

                            operaModle.isModelClick = false;
                        }
                        if (hit.collider.name == "WeiBan_WeiBan" && operaModle.isModelClickTwo == true)
                        {
                            hit.collider.GetComponent<HighlightEffect>().highlighted = false;
                            hit.collider.gameObject.SetActive(false);
                            TriggerOther.GetInstance().OperationModel[21].SetActive(false);
                            TriggerOther.GetInstance().OperationModel[23].SetActive(false);
                            operaModle.isModelClickTwo = false;
                        }
                        if (hit.collider.name == "ZhuJiangKou_NeiMo" && operaModle.isModelClickThree == true)
                        {
                            hit.collider.gameObject.GetComponent<Animation>().playAutomatically = true;
                            hit.collider.gameObject.GetComponent<Animation>().Play();
                           
                            ActionKit.Sequence()
                                   .Delay(seconds: 2.0f)
                                   .Callback(() => hit.collider.gameObject.GetComponent<HighlightEffect>().highlighted = false)
                                   .Callback(() => operaModle.isModelClickThree = false)
                                   .Start(this);
                        }
                        if (hit.collider.name == "ZhuJiangChengXing_PeiTi" && operaModle.isModelClickFive == true)
                        {
                            hit.collider.gameObject.GetComponent<HighlightEffect>().highlighted = true;
                            operaModle.isModelClickFive = false;
                        }
                        if (operaModle.isModelClickFour == true && hit.collider.name == "ZhuJiangKou_NeiMo")
                        {
                            Vector3 colOperaPos= hit.collider.transform.position;
                           
                            ActionKit.Sequence()
                              .Callback(() => print("----------------------动画2----------------"))
                              .Delay(seconds: 2.0f)
                              .Callback(() => hit.collider.gameObject.GetComponent<Animation>().Play("NeiMoOne"))
                              .Delay(seconds: 2.0f)
                              .Callback(() => hit.collider.gameObject.SetActive(false))
                              .Callback(() => hit.transform.position = colOperaPos)
                              .Callback(()=> hit.transform.localEulerAngles=new Vector3(90,0,0))
                              .Callback(() => TriggerOther.GetInstance().OperationModel[19].SetActive(false))
                              .Callback(() => operaModle.isModelClickFour = false)
                              .Start(this);

                        }
                        break;
                    case OperaModle.ExperimentType.Two:
                        if (hit.collider.tag == "YaKeLiBang" && operaModle.isModelClick == true)
                        {
                            hit.collider.transform.parent.GetComponent<HighlightEffect>().highlighted = false;
                            hit.collider.transform.parent.gameObject.SetActive(false);
                            operaModle.isModelClick = false;
                        }
                        if (hit.collider.tag == "GuDingJingShu" && operaModle.isModelClickTwo == true)
                        {
                            hit.collider.transform.parent.GetComponent<HighlightEffect>().highlighted = false;
                            hit.collider.transform.parent.gameObject.SetActive(false);
                            TriggerOther.GetInstance().operaBigModles[19].SetActive(true);
                            operaModle.isModelClickTwo = false;
                        }
                        if (hit.collider.name == "Step_YiMo_HuiZhi_TuZi_Xian_01_1" && operaModle.isModelClickSix == true)
                        {
                            hit.collider.gameObject.GetComponent<HighlightEffect>().highlighted = false;
                            TriggerOther.GetInstance().operaBigModles[25].SetActive(true);
                            if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                            {
                                TriggerOther.GetInstance().operaBigModles[25].GetComponent<HighlightEffect>().highlighted = true;
                            }
                           
                            operaModle.isModelClickSeven = true;
                            operaModle.isModelClickSix = false;
                           
                          
                        }
                        if (hit.collider.name == "Step_YiMo_HuiZhi_TuZi_Xian_01_2" && operaModle.isModelClickSeven == true)
                        {
                            hit.collider.gameObject.GetComponent<HighlightEffect>().highlighted = false;
                            operaModle.isModelClickSeven = false;
                            switch (operaModle.experimentState)
                            {
                                case OperaModle.ExperimentState.None:
                                    break;
                                case OperaModle.ExperimentState.Examine:
                                    TriggerOther.GetInstance().SetView();
                                    operaModle.operaNum = OperaModle.OperaStateID.QiangBi;
                                    break;
                                case OperaModle.ExperimentState.Practise:
                                    UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择铅笔，拖拽至场景中";
                                    TriggerOther.GetInstance().SetView();
                                    operaModle.operaNum = OperaModle.OperaStateID.QiangBi;
                                    break;
                                default:
                                    break;
                            }
                          

                        }
                        if (hit.collider.name == "TuZi")
                        {
                            hit.collider.GetComponent<Animation>().playAutomatically = true;
                           
                            hit.collider.GetComponent<Animation>().Play();
                            ActionKit.Sequence()
                          .Callback(() => print("----------------------动画2----------------"))
                          .Delay(seconds: 1.0f)
                          .Callback(() => hit.collider.GetComponent<Animation>().playAutomatically = false)
                          .Callback(() => hit.collider.GetComponent<Animation>().Stop())
                          .Callback(() => hit.collider.GetComponent<MeshCollider>().enabled = false)
                          .Callback(() => hit.collider.gameObject.SetActive(false))
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].time = TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].clip.length)
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>()["MoJu"].speed = -1.0f)
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>().CrossFade("MoJu"))
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].GetComponent<Animation>().Play())
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].transform.localEulerAngles = new Vector3(-90,-90,-270))
                          .Callback(() => TriggerOther.GetInstance().operaBigModles[21].transform.localPosition = new Vector3(0.002f, 1.0604f, 0.005f))
                          .Delay(seconds: 2.0f)
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[9], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[10], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[10], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                          .Start(monoBehaviour: this, onFinish: _ =>
                          {

                              hit.collider.gameObject.SetActive(false);

                          });

                        }
                        if (hit.collider.name == "ChengXingMoJu" && operaModle.isModelClickFour == true)
                        {
                            TriggerOther.GetInstance().operaBigModles[4].transform.parent = hit.collider.transform;
                            hit.collider.gameObject.GetComponent<Animation>().playAutomatically = true;
                            hit.collider.gameObject.GetComponent<Animation>().Play("DaoNiJiang");
                            TriggerOther.GetInstance().operaBigModles[4].SetActive(false);
                            ActionKit.Sequence()
                            .Callback(() => print("----------------------动画2----------------"))
                            .Delay(seconds: 2.0f)
                            .Start(monoBehaviour: this, onFinish: _ =>
                            {
                                hit.collider.transform.localEulerAngles = new Vector3(-90, -180, 180);
                                hit.collider.transform.localPosition = new Vector3(0, 1.1f, 0);
                                hit.collider.gameObject.GetComponent<Animation>().playAutomatically = false;
                                hit.collider.gameObject.GetComponent<Animation>().Stop();
                                operaModle.isModelClickFour = false;
                                operaModle.isModelClickFive = true;

                            });
                        }
                        if (hit.collider.name == "ChengXingMoJu" && operaModle.isModelClickFive == true)
                        {
                            hit.collider.gameObject.SetActive(false);
                            TriggerOther.GetInstance().operaBigModles[4].SetActive(false);
                            TriggerOther.GetInstance().operaBigModles[19].SetActive(true);
                            if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                            {
                                TriggerOther.GetInstance().operaBigModles[19].GetComponent<HighlightEffect>().highlighted = true;
                            }
                            operaModle.isModelClickFive = false;
                            ActionKit.Sequence()
                          .Condition(()=> operaModle.isModelClick ==false)
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[10], new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler))
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[11], new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler))
                          .Callback(() => ExecuteEvents.Execute(TriggerOther.GetInstance().btnoperModles[11], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler))
                          .Start(monoBehaviour: this, onFinish: _ =>
                         {

                             operaModle.operaNum = OperaModle.OperaStateID.JingShuDao;

                         });

                        }
                        break;
                    default:
                        break;
                }




            }
        }
    }
}
