using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.Interfaces
{ 
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}