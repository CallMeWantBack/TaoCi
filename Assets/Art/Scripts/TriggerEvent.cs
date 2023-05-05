using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using HighlightPlus;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace QFramework.Example
{
    public class TriggerEvent : MonoBehaviour, IController
    {
        private static TriggerEvent _instance;
        public static TriggerEvent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType(typeof(TriggerEvent)) as TriggerEvent;
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        //obj.hideFlags = HideFlags.DontSave;
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = (TriggerEvent)obj.AddComponent(typeof(TriggerEvent));
                    }
                }
                return _instance;
            }
        }

        private OperaModle operaModle;

        public GameObject MoZhong;
        public GameObject ShiDIbang;

        public string startTime;

        public string step;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (_instance == null)
            {
                _instance = this as TriggerEvent;
            }
            else
            {
                Destroy(gameObject);
            }
            operaModle = this.GetModel<OperaModle>();
            ShiDIbang.GetComponent<HighlightEffect>().highlighted = true;

        }
        public void OnTriggerEnter(Collider collider)
        {
            switch (operaModle.experimentType)
            {
                case OperaModle.ExperimentType.None:
                    break;
                case OperaModle.ExperimentType.One:
                    print(string.Format("<color=Yellow>{0}</color>", collider.name + "-----------------") + operaModle.operaNum);
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        if (collider.name == "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {
                            for (int i = 0; i < TriggerOther.GetInstance().operatemodle.Count; i++)
                            {
                                print(TriggerOther.GetInstance().operatemodle[i].name);
                                if (TriggerOther.GetInstance().operatemodle[i].name == "模种")
                                {
                                    TriggerOther.GetInstance().operatemodle[i].gameObject.SetActive(false);
                                    TriggerOther.GetInstance().operatemodle[i].GetComponent<DragUI>().dragObj.SetActive(false);
                                }
                            }
                       
                            MoZhong.SetActive(true);
                            ShiDIbang.GetComponent<HighlightEffect>().highlighted = false;
                            UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择脱模剂，拖拽至场景中";
                            TriggerOther.GetInstance().SetView();
                            this.SendCommand<DanGradeCommand>();
                            print(string.Format("<color=Green>{0}</color>", operaModle.grade));

                            operaModle.operaNum = OperaModle.OperaStateID.TuoMoJi;
                        }
                        else
                        {
                            if (collider.name != "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                            {

                                ActionKit.Sequence()
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Delay(seconds: 2.0f)
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Start(monoBehaviour: this, onFinish: _ =>
                               {

                               });
                            }
                        }

                    }
                    if (operaModle.experimentState == OperaModle.ExperimentState.Examine)
                    {
                        if (collider.name == "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {
                            for (int i = 0; i < TriggerOther.GetInstance().operatemodle.Count; i++)
                            {
                                print(TriggerOther.GetInstance().operatemodle[i].name);
                                if (TriggerOther.GetInstance().operatemodle[i].name == "模种")
                                {
                                    TriggerOther.GetInstance().operatemodle[i].gameObject.SetActive(false);
                                    TriggerOther.GetInstance().operatemodle[i].GetComponent<DragUI>().dragObj.SetActive(false);
                                }
                            }
                          
                            MoZhong.SetActive(true);
                            ShiDIbang.GetComponent<HighlightEffect>().highlighted = false;
                            this.SendCommand<DanGradeCommand>();
                            print(string.Format("<color=Green>{0}</color>", operaModle.grade));
                            step = "喷洒脱模剂";
                            startTime = System.DateTime.Now.ToString();
                            operaModle.operaNum = OperaModle.OperaStateID.TuoMoJi;

                        }
                        else
                        {
                            if (collider.name != "MoZhong(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                            {
                              
                           
                                this.SendCommand<YiGradeCommand>();
                                print(string.Format("<color=Green>{0}</color>", operaModle.grade));
                                ActionKit.Sequence()
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Delay(seconds: 2.0f)
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Start(monoBehaviour: this, onFinish: _ =>
                               {
                                   
                               });
                            }
                        }
                    }
                    break;
                case OperaModle.ExperimentType.Two:
                    print(string.Format("<color=Yellow>{0}</color>", collider.name + "-----------------") + operaModle.operaNum);
                    if (operaModle.experimentState == OperaModle.ExperimentState.Practise)
                    {
                        if (collider.name == "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {        
                            collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle();
                            ShiDIbang.GetComponent<HighlightEffect>().highlighted = false;
                            UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择注浆口，拖拽至场景中";
                            TriggerOther.GetInstance().SetView();

                            operaModle.operaNum = OperaModle.OperaStateID.ZhuJiangKou;
                        }

                        else
                        {
                            if (collider.name != "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                            {
                         
                                ActionKit.Sequence()
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Delay(seconds: 2.0f)
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Start(monoBehaviour: this, onFinish: _ =>
                               {

                               });
                            }
                        }
                    }
                    if (operaModle.experimentState == OperaModle.ExperimentState.Examine)
                    {
                        if (collider.name == "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                        {

                        
                            collider.GetComponent<IsTriggerEvent>().ShowHideUiORModle();
                            ShiDIbang.GetComponent<HighlightEffect>().highlighted = false;
                            operaModle.operaNum = OperaModle.OperaStateID.ZhuJiangKou;
                        }
                        else
                        {
                            if (collider.name != "TuZi(Clone)" && operaModle.operaNum == OperaModle.OperaStateID.MoZhong)
                            {
                             
                                ActionKit.Sequence()
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "请按步骤进行操作")
                               .Callback(() => TriggerOther.GetInstance().SetView())
                               .Delay(seconds: 2.0f)
                               .Callback(() => UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = "选择模种,拖拽至场景中")
                               .Callback(() => TriggerOther.GetInstance().SetView())
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
