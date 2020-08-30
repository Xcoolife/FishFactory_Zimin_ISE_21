using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishFactoryDatabaseImplement.Implements
{
    public class CannedLogic : ICannedLogic
    {
        public void CreateOrUpdate(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Canned element = context.Canneds.FirstOrDefault(rec =>
                       rec.CannedName == model.CannedName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть консервы с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Canneds.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Canned();
                            context.Canneds.Add(element);
                        }
                        element.CannedName = model.CannedName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var cannedComponents = context.CannedComponents.Where(rec
                           => rec.CannedId == model.Id.Value).ToList();
                            context.CannedComponents.RemoveRange(cannedComponents.Where(rec =>
                            !model.CannedComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in cannedComponents)
                            {
                                updateComponent.Count =
                               model.CannedComponents[updateComponent.ComponentId].Item2;

                                model.CannedComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.CannedComponents)
                        {
                            context.CannedComponents.Add(new CannedComponent
                            {
                                CannedId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.CannedComponents.RemoveRange(context.CannedComponents.Where(rec =>
                        rec.CannedId == model.Id));
                        Canned element = context.Canneds.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Canneds.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<CannedViewModel> Read(CannedBindingModel model)
        {
            using (var context = new FishFactoryDatabase())
            {
                return context.Canneds
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new CannedViewModel
               {
                   Id = rec.Id,
                   CannedName = rec.CannedName,
                   Price = rec.Price,
                   CannedComponents = context.CannedComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.CannedId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}