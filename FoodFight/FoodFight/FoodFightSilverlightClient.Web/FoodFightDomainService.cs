
namespace FoodFightSilverlightClient.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the FoodFightEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class FoodFightDomainService : LinqToEntitiesDomainService<FoodFightEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EquipmentTags' query.
        public IQueryable<EquipmentTag> GetEquipmentTags()
        {
            return this.ObjectContext.EquipmentTags;
        }

        public void InsertEquipmentTag(EquipmentTag equipmentTag)
        {
            if ((equipmentTag.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(equipmentTag, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EquipmentTags.AddObject(equipmentTag);
            }
        }

        public void UpdateEquipmentTag(EquipmentTag currentEquipmentTag)
        {
            this.ObjectContext.EquipmentTags.AttachAsModified(currentEquipmentTag, this.ChangeSet.GetOriginal(currentEquipmentTag));
        }

        public void DeleteEquipmentTag(EquipmentTag equipmentTag)
        {
            if ((equipmentTag.EntityState == EntityState.Detached))
            {
                this.ObjectContext.EquipmentTags.Attach(equipmentTag);
            }
            this.ObjectContext.EquipmentTags.DeleteObject(equipmentTag);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'FoodGroups' query.
        public IQueryable<FoodGroup> GetFoodGroups()
        {
            return this.ObjectContext.FoodGroups;
        }

        public void InsertFoodGroup(FoodGroup foodGroup)
        {
            if ((foodGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(foodGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.FoodGroups.AddObject(foodGroup);
            }
        }

        public void UpdateFoodGroup(FoodGroup currentFoodGroup)
        {
            this.ObjectContext.FoodGroups.AttachAsModified(currentFoodGroup, this.ChangeSet.GetOriginal(currentFoodGroup));
        }

        public void DeleteFoodGroup(FoodGroup foodGroup)
        {
            if ((foodGroup.EntityState == EntityState.Detached))
            {
                this.ObjectContext.FoodGroups.Attach(foodGroup);
            }
            this.ObjectContext.FoodGroups.DeleteObject(foodGroup);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ingredients' query.
        public IQueryable<Ingredient> GetIngredients()
        {
            return this.ObjectContext.Ingredients;
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            if ((ingredient.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ingredient, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ingredients.AddObject(ingredient);
            }
        }

        public void UpdateIngredient(Ingredient currentIngredient)
        {
            this.ObjectContext.Ingredients.AttachAsModified(currentIngredient, this.ChangeSet.GetOriginal(currentIngredient));
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            if ((ingredient.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Ingredients.Attach(ingredient);
            }
            this.ObjectContext.Ingredients.DeleteObject(ingredient);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Recipes' query.
        public IQueryable<Recipe> GetRecipes()
        {
            return this.ObjectContext.Recipes;
        }

        public Recipe GetRecipe(int RecipeID)
        {
            return this.ObjectContext.Recipes.Include("RecipeEquipmentTags").Include("RecipeFoodGroups").Include("RecipeIngredients").Include("RecipeSteps").Include("RecipeTags").Where(R => R.RecipeID == RecipeID).FirstOrDefault();
        }

        public void InsertRecipe(Recipe recipe)
        {
            if ((recipe.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipe, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Recipes.AddObject(recipe);
            }
        }

        public void UpdateRecipe(Recipe currentRecipe)
        {
            this.ObjectContext.Recipes.AttachAsModified(currentRecipe, this.ChangeSet.GetOriginal(currentRecipe));
        }

        public void DeleteRecipe(Recipe recipe)
        {
            if ((recipe.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Recipes.Attach(recipe);
            }
            this.ObjectContext.Recipes.DeleteObject(recipe);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RecipeEquipmentTags' query.
        public IQueryable<RecipeEquipmentTag> GetRecipeEquipmentTags()
        {
            return this.ObjectContext.RecipeEquipmentTags;
        }

        public void InsertRecipeEquipmentTag(RecipeEquipmentTag recipeEquipmentTag)
        {
            if ((recipeEquipmentTag.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipeEquipmentTag, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RecipeEquipmentTags.AddObject(recipeEquipmentTag);
            }
        }

        public void UpdateRecipeEquipmentTag(RecipeEquipmentTag currentRecipeEquipmentTag)
        {
            this.ObjectContext.RecipeEquipmentTags.AttachAsModified(currentRecipeEquipmentTag, this.ChangeSet.GetOriginal(currentRecipeEquipmentTag));
        }

        public void DeleteRecipeEquipmentTag(RecipeEquipmentTag recipeEquipmentTag)
        {
            if ((recipeEquipmentTag.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RecipeEquipmentTags.Attach(recipeEquipmentTag);
            }
            this.ObjectContext.RecipeEquipmentTags.DeleteObject(recipeEquipmentTag);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RecipeFoodGroups' query.
        public IQueryable<RecipeFoodGroup> GetRecipeFoodGroups()
        {
            return this.ObjectContext.RecipeFoodGroups;
        }

        public void InsertRecipeFoodGroup(RecipeFoodGroup recipeFoodGroup)
        {
            if ((recipeFoodGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipeFoodGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RecipeFoodGroups.AddObject(recipeFoodGroup);
            }
        }

        public void UpdateRecipeFoodGroup(RecipeFoodGroup currentRecipeFoodGroup)
        {
            this.ObjectContext.RecipeFoodGroups.AttachAsModified(currentRecipeFoodGroup, this.ChangeSet.GetOriginal(currentRecipeFoodGroup));
        }

        public void DeleteRecipeFoodGroup(RecipeFoodGroup recipeFoodGroup)
        {
            if ((recipeFoodGroup.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RecipeFoodGroups.Attach(recipeFoodGroup);
            }
            this.ObjectContext.RecipeFoodGroups.DeleteObject(recipeFoodGroup);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RecipeIngredients' query.
        public IQueryable<RecipeIngredient> GetRecipeIngredients()
        {
            return this.ObjectContext.RecipeIngredients;
        }

        public void InsertRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            if ((recipeIngredient.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipeIngredient, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RecipeIngredients.AddObject(recipeIngredient);
            }
        }

        public void UpdateRecipeIngredient(RecipeIngredient currentRecipeIngredient)
        {
            this.ObjectContext.RecipeIngredients.AttachAsModified(currentRecipeIngredient, this.ChangeSet.GetOriginal(currentRecipeIngredient));
        }

        public void DeleteRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            if ((recipeIngredient.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RecipeIngredients.Attach(recipeIngredient);
            }
            this.ObjectContext.RecipeIngredients.DeleteObject(recipeIngredient);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RecipeSteps' query.
        public IQueryable<RecipeStep> GetRecipeSteps()
        {
            return this.ObjectContext.RecipeSteps;
        }

        public void InsertRecipeStep(RecipeStep recipeStep)
        {
            if ((recipeStep.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipeStep, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RecipeSteps.AddObject(recipeStep);
            }
        }

        public void UpdateRecipeStep(RecipeStep currentRecipeStep)
        {
            this.ObjectContext.RecipeSteps.AttachAsModified(currentRecipeStep, this.ChangeSet.GetOriginal(currentRecipeStep));
        }

        public void DeleteRecipeStep(RecipeStep recipeStep)
        {
            if ((recipeStep.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RecipeSteps.Attach(recipeStep);
            }
            this.ObjectContext.RecipeSteps.DeleteObject(recipeStep);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RecipeTags' query.
        public IQueryable<RecipeTag> GetRecipeTags()
        {
            return this.ObjectContext.RecipeTags;
        }

        public void InsertRecipeTag(RecipeTag recipeTag)
        {
            if ((recipeTag.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(recipeTag, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RecipeTags.AddObject(recipeTag);
            }
        }

        public void UpdateRecipeTag(RecipeTag currentRecipeTag)
        {
            this.ObjectContext.RecipeTags.AttachAsModified(currentRecipeTag, this.ChangeSet.GetOriginal(currentRecipeTag));
        }

        public void DeleteRecipeTag(RecipeTag recipeTag)
        {
            if ((recipeTag.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RecipeTags.Attach(recipeTag);
            }
            this.ObjectContext.RecipeTags.DeleteObject(recipeTag);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'States' query.
        public IQueryable<State> GetStates()
        {
            return this.ObjectContext.States;
        }

        public void InsertState(State state)
        {
            if ((state.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(state, EntityState.Added);
            }
            else
            {
                this.ObjectContext.States.AddObject(state);
            }
        }

        public void UpdateState(State currentState)
        {
            this.ObjectContext.States.AttachAsModified(currentState, this.ChangeSet.GetOriginal(currentState));
        }

        public void DeleteState(State state)
        {
            if ((state.EntityState == EntityState.Detached))
            {
                this.ObjectContext.States.Attach(state);
            }
            this.ObjectContext.States.DeleteObject(state);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tags' query.
        public IQueryable<Tag> GetTags()
        {
            return this.ObjectContext.Tags;
        }

        public void InsertTag(Tag tag)
        {
            if ((tag.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tag, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tags.AddObject(tag);
            }
        }

        public void UpdateTag(Tag currentTag)
        {
            this.ObjectContext.Tags.AttachAsModified(currentTag, this.ChangeSet.GetOriginal(currentTag));
        }

        public void DeleteTag(Tag tag)
        {
            if ((tag.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Tags.Attach(tag);
            }
            this.ObjectContext.Tags.DeleteObject(tag);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Units' query.
        public IQueryable<Unit> GetUnits()
        {
            return this.ObjectContext.Units;
        }

        public void InsertUnit(Unit unit)
        {
            if ((unit.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(unit, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Units.AddObject(unit);
            }
        }

        public void UpdateUnit(Unit currentUnit)
        {
            this.ObjectContext.Units.AttachAsModified(currentUnit, this.ChangeSet.GetOriginal(currentUnit));
        }

        public void DeleteUnit(Unit unit)
        {
            if ((unit.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Units.Attach(unit);
            }
            this.ObjectContext.Units.DeleteObject(unit);
        }
    }
}


