using DCMS.BlueToothPrinter.DependencyServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DCMS.BlueToothPrinter.ViewModels
{
    public class PrintPageViewModel
    {
        private readonly IBlueToothService _blueToothService;

        private IList<string> _deviceList;
        public IList<string> DeviceList
        {
            get
            {
                if (_deviceList == null)
                    _deviceList = new ObservableCollection<string>();
                return _deviceList;
            }
            set
            {
                _deviceList = value;
            }
        }

        private string _printMessage;
        public string PrintMessage
        {
            get
            {
                return _printMessage;
            }
            set
            {
                _printMessage = value;
            }
        }

        private string _selectedDevice;
        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public ICommand PrintCommand => new Command(async () =>
        {
            PrintMessage += " DCMS 是华润雪花啤酒晋陕区域公司基于Saas的经销商快消解决方案，皆在满足区域营销管理业务快速变化需求，系统基于Docker + .Net core + Mysql Inner db cluster 的分布式微服务框架,提供高性能RPC远程服务调用，采用Zookeeper、Consul作为surging服务的注册中心，集成了哈希，随机，轮询，压力最小优先作为负载均衡的算法，RPC集成采用的是netty框架，采用异步传输，客户端APP 采用 Android Xamarin/ Xamarin.Forms 支持Android 5.0 以上 所有Android 最新版本。";
            await _blueToothService.Print(SelectedDevice, PrintMessage);
        });

        public PrintPageViewModel()
        {
            _blueToothService = DependencyService.Get<IBlueToothService>();
            BindDeviceList();
        }


        void BindDeviceList()
        {
            var list = _blueToothService.GetDeviceList();
            DeviceList.Clear();
            foreach (var item in list)
                DeviceList.Add(item);
        }
    }
}