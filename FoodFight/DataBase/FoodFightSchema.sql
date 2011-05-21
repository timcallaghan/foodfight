USE [FoodFight]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipe](
	[RecipeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[CookingTime] [time](7) NULL,
	[Serves] [int] NOT NULL,
	[Picture] [varbinary](max) NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_Recipe_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[IngredientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_Ingredient_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodGroup]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodGroup](
	[FoodGroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_FoodGroup] PRIMARY KEY CLUSTERED 
(
	[FoodGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_FoodGroup_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentTag]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTag](
	[EquipmentTagID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_EquipmentTag] PRIMARY KEY CLUSTERED 
(
	[EquipmentTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_EquipmentTag_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_Unit_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_Tag_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_State_Description] UNIQUE NONCLUSTERED 
(
	[Description] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeTag]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeTag](
	[RecipeTagID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_RecipeTag] PRIMARY KEY CLUSTERED 
(
	[RecipeTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_RecipeTag] UNIQUE NONCLUSTERED 
(
	[RecipeID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeTag_Recipe] ON [dbo].[RecipeTag] 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeTag_Tag] ON [dbo].[RecipeTag] 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeStep]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecipeStep](
	[RecipeStepID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[StepNumber] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Picture] [varbinary](max) NULL,
 CONSTRAINT [PK_RecipeStep] PRIMARY KEY CLUSTERED 
(
	[RecipeStepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_RecipeStep_StepNumber] UNIQUE NONCLUSTERED 
(
	[StepNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RecipeStep_Recipe] ON [dbo].[RecipeStep] 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeIngredient]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredient](
	[RecipeIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[IngredientID] [int] NOT NULL,
	[StateID] [int] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[UnitID] [int] NULL,
	[AliasForRecipeIngredientID] [int] NULL,
 CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY CLUSTERED 
(
	[RecipeIngredientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeIngredient_Ingredient] ON [dbo].[RecipeIngredient] 
(
	[IngredientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeIngredient_Recipe] ON [dbo].[RecipeIngredient] 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeFoodGroup]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeFoodGroup](
	[RecipeFoodGroupID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[FoodGroupID] [int] NOT NULL,
	[Amount] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_RecipeFoodGroup] PRIMARY KEY CLUSTERED 
(
	[RecipeFoodGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_RecipeFoodGroup] UNIQUE NONCLUSTERED 
(
	[RecipeID] ASC,
	[FoodGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeFoodGroup_FoodGroup] ON [dbo].[RecipeFoodGroup] 
(
	[FoodGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeFoodGroup_Recipe] ON [dbo].[RecipeFoodGroup] 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeEquipmentTag]    Script Date: 05/21/2011 12:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeEquipmentTag](
	[RecipeEquipmentTagID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[EquipmentTagID] [int] NOT NULL,
 CONSTRAINT [PK_RecipeEquipmentTag] PRIMARY KEY CLUSTERED 
(
	[RecipeEquipmentTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UX_RecipeEquipmentTag] UNIQUE NONCLUSTERED 
(
	[RecipeID] ASC,
	[EquipmentTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeEquipmentTag_Equipment] ON [dbo].[RecipeEquipmentTag] 
(
	[EquipmentTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RecipeEquipmentTag_Recipe] ON [dbo].[RecipeEquipmentTag] 
(
	[RecipeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_RecipeEquipmentTag_EquipmentTag]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeEquipmentTag]  WITH CHECK ADD  CONSTRAINT [FK_RecipeEquipmentTag_EquipmentTag] FOREIGN KEY([EquipmentTagID])
REFERENCES [dbo].[EquipmentTag] ([EquipmentTagID])
GO
ALTER TABLE [dbo].[RecipeEquipmentTag] CHECK CONSTRAINT [FK_RecipeEquipmentTag_EquipmentTag]
GO
/****** Object:  ForeignKey [FK_RecipeEquipmentTag_Recipe]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeEquipmentTag]  WITH CHECK ADD  CONSTRAINT [FK_RecipeEquipmentTag_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeEquipmentTag] CHECK CONSTRAINT [FK_RecipeEquipmentTag_Recipe]
GO
/****** Object:  ForeignKey [FK_RecipeFoodGroup_FoodGroup]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeFoodGroup]  WITH CHECK ADD  CONSTRAINT [FK_RecipeFoodGroup_FoodGroup] FOREIGN KEY([FoodGroupID])
REFERENCES [dbo].[FoodGroup] ([FoodGroupID])
GO
ALTER TABLE [dbo].[RecipeFoodGroup] CHECK CONSTRAINT [FK_RecipeFoodGroup_FoodGroup]
GO
/****** Object:  ForeignKey [FK_RecipeFoodGroup_Recipe]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeFoodGroup]  WITH CHECK ADD  CONSTRAINT [FK_RecipeFoodGroup_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeFoodGroup] CHECK CONSTRAINT [FK_RecipeFoodGroup_Recipe]
GO
/****** Object:  ForeignKey [FK_RecipeIngredient_Ingredient]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_Ingredient] FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredient] ([IngredientID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_Ingredient]
GO
/****** Object:  ForeignKey [FK_RecipeIngredient_Recipe]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_Recipe]
GO
/****** Object:  ForeignKey [FK_RecipeIngredient_RecipeIngredient]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_RecipeIngredient] FOREIGN KEY([AliasForRecipeIngredientID])
REFERENCES [dbo].[RecipeIngredient] ([RecipeIngredientID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_RecipeIngredient]
GO
/****** Object:  ForeignKey [FK_RecipeIngredient_State]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([StateID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_State]
GO
/****** Object:  ForeignKey [FK_RecipeIngredient_Unit]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_Unit] FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([UnitID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_Unit]
GO
/****** Object:  ForeignKey [FK_RecipeStep_Recipe]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeStep]  WITH CHECK ADD  CONSTRAINT [FK_RecipeStep_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeStep] CHECK CONSTRAINT [FK_RecipeStep_Recipe]
GO
/****** Object:  ForeignKey [FK_RecipeTag_Recipe]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeTag]  WITH CHECK ADD  CONSTRAINT [FK_RecipeTag_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeTag] CHECK CONSTRAINT [FK_RecipeTag_Recipe]
GO
/****** Object:  ForeignKey [FK_RecipeTag_Tag]    Script Date: 05/21/2011 12:09:58 ******/
ALTER TABLE [dbo].[RecipeTag]  WITH CHECK ADD  CONSTRAINT [FK_RecipeTag_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([TagID])
GO
ALTER TABLE [dbo].[RecipeTag] CHECK CONSTRAINT [FK_RecipeTag_Tag]
GO
