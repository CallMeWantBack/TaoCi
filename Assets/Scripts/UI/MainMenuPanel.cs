using PicklePro;
using System;

namespace QFramework.Example
{
  
    public class MainMenuPanelData : UIPanelData
    {
    }
    public partial class MainMenuPanel : UIPanel,IController
    {
        private OperaModle operaModle;
        protected override void OnInit(IUIData uiData = null)
        {
            operaModle = operaModle = this.GetModel<OperaModle>();
            mData = uiData as MainMenuPanelData ?? new MainMenuPanelData();
            OnclickEvent();
         
            // please add init code here
        }
        private void OnclickEvent()
        {
            CeramicExamine_Btn.onClick.AddListener(() =>
            {
                //UIKit.OpenPanel<OperationExperiPanel>().AsLastSibling();

                UIKit.OpenPanelAsync<OperationExperiPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<OperationExperiPanel>().AsLastSibling();
                    UIKit.GetPanel<OperationExperiPanel>().ChangeTxt.text = "陶瓷造型考核";
                });
              
                operaModle.experimentState = OperaModle.ExperimentState.Examine;
               // print(string.Format("<color=Yellow>{0}</color>", operaModle.experimentType + "-----------------"));
              
            }
            );
            CeramicTrain_Btn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<OperationExperiPanel>().AsLastSibling();

                UIKit.OpenPanelAsync<OperationExperiPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<OperationExperiPanel>().AsLastSibling();
                    UIKit.GetPanel<OperationExperiPanel>().ChangeTxt.text = "陶瓷造型训练";
                });
               
                operaModle.experimentState = OperaModle.ExperimentState.Practise;
                //print(string.Format("<color=Yellow>{0}</color>", operaModle.experimentType + "-----------------"));
              

            }
            );
            KnowledgeExamine_Btn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<KnowAssessmentPanel>().AsLastSibling();


                UIKit.OpenPanelAsync<KnowAssessmentPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowAssessmentPanel>().AsLastSibling();
                });
               

            }
            );
            KnowledgeLearning_Btn.onClick.AddListener(() =>
            {
                //UIKit.OpenPanel<KnowledgeLearPanel>().AsLastSibling();


                UIKit.OpenPanelAsync<KnowledgeLearPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowledgeLearPanel>().AsLastSibling();
                });
               

            }
            );
            ExperimentalReport_Btn.onClick.AddListener(() =>
            {
                //UIKit.OpenPanel<ExperimentalReportPanel>().AsLastSibling();


                UIKit.OpenPanelAsync<ExperimentalReportPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<ExperimentalReportPanel>().AsLastSibling();
                });
             
                //operaModle.grades.Add("对称型单块模", operaModle.grade);
                //print(operaModle.grade);
            });
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
        }
        private void OnDestroy()
        {
            operaModle = null;
        }
        public IArchitecture GetArchitecture()
        {
            return OperaApp.Interface;
        }
    }

}
