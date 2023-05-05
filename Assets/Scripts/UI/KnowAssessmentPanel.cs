namespace QFramework.Example
{
    public class KnowAssessmentPanelData : UIPanelData
    {
    }
    public partial class KnowAssessmentPanel : UIPanel
    {


        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as KnowAssessmentPanelData ?? new KnowAssessmentPanelData();
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





