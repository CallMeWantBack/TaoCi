
namespace QFramework.Example
{
    class DanGradeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.GetModel<OperaModle>().grade += 5;
        }
    }
}

