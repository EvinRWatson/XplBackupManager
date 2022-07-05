using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using XplLib;
using XplService;
namespace XplClient;

public partial class MainPage : ContentPage
{
    private readonly IConfiguration Configuration;

    public static IEnumerable<String> baseDataStrings { get; private set; }

    public MainPage()
	{
		InitializeComponent();

        XplLib.Objects.Settings settings = new XplLib.Objects.Settings();

        List<XplLib.Objects.BaseData> baseData = XplLib.Objects.BaseData.GetList();
        List<String> strings = new List<String>();
        foreach (XplLib.Objects.BaseData entry in baseData)
        {
            strings.Add(entry.ReturnPrintString());
        }
        baseDataStrings = strings;
        
       

        ListView listView = new ListView();
        listView.SetBinding(ItemsView.ItemsSourceProperty, "baseDataStrings");

        using Process xplService = new Process();
        string XplDirectory = XplLib.Func.GetXplDirectory();
        xplService.StartInfo.FileName = XplDirectory + settings.get("XplServiceRelativePath");
        xplService.StartInfo.CreateNoWindow = true;
        xplService.Start();

        
    }

	private void OnSettingsClicked(object sender, EventArgs e)
	{
        //SemanticScreenReader.Announce(Settings.Text);
    }

    private void OnShowLogs(object sender, EventArgs e)
    {

    }

    private void OnRestartService(object sender, EventArgs e)
    {

    }
}

public class BaseDataUI
{
    public static IEnumerable<String> baseDataStrings { get; private set; }

    static BaseDataUI()
    {
        List<XplLib.Objects.BaseData> baseData = XplLib.Func.ConvertEntriesToObjects(XplLib.Func.ReadEntriesFile());
        List<String> strings = new List<String>();
        foreach (XplLib.Objects.BaseData entry in baseData)
        {
            strings.Add(entry.ReturnPrintString());
        }
        baseDataStrings = strings;
    }
}