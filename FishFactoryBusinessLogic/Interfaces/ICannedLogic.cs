using System;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface ICannedLogic
    {
        List<CannedViewModel> Read(CannedBindingModel model);
        void CreateOrUpdate(CannedBindingModel model);
        void Delete(CannedBindingModel model);
    }
}