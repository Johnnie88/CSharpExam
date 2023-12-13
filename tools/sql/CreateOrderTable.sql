CREATE DATABASE [order];
USE [order];

CREATE TABLE [dbo].[order] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TotalAmount] DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);