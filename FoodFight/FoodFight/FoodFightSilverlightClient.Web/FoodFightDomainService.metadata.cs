
namespace FoodFightSilverlightClient.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies EquipmentTagMetadata as the class
    // that carries additional metadata for the EquipmentTag class.
    [MetadataTypeAttribute(typeof(EquipmentTag.EquipmentTagMetadata))]
    public partial class EquipmentTag
    {

        // This class allows you to attach custom attributes to properties
        // of the EquipmentTag class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EquipmentTagMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EquipmentTagMetadata()
            {
            }

            public int EquipmentTagID { get; set; }

            public string Name { get; set; }

            public EntityCollection<RecipeEquipmentTag> RecipeEquipmentTags { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies FoodGroupMetadata as the class
    // that carries additional metadata for the FoodGroup class.
    [MetadataTypeAttribute(typeof(FoodGroup.FoodGroupMetadata))]
    public partial class FoodGroup
    {

        // This class allows you to attach custom attributes to properties
        // of the FoodGroup class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class FoodGroupMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private FoodGroupMetadata()
            {
            }

            public int FoodGroupID { get; set; }

            public string Name { get; set; }

            public EntityCollection<RecipeFoodGroup> RecipeFoodGroups { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies IngredientMetadata as the class
    // that carries additional metadata for the Ingredient class.
    [MetadataTypeAttribute(typeof(Ingredient.IngredientMetadata))]
    public partial class Ingredient
    {

        // This class allows you to attach custom attributes to properties
        // of the Ingredient class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class IngredientMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private IngredientMetadata()
            {
            }

            public int IngredientID { get; set; }

            public string Name { get; set; }

            public EntityCollection<RecipeIngredient> RecipeIngredients { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeMetadata as the class
    // that carries additional metadata for the Recipe class.
    [MetadataTypeAttribute(typeof(Recipe.RecipeMetadata))]
    public partial class Recipe
    {

        // This class allows you to attach custom attributes to properties
        // of the Recipe class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeMetadata()
            {
            }

            public Nullable<TimeSpan> CookingTime { get; set; }

            public string Description { get; set; }

            public string Name { get; set; }

            public byte[] Picture { get; set; }

            [Include]
            public EntityCollection<RecipeEquipmentTag> RecipeEquipmentTags { get; set; }

            [Include]
            public EntityCollection<RecipeFoodGroup> RecipeFoodGroups { get; set; }

            public int RecipeID { get; set; }

            [Include]
            public EntityCollection<RecipeIngredient> RecipeIngredients { get; set; }

            [Include]
            public EntityCollection<RecipeStep> RecipeSteps { get; set; }

            [Include]
            public EntityCollection<RecipeTag> RecipeTags { get; set; }

            [DefaultValue(4)]
            public int Serves { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeEquipmentTagMetadata as the class
    // that carries additional metadata for the RecipeEquipmentTag class.
    [MetadataTypeAttribute(typeof(RecipeEquipmentTag.RecipeEquipmentTagMetadata))]
    public partial class RecipeEquipmentTag
    {

        // This class allows you to attach custom attributes to properties
        // of the RecipeEquipmentTag class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeEquipmentTagMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeEquipmentTagMetadata()
            {
            }

            public EquipmentTag EquipmentTag { get; set; }

            public int EquipmentTagID { get; set; }

            public Recipe Recipe { get; set; }

            public int RecipeEquipmentTagID { get; set; }

            public int RecipeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeFoodGroupMetadata as the class
    // that carries additional metadata for the RecipeFoodGroup class.
    [MetadataTypeAttribute(typeof(RecipeFoodGroup.RecipeFoodGroupMetadata))]
    public partial class RecipeFoodGroup
    {

        // This class allows you to attach custom attributes to properties
        // of the RecipeFoodGroup class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeFoodGroupMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeFoodGroupMetadata()
            {
            }

            public decimal Amount { get; set; }

            public FoodGroup FoodGroup { get; set; }

            public int FoodGroupID { get; set; }

            public Recipe Recipe { get; set; }

            public int RecipeFoodGroupID { get; set; }

            public int RecipeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeIngredientMetadata as the class
    // that carries additional metadata for the RecipeIngredient class.
    [MetadataTypeAttribute(typeof(RecipeIngredient.RecipeIngredientMetadata))]
    public partial class RecipeIngredient
    {

        // This class allows you to attach custom attributes to properties
        // of the RecipeIngredient class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeIngredientMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeIngredientMetadata()
            {
            }

            public Nullable<int> AliasForRecipeIngredientID { get; set; }

            public decimal Amount { get; set; }

            public Ingredient Ingredient { get; set; }

            public int IngredientID { get; set; }

            public Recipe Recipe { get; set; }

            public int RecipeID { get; set; }

            public EntityCollection<RecipeIngredient> RecipeIngredient1 { get; set; }

            public RecipeIngredient RecipeIngredient2 { get; set; }

            public int RecipeIngredientID { get; set; }

            public State State { get; set; }

            public Nullable<int> StateID { get; set; }

            public Unit Unit { get; set; }

            public Nullable<int> UnitID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeStepMetadata as the class
    // that carries additional metadata for the RecipeStep class.
    [MetadataTypeAttribute(typeof(RecipeStep.RecipeStepMetadata))]
    public partial class RecipeStep
    {

        // This class allows you to attach custom attributes to properties
        // of the RecipeStep class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeStepMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeStepMetadata()
            {
            }

            public string Description { get; set; }

            public byte[] Picture { get; set; }

            public Recipe Recipe { get; set; }

            public int RecipeID { get; set; }

            public int RecipeStepID { get; set; }

            public int StepNumber { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecipeTagMetadata as the class
    // that carries additional metadata for the RecipeTag class.
    [MetadataTypeAttribute(typeof(RecipeTag.RecipeTagMetadata))]
    public partial class RecipeTag
    {

        // This class allows you to attach custom attributes to properties
        // of the RecipeTag class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecipeTagMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecipeTagMetadata()
            {
            }

            public Recipe Recipe { get; set; }

            public int RecipeID { get; set; }

            public int RecipeTagID { get; set; }

            public Tag Tag { get; set; }

            public int TagID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies StateMetadata as the class
    // that carries additional metadata for the State class.
    [MetadataTypeAttribute(typeof(State.StateMetadata))]
    public partial class State
    {

        // This class allows you to attach custom attributes to properties
        // of the State class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StateMetadata()
            {
            }

            public string Description { get; set; }

            public EntityCollection<RecipeIngredient> RecipeIngredients { get; set; }

            public int StateID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TagMetadata as the class
    // that carries additional metadata for the Tag class.
    [MetadataTypeAttribute(typeof(Tag.TagMetadata))]
    public partial class Tag
    {

        // This class allows you to attach custom attributes to properties
        // of the Tag class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TagMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TagMetadata()
            {
            }

            public string Name { get; set; }

            public EntityCollection<RecipeTag> RecipeTags { get; set; }

            public int TagID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies UnitMetadata as the class
    // that carries additional metadata for the Unit class.
    [MetadataTypeAttribute(typeof(Unit.UnitMetadata))]
    public partial class Unit
    {

        // This class allows you to attach custom attributes to properties
        // of the Unit class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UnitMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UnitMetadata()
            {
            }

            public string Name { get; set; }

            public EntityCollection<RecipeIngredient> RecipeIngredients { get; set; }

            public int UnitID { get; set; }
        }
    }
}
