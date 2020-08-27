using FishFactoryBusinessLogic.Enums;
using FishFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FishFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string CannedFileName = "C:\\Users\\zimin\\source\\FishFactory_Zimin_ISE_21.git\\Canned.xml";
        private readonly string OrderFileName = "C:\\Users\\zimin\\source\\FishFactory_Zimin_ISE_21.git\\Order.xml";
        private readonly string ComponentFileName = "C:\\Users\\zimin\\source\\FishFactory_Zimin_ISE_21.git\\Component.xml";
        private readonly string CannedComponentFileName = "C:\\Users\\zimin\\source\\FishFactory_Zimin_ISE_21.git\\CannedComponent.xml";
        public List<Canned> Canneds { get; set; }
        public List<Order> Orders { get; set; }
        public List<Component> Components { get; set; }
        public List<CannedComponent> CannedComponents { get; set; }
        private FileDataListSingleton()
        {
            Canneds = LoadCanneds();
            Orders = LoadOrders();
            Components = LoadComponents();
            CannedComponents = LoadCannedComponents();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveCanneds();
            SaveOrders();
            SaveComponents();
            SaveCannedComponents();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CannedId = Convert.ToInt32(elem.Element("CannedId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Canned> LoadCanneds()
        {
            var list = new List<Canned>();
            if (File.Exists(CannedFileName))
            {
                XDocument xDocument = XDocument.Load(CannedFileName);
                var xElements = xDocument.Root.Elements("Canned").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Canned
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CannedName = elem.Element("CannedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<CannedComponent> LoadCannedComponents()
        {
            var list = new List<CannedComponent>();
            if (File.Exists(CannedComponentFileName))
            {
                XDocument xDocument = XDocument.Load(CannedComponentFileName);
                var xElements = xDocument.Root.Elements("CannedComponent").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new CannedComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CannedId = Convert.ToInt32(elem.Element("CannedId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var Component in Components)
                {
                    xElement.Add(new XElement("Components",
                    new XAttribute("Id", Component.Id),
                    new XElement("ComponentName", Component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("CannedId", order.CannedId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveCanneds()
        {
            if (Canneds != null)
            {
                var xElement = new XElement("Canneds");
                foreach (var Canned in Canneds)
                {
                    xElement.Add(new XElement("Canned",
                    new XAttribute("Id", Canned.Id),
                    new XElement("CannedName", Canned.CannedName),
                    new XElement("Price", Canned.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(CannedFileName);
            }
        }
        private void SaveCannedComponents()
        {
            if (CannedComponents != null)
            {
                var xElement = new XElement("CannedComponents");
                foreach (var CannedComponent in CannedComponents)
                {
                    xElement.Add(new XElement("CannedComponents",
                    new XAttribute("Id", CannedComponent.Id),
                    new XElement("CannedId", CannedComponent.CannedId),
                    new XElement("ComponentId", CannedComponent.ComponentId),
                    new XElement("Count", CannedComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(CannedComponentFileName);
            }
        }
    }
}