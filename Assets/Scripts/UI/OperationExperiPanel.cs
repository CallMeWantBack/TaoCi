using PicklePro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QFramework.Example
{


    public class OperationExperiPanelData : UIPanelData
    {
    }
    public partial class OperationExperiPanel : UIPanel,IController
    {
        private OperaModle operaModle;
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as OperationExperiPanelData ?? new OperationExperiPanelData();
            operaModle = operaModle = this.GetModel<OperaModle>();
            OnclickEvnet();
            // please add init code here
        }
        private void OnclickEvnet()
        {
            Monoblock_moldBtn.onClick.AddListener(() =>
            {

                UIKit.HideAllPanel();
                operaModle.experimentType = OperaModle.ExperimentType.One;
                //UIKit.OpenPanel<ExpriMainPanel>().AsLastSibling();

                UIKit.OpenPanelAsync<ExpriMainPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                 


                });
                UIKit.OpenPanelAsync<HelpPagePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {



                });
                UIKit.ShowPanel<TittlePanel>();
                UIKit.GetPanel<TittlePanel>().transform.GetChild(1).gameObject.SetActive(true);
                UIKit.GetPanel<TittlePanel>().transform.GetChild(0).gameObject.SetActive(false);
                UIKit.GetPanel<TittlePanel>().transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                //TaskPlay();




            });
            Multiblock_moldBtn.onClick.AddListener(() =>
            {
                UIKit.HideAllPanel();
                operaModle.experimentType = OperaModle.ExperimentType.Two;
               // UIKit.OpenPanel<ExpriMainPanel>().AsLastSibling();

                UIKit.OpenPanelAsync<ExpriMainPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                   

                });
                UIKit.OpenPanelAsync<HelpPagePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {



                });
                UIKit.ShowPanel<TittlePanel>();
                UIKit.GetPanel<TittlePanel>().transform.GetChild(1).gameObject.SetActive(true);
                UIKit.GetPanel<TittlePanel>().transform.GetChild(0).gameObject.SetActive(false);
                UIKit.GetPanel<TittlePanel>().transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);


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
