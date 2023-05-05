/****************************************************************************
 * 2023.3 ADMIN-20230222X
 ****************************************************************************/

using DG.Tweening;
namespace QFramework.Example
{


    public partial class StepContent : UIElement
    {
        public bool isOutSide = true;
        private void Awake()
        {
            OnclickEvent();
        }

        private void OnclickEvent()
        {
            StepBtn.onClick.AddListener(() =>
            {

                this.transform.DOLocalMoveX(-308, 0.5f);
                this.StepBtnOpen.gameObject.SetActive(true);
                this.StepBtn.gameObject.SetActive(false);

            });
            StepBtnOpen.onClick.AddListener(() =>
            {

                this.transform.DOLocalMoveX(0, 0.5f);
                this.StepBtnOpen.gameObject.SetActive(false);
                this.StepBtn.gameObject.SetActive(true);

            });
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}