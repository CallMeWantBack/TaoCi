

namespace QFramework.Example
{
    class YiGradeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.GetModel<OperaModle>().grade -= 2;
        }
    }
}

