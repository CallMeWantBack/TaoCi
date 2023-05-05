using System.Collections;
using UnityEngine;

namespace QFramework.Example
{
    public class StartTestPanelData : UIPanelData
    {
    }
    public partial class StartTestPanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as StartTestPanelData ?? new StartTestPanelData();
            // please add init code here
            OnclickEvent();
        }
        private void OnclickEvent()
        {
            StartTest_Btn.onClick.AddListener(() =>
            {
                //UIKit.OpenPanel<MainMenuPanel>().AsLastSibling();

                UIKit.OpenPanelAsync<MainMenuPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<MainMenuPanel>().AsLastSibling();
                    UIKit.HidePanel<StartTestPanel>();
                });
               

                for (int i = 0; i < UIKit.GetPanel<TittlePanel>().uielementBtns.Count; i++)
                {
                    UIKit.GetPanel<TittlePanel>().uielementBtns[i].SetActive(true);

                }

                CloseSelf();
            }
            );

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
