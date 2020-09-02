using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.HelperModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FishFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly ICannedLogic cannedLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(ICannedLogic cannedLogic, IComponentLogic componentLogic,
       IOrderLogic orderLLogic)
        {
            this.cannedLogic = cannedLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }
        public List<ReportCannedComponentViewModel> GetCannedComponent()
        {
            var Canneds = cannedLogic.Read(null);
            var list = new List<ReportCannedComponentViewModel>();
            foreach (var Canned in Canneds)
            {
                foreach (var cd in Canned.CannedComponents)
                {
                    var record = new ReportCannedComponentViewModel
                    {
                        CannedName = Canned.CannedName,
                        ComponentName = cd.Value.Item1,
                        Count = cd.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
                        .Read(new OrderBindingModel
                        {
                            DateFrom = model.DateFrom,
                            DateTo = model.DateTo
                        })
                        .GroupBy(rec => rec.DateCreate.Date)
                        .OrderBy(recG => recG.Key)
                        .ToList();
            return list;
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveCannedsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список консерв",
                Canneds = cannedLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveCannedsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список консерв по компонентам",
                CannedComponents = GetCannedComponent(),
            });
        }
    }
}