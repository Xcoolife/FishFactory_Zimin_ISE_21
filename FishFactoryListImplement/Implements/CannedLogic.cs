using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryListImplement.Models;

namespace FishFactoryListImplement.Implements
{
    public class CannedLogic : ICannedLogic
    {
        private readonly DataListSingleton source;
        public CannedLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(CannedBindingModel model)
        {
            Canned tempCanned = model.Id.HasValue ? null : new Canned { Id = 1 };
            foreach (var canned in source.Canneds)
            {
                if (canned.CannedName == model.CannedName && canned.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && canned.Id >= tempCanned.Id)
                {
                    tempCanned.Id = canned.Id + 1;
                }
                else if (model.Id.HasValue && canned.Id == model.Id)
                {
                    tempCanned = canned;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempCanned == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempCanned);
            }
            else
            {
                source.Canneds.Add(CreateModel(model, tempCanned));
            }
        }
        public void Delete(CannedBindingModel model)
        {
            for (int i = 0; i < source.CannedComponents.Count; ++i)
            {
                if (source.CannedComponents[i].CannedId == model.Id)
                {
                    source.CannedComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Canneds.Count; ++i)
            {
                if (source.Canneds[i].Id == model.Id)
                {
                    source.Canneds.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Canned CreateModel(CannedBindingModel model, Canned canned)
        {
            canned.CannedName = model.CannedName;
            canned.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.CannedComponents.Count; ++i)
            {
                if (source.CannedComponents[i].Id > maxPCId)
                {
                    maxPCId = source.CannedComponents[i].Id;
                }
                if (source.CannedComponents[i].CannedId == canned.Id)
                {
                    if
                    (model.CannedComponents.ContainsKey(source.CannedComponents[i].ComponentId))
                    {
                        source.CannedComponents[i].Count =
                        model.CannedComponents[source.CannedComponents[i].ComponentId].Item2;
                        model.CannedComponents.Remove(source.CannedComponents[i].ComponentId);
                    }
                    else
                    {
                        source.CannedComponents.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.CannedComponents)
            {
                source.CannedComponents.Add(new CannedComponent
                {
                    Id = ++maxPCId,
                    CannedId = canned.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return canned;
        }
        public List<CannedViewModel> Read(CannedBindingModel model)
        {
            List<CannedViewModel> result = new List<CannedViewModel>();
            foreach (var component in source.Canneds)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private CannedViewModel CreateViewModel(Canned canned)
        {
            Dictionary<int, (string, int)> cannedComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in source.CannedComponents)
            {
                if (pc.CannedId == canned.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    cannedComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new CannedViewModel
            {
                Id = canned.Id,
                CannedName = canned.CannedName,
                Price = canned.Price,
                CannedComponents = cannedComponents
            };
        }
    }
}