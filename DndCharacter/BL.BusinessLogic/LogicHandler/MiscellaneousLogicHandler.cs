﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using BL.BusinessLogic.ViewModel;
using BL.BusinessLogic.ViewModels;
using DAL.Data.Repository;
using DAL.Model.Entities;

namespace BL.BusinessLogic.LogicHandler
{
    public class MiscellaneousLogicHandler
    {
        private readonly DndRepository _dndRepository;
        public MiscellaneousLogicHandler(DndRepository dndRepository)
        {
            _dndRepository = dndRepository;
        }

        #region Equipment
        public List<EquipmentViewModel> GetEquipments()
        {
            var entities = _dndRepository.GetAll<Equipment>().ToList();
            return Mapper.Map<List<Equipment>, List<EquipmentViewModel>>(entities);
        }

        public EquipmentViewModel GetEquipmentById(int id)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == id, false, a => a.TypeEquipment);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Equipment)));
            return Mapper.Map<Equipment, EquipmentViewModel>(entity);
        }

        public EquipmentViewModel CreateEquipment(EquipmentViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == viewModel.IdEquipment);
            if (entity != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Equipment)));
            else
                entity = Mapper.Map<EquipmentViewModel, Equipment>(viewModel);
            _dndRepository.Add(entity);
            _dndRepository.Commit();
            entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == entity.IdEquipment, false, a=> a.TypeEquipment);
            return Mapper.Map<Equipment, EquipmentViewModel>(entity);
        }

        public EquipmentViewModel UpdateEquipment(EquipmentViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == viewModel.IdEquipment);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Equipment)));

            entity.IdCTypeEquipment = viewModel.IdCTypeEquipment;
            entity.Name = viewModel.Name;
            entity.Cost = viewModel.Cost;

            _dndRepository.Update(entity);
            _dndRepository.Commit();
            return GetEquipmentById(entity.IdEquipment);
        }

        public void DeleteEquipment(int id)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == id, false, a => a.TypeEquipment);
            try
            {
                _dndRepository.Delete(entity);
                _dndRepository.Commit();
            }
            catch
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_Delete, nameof(Equipment)));
            }
        }
        #endregion

        #region Skill
        public List<SkillViewModel> GetSkills()
        {
            var skills = _dndRepository.GetAll<Skill>().ToList();
            return Mapper.Map<List<Skill>, List<SkillViewModel>>(skills);
        }

        public SkillViewModel GetSkillById(int id)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == id, false, a => a.AbilityScoreSkill);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public SkillViewModel CreateSkill(SkillViewModel viewModel)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill==viewModel.IdSkill);
            if (skill != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_AlredyExist, nameof(Skill)));
            skill = Mapper.Map<SkillViewModel, Skill>(viewModel);
            _dndRepository.Add(skill);
            _dndRepository.Commit();
            skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == skill.IdSkill, false, a=> a.AbilityScoreSkill);
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public SkillViewModel UpdateSkill(SkillViewModel viewModel)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == viewModel.IdSkill);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));

            skill.IdCAbilityScore = viewModel.IdCAbilityScore;
            skill.Name = viewModel.Name;
            _dndRepository.Update(skill);
            _dndRepository.Commit();
            skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == viewModel.IdSkill, false, a=> a.AbilityScoreSkill); ;
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public void DeleteSkill(int id)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == id);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));
            _dndRepository.Delete(skill);
            _dndRepository.Commit();
        }
        #endregion

        #region Feat
        public List<FeatViewModel> GetFeats()
        {
            var feats = _dndRepository.GetAll<Feat>().ToList();
            return Mapper.Map<List<Feat>, List<FeatViewModel>>(feats);
        }

        public FeatViewModel GetFeatById(int id)
        {
            var feat = _dndRepository.GetSingle<Feat>(a => a.Id == id, false, a => a.Race, a => a.FeatFeatures);
            return Mapper.Map<Feat, FeatViewModel>(feat);
        }

        #endregion

        #region FeatFeature

        public List<FeatureViewModel> GetFeatures()
        {
            var features = _dndRepository.GetAll<Feature>().ToList();
            return Mapper.Map<List<Feature>, List<FeatureViewModel>>(features);
        }

        public FeatureViewModel GetFeaturesById(int id)
        {
            var feature = _dndRepository.GetSingle<Feature>(a => a.Id == id, false, a=> a.TypeFeat);
            if (feature == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Feature)));
            return Mapper.Map<Feature, FeatureViewModel>(feature);
        }

        public FeatureViewModel CreateFeature(FeatureViewModel viewModel)
        {
            var feat = _dndRepository.GetSingle<Feature>(a => a.Id == viewModel.Id, false);
            if (feat != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Feature)));
            feat = Mapper.Map<FeatureViewModel, Feature>(viewModel);
            _dndRepository.Add(feat);
            _dndRepository.Commit();
            feat = _dndRepository.GetSingle<Feature>(a => a.Id == feat.Id, false);
            return Mapper.Map<Feature, FeatureViewModel>(feat);
        }

        public FeatureViewModel UpdateFeature(FeatureViewModel viewModel)
        {
            var feature = _dndRepository.GetSingle<Feature>(a => a.Id == viewModel.Id, false);
            if (feature == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Feature)));
            feature.IdFeat = viewModel.IdFeat;
            feature.Description = viewModel.Description;
            feature.IdCTypeFeat = viewModel.IdCTypeFeat;
            feature.AddedAmount = viewModel.AddedAmount;
            feature.AddedDescription = viewModel.AddedDescription;
            _dndRepository.Update(feature);
            _dndRepository.Commit();
            feature = _dndRepository.GetSingle<Feature>(a => a.Id == viewModel.Id, false);
            return Mapper.Map<Feature, FeatureViewModel>(feature);
        }

        public void DeleteFeature(int id)
        {
            var feature = _dndRepository.GetSingle<Feature>(a => a.Id == id, false);
            if (feature == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Feature)));
            _dndRepository.Delete(feature);
            _dndRepository.Commit();
        }
        #endregion

        #region Collection
        /// <summary>
        /// Get the list of collections
        /// </summary>
        /// <returns></returns>
        public List<CollectionViewModel> GetCollections()
        {
            var collections = _dndRepository.GetAll<Collection>().ToList();
            return Mapper.Map<List<Collection>, List<CollectionViewModel>>(collections);
        }
        /// <summary>
        /// Get a specific collection by given id
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns></returns>
        public CollectionViewModel GetCollectionById(int idCollection)
        {
            var collection = _dndRepository.GetSingle<Collection>(a => a.Id == idCollection, false, a=>a.DataCollections);
            return Mapper.Map<Collection, CollectionViewModel>(collection);
        }
        /// <summary>
        /// Create a new collection by given CollectionVieWModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public CollectionViewModel CreateCollection(CollectionViewModel viewModel)
        {
            var entity = Mapper.Map<CollectionViewModel, Collection>(viewModel);
            _dndRepository.Add(entity);
            _dndRepository.Commit();
            viewModel = Mapper.Map<Collection, CollectionViewModel>(_dndRepository.GetSingle<Collection>(a => a.Id == entity.Id));
            return viewModel;
        }
        /// <summary>
        /// Update a collection by given CollectionViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public CollectionViewModel UpdateCollection(CollectionViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Collection>(a => a.Id == viewModel.Id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Collection)));
            entity.Name = viewModel.Name;
            _dndRepository.Update(entity);
            _dndRepository.Commit();

            viewModel = Mapper.Map<Collection, CollectionViewModel>(_dndRepository.GetSingle<Collection>(a => a.Id == viewModel.Id));
            return viewModel;
        }
        /// <summary>
        /// Delete a collection by given id
        /// </summary>
        /// <param name="idCollection"></param>
        public void DeleteCollection(int idCollection)
        {
            var entity = _dndRepository.GetSingle<Collection>(a => a.Id == idCollection);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Collection)));

            try
            {
                _dndRepository.Delete(entity);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_Terminate, nameof(Collection)));
            }

        }
        #endregion

        #region DataCollection 
        /// <summary>
        /// Get the datacollection of a collecion
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns>List of DataCollectionViewModel</returns>
        public List<DataCollectionViewModel> GetDataCollectionByIdCollection(int idCollection)
        {
            var dataCollection = _dndRepository.GetAllWhere(new List<System.Linq.Expressions.Expression<Func<DataCollection, bool>>>() { a => a.IdCollection == idCollection }).ToList();
            if (dataCollection == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(DataCollection)));
            return Mapper.Map<List<DataCollection>, List<DataCollectionViewModel>>(dataCollection);
        }
        /// <summary>
        /// Update DataCollections in a collection
        /// </summary>
        /// <param name="idCollection"></param>
        /// <param name="dataCollections"></param>
        /// <returns>CollectionViewModel</returns>
        public CollectionViewModel SetDataCollectionToCollection(int idCollection, List<DataCollectionViewModel> dataCollections)
        {
            var collection = _dndRepository.GetSingle<Collection>(a => a.Id == idCollection, false, a => a.DataCollections);
            if (collection == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Collection)));
            collection.DataCollections.Clear();
            foreach(var data in dataCollections)
            {
                collection.DataCollections.Add(new DataCollection()
                {
                    Value = data.Value,
                    IdCollection = idCollection
                });
            }
            _dndRepository.Update(collection);
            _dndRepository.Commit();
            var viewModel = Mapper.Map<Collection, CollectionViewModel>(_dndRepository.GetSingle<Collection>(a => a.Id == idCollection, false, a => a.DataCollections));
            return viewModel;
        }
        #endregion

        #region Spells

        public List<SpellViewModel> GetSpells()
        {
            var spells = _dndRepository.GetAll<Spell>().ToList();
            return Mapper.Map<List<Spell>, List<SpellViewModel>>(spells);
        }

        public SpellViewModel GetSpellById(int id)
        {
            var spell = _dndRepository.GetSingle<Spell>(a => a.Id == id);
            return Mapper.Map<Spell, SpellViewModel>(spell);
        }

        public SpellViewModel CreateSpell(SpellViewModel viewModel)
        {
            var entity = Mapper.Map<SpellViewModel, Spell>(viewModel);
            _dndRepository.Add(entity);
            _dndRepository.Commit();

            return GetSpellById(entity.Id);
        }

        public SpellViewModel UpdateSpell(SpellViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Spell>(a => a.Id == viewModel.Id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Spell)));
            entity.Name = viewModel.Name;
            entity.Description = viewModel.Description;

            _dndRepository.Update(entity);
            _dndRepository.Commit();

            return GetSpellById(viewModel.Id);
        }

        public void DeleteSpell(int id)
        {
            var entity = _dndRepository.GetSingle<Spell>(a => a.Id == id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Spell)));

            try
            {
                _dndRepository.Delete(entity);
                _dndRepository.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Terminate, nameof(Spell)));
            }
        }

        #endregion

        #region Class
        public List<ClassViewModel> GetClasses()
        {
            var classes = _dndRepository.GetAll<Class>().ToList();
            return Mapper.Map<List<Class>, List<ClassViewModel>>(classes);
        }

        public ClassViewModel GetClassById(int id)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == id, false);
            return Mapper.Map<Class, ClassViewModel>(entity);
        }

        public ClassViewModel CreateClass(ClassViewModel viewModel)
        {
            var classEntity = Mapper.Map<ClassViewModel, Class>(viewModel);
            if (_dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id) != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Class)));

            _dndRepository.Add(classEntity);
            _dndRepository.Commit();
            classEntity = _dndRepository.GetSingle<Class>(a => a.Id == classEntity.Id, false);
            return Mapper.Map<Class, ClassViewModel>(classEntity);
        }

        public ClassViewModel UpdateClass(ClassViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Class)));
            entity.Name = viewModel.Name;
            _dndRepository.Update(entity);
            _dndRepository.Commit();
            return Mapper.Map<Class, ClassViewModel>(_dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id));
        }

        public void DeleteClass(int id)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Class)));
            _dndRepository.Delete(entity);
            _dndRepository.Commit();
        }

        public List<SpellViewModel> GetSpellByClass(int idClass, int spellLevel = 0)
        {
            var isClass = _dndRepository.GetSingle<Class>(a => a.Id == idClass);
            if (isClass == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Class)));
            var whereExpression = new List<Expression<Func<SpellClass, bool>>>()
            {
                a=> a.IdClass == idClass
            };
            if (spellLevel > 0)
                whereExpression.Add(a => a.Spell.Level == spellLevel);
            var spells = _dndRepository.GetAllWhere(whereExpression, null, false, a=> a.Spell);
            var listSpell = new List<SpellViewModel>();
            foreach(var spell in spells)
            {
                listSpell.Add(Mapper.Map<Spell, SpellViewModel>(spell.Spell));
            }
            return listSpell;
        }
        #endregion
    }
}
