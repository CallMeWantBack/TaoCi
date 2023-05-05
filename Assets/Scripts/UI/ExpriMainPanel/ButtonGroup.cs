/****************************************************************************
 * 2023.3 ADMIN-20230222X
 ****************************************************************************/

namespace QFramework.Example
{
    public partial class ButtonGroup : UIElement
    {
        private void Awake()
        {
            Help_Btn.onClick.AddListener(() =>
            {
               // UIKit.OpenPanel<HelpPagePanel>().AsLastSibling();

                UIKit.OpenPanelAsync<HelpPagePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<HelpPagePanel>().AsLastSibling();
                });
                
            });
            FullScrenn_Btn.onClick.AddListener(() =>
            {
            });
            ReturnHome_Btn.onClick.AddListener(() =>
            {
                UIKit.HidePanel<ExpriMainPanel>();
                UIKit.ShowPanel<MainMenuPanel>();
                UIKit.ShowPanel<TittlePanel>();
                UIKit.GetPanel<MainMenuPanel>().AsLastSibling();
                UIKit.GetPanel<TittlePanel>().AsLastSibling();
            });
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}