using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCMS.BlueToothPrinter.DependencyServices
{
    public interface IBlueToothService
    {
        IList<string> GetDeviceList();
        Task Print(string deviceName, string text);
    }
}