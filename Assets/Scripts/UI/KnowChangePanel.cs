using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class KnowChangePanelData : UIPanelData
    {
    }
    public partial class KnowChangePanel : UIPanel
    {
        public List<GameObject> toggleContents;
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as KnowChangePanelData ?? new KnowChangePanelData();
            OnClickEvent();
            // please add init code here
        }
        private void OnClickEvent()
        {
            SureBtn.onClick.AddListener(() =>
            {
                UIKit.HidePanel<KnowChangePanel>();
                UIKit.GetPanel<KnowledgeLearPanel>().AsLastSibling();

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
    }
}
