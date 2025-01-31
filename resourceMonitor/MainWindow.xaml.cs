using System.Management;
using System.Windows;

namespace resourceMonitor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnCreateGpu()
    {
        List<string> gpuNames = new List<string>();
        List<string> gpuIds = new List<string>();

        ManagementObjectSearcher vida = new ManagementObjectSearcher("SELECT Description FROM Win32_VideoController");

        ManagementObjectSearcher tempFind =
            new ManagementObjectSearcher("root\\WMI",
                "SELECT * FROM MSAcpi_ThermalZoneTemperature");

        foreach (var name in vida.Get())
        {
            if (name["CurrentBitsPerPixel"] != null && name["CurrentHorizontalResolution"] != null)
            {
                gpuNames.Add(name["Description"].ToString());
                gpuIds.Add(name["DeviceID"].ToString());
            }
        }

        List<int> temps = new List<int>(gpuNames.Count);
        int _maxTemp;
        int _avgTemp;

        int _load;

        int _memUsed;
        int _memTotal;

        int _fanSpd;
    }

    public void Update(string id)
    {
        GetTemp(id);

        GetLoad(id);

        GetMem(id);

        GetFan(id);
    }

    private void GetTemp(string id)
    {
        _temp = ;
        _maxTemp = 0;
        _avgTemp = 0;
    }
}