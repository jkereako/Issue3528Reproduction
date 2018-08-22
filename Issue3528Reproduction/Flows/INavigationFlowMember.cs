using System;
namespace Issue3528Reproduction.Flows
{
    public interface INavigationFlowMember
    {
        //-- Events
        event EventHandler ShouldAdvance;
        event EventHandler ShouldPopToRoot;
    }
}
