CREATE TABLE [dbo].[Table] (
    [номер]         INT   NOT NULL,
    [производитель] NTEXT  NULL,
    [наименование]  NTEXT NULL,
    [артикул]       NTEXT NULL,
    [фотография]    IMAGE NULL,
    [цена]          MONEY NULL,
    PRIMARY KEY CLUSTERED ([номер] ASC)
);

