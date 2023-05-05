using UnityEngine;

namespace QFramework.Example
{
    public class KnowledgeLearPanelData : UIPanelData
    {
    }
    public partial class KnowledgeLearPanel : UIPanel
    {

        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as KnowledgeLearPanelData ?? new KnowledgeLearPanelData();
            OnclickEvent();
            // please add init code here
        }
        private void OnclickEvent()
        {
            Experiment_purposeBtn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<KnowChangePanel>().AsLastSibling();

                UIKit.OpenPanelAsync<KnowChangePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowChangePanel>().AsLastSibling();
                    ShowContent(0);
                });
              
                
            });
            Experiment_principleBtn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<KnowChangePanel>().AsLastSibling();
                UIKit.OpenPanelAsync<KnowChangePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowChangePanel>().AsLastSibling();
                    ShowContent(1);
                });
                
                
            });
            Experiment_askBtn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<KnowChangePanel>().AsLastSibling();

                UIKit.OpenPanelAsync<KnowChangePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowChangePanel>().AsLastSibling();
                    ShowContent(2);
                });
               
                
            });
            SureBtn.onClick.AddListener(() =>
            {
                UIKit.HidePanel<KnowledgeLearPanel>();
                UIKit.GetPanel<MainMenuPanel>().AsLastSibling();
            });
        }
        private void ShowContent(int index)
        {
            var toggle = UIKit.GetPanel<KnowChangePanel>().toggleContents;
            for (int i = 0; i < toggle.Count; i++)
            {
                GameObject go = toggle[i];
                go.SetActive(false);
            }

            if (index < toggle.Count)
            {
                //SetActive(toggleContents[index], isShow);
                toggle[index].SetActive(true);
            }
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
    }
}
