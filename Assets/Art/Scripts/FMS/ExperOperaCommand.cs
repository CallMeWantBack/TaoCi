

namespace QFramework.Example
{
    class ExperOperaCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.GetModel<OperaModle>().isUITrigger = true;
        }
    }
}
