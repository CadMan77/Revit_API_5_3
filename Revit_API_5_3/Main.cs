// Создайте вкладку на ленте в Revit, панель и две кнопки:
// - 1-ая запускает приложение задания 5.1;
// - 2-ая запускает приложение задания 5.2.

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_API_5_3
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "ITMO Revit-API";
            application.CreateRibbonTab(tabName);

            string panelName = "Тема 5";
            RibbonPanel myPanel = application.CreateRibbonPanel(tabName, panelName);

            string u51 = "Revit_API_5_1";
            string u52 = "Revit_API_5_2";
            string utilsFolder = @"C:\ProgramData\RevitAPITraining\";

            string assy_51_Path = Path.Combine(utilsFolder, $"{u51}.dll");
            string assy_52_Path = Path.Combine(utilsFolder, $"{u52}.dll");

            //TaskDialog.Show("1", assy_51_Path+$"{Environment.NewLine}"+assy_52_Path);

            PushButtonData pbd_5_1 = new PushButtonData("button_5_1", "Статистика (5.1)", assy_51_Path, $"{u51}.Main");
            PushButtonData pbd_5_2 = new PushButtonData("button_5_2", "Тип стен (5.2)", assy_52_Path, $"{u52}.Main");

            //myPanel.AddItem(pbd_5_1);
            myPanel.AddStackedItems(pbd_5_1, pbd_5_2);

            return Result.Succeeded;
        }
    }
}
