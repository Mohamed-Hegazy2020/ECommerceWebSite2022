IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    CREATE TABLE [CompanyDatas] (
        [id] int NOT NULL IDENTITY,
        [CompanyNameAr] nvarchar(max) NULL,
        [CompanyNameEn] nvarchar(max) NULL,
        [AddressAr] nvarchar(max) NULL,
        [AddressEn] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [LogoImage] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Mobile] nvarchar(max) NULL,
        [Fax] nvarchar(max) NULL,
        [FaceBookLink] nvarchar(max) NULL,
        [TwitterLink] nvarchar(max) NULL,
        [InstgramLink] nvarchar(max) NULL,
        [LinkedinLink] nvarchar(max) NULL,
        CONSTRAINT [PK_CompanyDatas] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    CREATE TABLE [Curunces] (
        [id] int NOT NULL IDENTITY,
        [CuruncyNameAr] nvarchar(max) NULL,
        [CuruncyNameEn] nvarchar(max) NULL,
        CONSTRAINT [PK_Curunces] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    CREATE TABLE [Groups] (
        [id] int NOT NULL IDENTITY,
        [GroupNameAr] nvarchar(max) NULL,
        [GroupNameEn] nvarchar(max) NULL,
        CONSTRAINT [PK_Groups] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    CREATE TABLE [Items] (
        [id] int NOT NULL IDENTITY,
        [itemNameAr] nvarchar(max) NULL,
        [itemNameEn] nvarchar(max) NULL,
        [itemDescreptionAr] nvarchar(max) NULL,
        [itemDescreptionEn] nvarchar(max) NULL,
        [groupId] int NOT NULL,
        [unitId] int NOT NULL,
        [price] decimal(18,2) NOT NULL,
        [quantity] decimal(18,2) NOT NULL,
        [itemImgFile] nvarchar(max) NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    CREATE TABLE [Units] (
        [id] int NOT NULL IDENTITY,
        [UnitNameAr] nvarchar(max) NULL,
        [UnitNameEn] nvarchar(max) NULL,
        CONSTRAINT [PK_Units] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227160442_createdatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211227160442_createdatabase', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227163241_Addgroupimage')
BEGIN
    ALTER TABLE [Groups] ADD [GroupImgFile] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211227163241_Addgroupimage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211227163241_Addgroupimage', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101190315_createInvoices')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CompanyDatas]') AND [c].[name] = N'CompanyNameAr');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [CompanyDatas] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [CompanyDatas] ALTER COLUMN [CompanyNameAr] nvarchar(max) NOT NULL;
    ALTER TABLE [CompanyDatas] ADD DEFAULT N'' FOR [CompanyNameAr];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101190315_createInvoices')
BEGIN
    CREATE TABLE [Invoices] (
        [id] int NOT NULL IDENTITY,
        [invNo] int NOT NULL,
        [customerName] nvarchar(max) NULL,
        [customerTel] nvarchar(max) NULL,
        [customerMobile] nvarchar(max) NULL,
        [customerAddress] nvarchar(max) NULL,
        [itemName] nvarchar(max) NULL,
        [itemCode] nvarchar(max) NULL,
        [price] decimal(18,2) NOT NULL,
        [quantity] decimal(18,2) NOT NULL,
        [IsViewed] bit NOT NULL,
        CONSTRAINT [PK_Invoices] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101190315_createInvoices')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220101190315_createInvoices', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101202443_InvoiceMaster')
BEGIN
    DROP TABLE [Invoices];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101202443_InvoiceMaster')
BEGIN
    CREATE TABLE [InvoiceDetailes] (
        [id] int NOT NULL IDENTITY,
        [masterId] int NOT NULL,
        [invNo] int NOT NULL,
        [itemName] nvarchar(max) NULL,
        [itemCode] nvarchar(max) NULL,
        [price] decimal(18,2) NOT NULL,
        [quantity] decimal(18,2) NOT NULL,
        [IsViewed] bit NOT NULL,
        CONSTRAINT [PK_InvoiceDetailes] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101202443_InvoiceMaster')
BEGIN
    CREATE TABLE [InvoiceMaster] (
        [id] int NOT NULL IDENTITY,
        [customerName] nvarchar(max) NULL,
        [customerTel] nvarchar(max) NULL,
        [customerMobile] nvarchar(max) NULL,
        [customerAddress] nvarchar(max) NULL,
        [deleverMethod] int NOT NULL,
        [IsPayed] bit NOT NULL,
        [IsDeleverd] bit NOT NULL,
        [invDate] int NOT NULL,
        CONSTRAINT [PK_InvoiceMaster] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220101202443_InvoiceMaster')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220101202443_InvoiceMaster', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206164841_updateinvoicemaster')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [InvoiceId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206164841_updateinvoicemaster')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [PaymentURL] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206164841_updateinvoicemaster')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [paymentMethod] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206164841_updateinvoicemaster')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220206164841_updateinvoicemaster', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206172548_updateinvoicemaster2')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [PaymentId] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206172548_updateinvoicemaster2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220206172548_updateinvoicemaster2', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206174633_updateinvoicemaster3')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InvoiceMaster]') AND [c].[name] = N'invDate');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [InvoiceMaster] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [InvoiceMaster] ALTER COLUMN [invDate] datetime2 NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206174633_updateinvoicemaster3')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [InvoiceStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206174633_updateinvoicemaster3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220206174633_updateinvoicemaster3', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206175042_updateinvoicemaster4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220206175042_updateinvoicemaster4', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206180929_updateinvoicemaster5')
BEGIN
    EXEC sp_rename N'[InvoiceMaster].[invDate]', N'invoiceDate', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220206180929_updateinvoicemaster5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220206180929_updateinvoicemaster5', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213120129_addInvoiceTotal')
BEGIN
    ALTER TABLE [InvoiceMaster] ADD [InvoiceTotal] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213120129_addInvoiceTotal')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220213120129_addInvoiceTotal', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213132857_addSliderTbl')
BEGIN
    CREATE TABLE [Slider] (
        [id] int NOT NULL IDENTITY,
        [HedarAr] nvarchar(max) NULL,
        [HedarEn] nvarchar(max) NULL,
        [DescreptionAr] nvarchar(max) NULL,
        [DescreptionEn] nvarchar(max) NULL,
        [ImagePath] nvarchar(max) NULL,
        CONSTRAINT [PK_Slider] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213132857_addSliderTbl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220213132857_addSliderTbl', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213212615_addisDefualtCuruncy')
BEGIN
    ALTER TABLE [Curunces] ADD [isDefualtCuruncy] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213212615_addisDefualtCuruncy')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220213212615_addisDefualtCuruncy', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213215450_addisDefualtid')
BEGIN
    ALTER TABLE [Items] ADD [curuncyId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213215450_addisDefualtid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220213215450_addisDefualtid', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220218212144_addAboutDescreptioncolnn')
BEGIN
    ALTER TABLE [CompanyDatas] ADD [AboutDescreptionAr] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220218212144_addAboutDescreptioncolnn')
BEGIN
    ALTER TABLE [CompanyDatas] ADD [AboutDescreptionEn] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220218212144_addAboutDescreptioncolnn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220218212144_addAboutDescreptioncolnn', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220219210827_addIsMainGroup')
BEGIN
    ALTER TABLE [Groups] ADD [IsMainGroup] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220219210827_addIsMainGroup')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220219210827_addIsMainGroup', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220219211726_addMainGroupid')
BEGIN
    ALTER TABLE [Groups] ADD [mainGroupId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220219211726_addMainGroupid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220219211726_addMainGroupid', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220220131202_addsubGroupId')
BEGIN
    ALTER TABLE [Items] ADD [subGroupId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220220131202_addsubGroupId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220220131202_addsubGroupId', N'5.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220227120035_addspecialItem')
BEGIN
    ALTER TABLE [Items] ADD [specialItem] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220227120035_addspecialItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220227120035_addspecialItem', N'5.0.13');
END;
GO

COMMIT;
GO

