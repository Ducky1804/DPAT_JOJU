
namespace DPAT_JOJU;

class Application
{
    public static void Main(string[] args)
    {
        IApplicationBooter booter = new FiniteStateMachineBooter();
        booter.Boot();
    }
}