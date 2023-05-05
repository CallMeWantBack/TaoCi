namespace QFramework.Example
{
    public class HelpPagePanelData : UIPanelData
    {
    }
    public partial class HelpPagePanel : UIPanel
    {

        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as HelpPagePanelData ?? new HelpPagePanelData();
            // please add init code here

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
