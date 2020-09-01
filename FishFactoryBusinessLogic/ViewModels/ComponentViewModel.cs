using System;
using System.Collections.Generic;
using System.ComponentModel;
using FishFactoryBusinessLogic.Attributes;
using FishFactoryBusinessLogic.Enums;

namespace FishFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel : BaseViewModel
    {
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ComponentName"
        };
    }
}