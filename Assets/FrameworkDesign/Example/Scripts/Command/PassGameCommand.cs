

namespace FrameworkDesign.Example
{
    public struct PassGameCommand : ICommand
    {
        public void Execute()
        {
            GamePassEvent.Trigger();
        }
    }
}

