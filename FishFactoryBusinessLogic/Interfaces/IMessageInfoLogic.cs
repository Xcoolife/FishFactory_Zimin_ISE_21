using FishFactoryBusinessLogic.ViewModels;
using FishFactoryBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
