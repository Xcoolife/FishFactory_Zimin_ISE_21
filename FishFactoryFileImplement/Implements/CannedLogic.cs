using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishFactoryFileImplement.Implements
{
    public class CannedLogic : ICannedLogic
    {
        private readonly FileDataListSingleton source;
        public CannedLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(CannedBindingModel model)
        {
            Canned element = source.Canneds.FirstOrDefault(rec => rec.CannedName ==
           model.CannedName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть консервы с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Canneds.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new Canned { Id = maxId + 1 };
                source.Canneds.Add(element);
            }
            element.CannedName = model.CannedName;
            element.Price = model.Price;
            source.CannedComponents.RemoveAll(rec => rec.CannedId == model.Id &&
           !model.CannedComponents.ContainsKey(rec.ComponentId));
            var updateComponents = source.CannedComponents.Where(rec => rec.CannedId ==
           model.Id && model.CannedComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count =
               model.CannedComponents[updateComponent.ComponentId].Item2;
                model.CannedComponents.Remove(updateComponent.ComponentId);
            }
            int maxPCId = source.CannedComponents.Count > 0 ?
           source.CannedComponents.Max(rec => rec.Id) : 0;
            foreach (var pc in model.CannedComponents)
            {
                source.CannedComponents.Add(new CannedComponent
                {
                    Id = ++maxPCId,
                    CannedId = element.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(CannedBindingModel model)
        {
            source.CannedComponents.RemoveAll(rec => rec.CannedId == model.Id);
            Canned element = source.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Canneds.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<CannedViewModel> Read(CannedBindingModel model)
        {
            return source.Canneds
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new CannedViewModel
            {
                Id = rec.Id,
                CannedName = rec.CannedName,
                Price = rec.Price,
                CannedComponents = source.CannedComponents
            .Where(recPC => recPC.CannedId == rec.Id)
           .ToDictionary(recPC => recPC.ComponentId, recPC =>
            (source.Components.FirstOrDefault(recC => recC.Id ==
           recPC.ComponentId)?.ComponentName, recPC.Count))
            })
            .ToList();
        }
    }
}