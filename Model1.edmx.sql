
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/31/2020 19:03:28
-- Generated from EDMX file: E:\Nam4\quanli\Web_QLDA-1\WebBanHang\WebBanHang\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLyDuAnNhom3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DanhMuc_id_pk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SANPHAM] DROP CONSTRAINT [FK_DanhMuc_id_pk];
GO
IF OBJECT_ID(N'[dbo].[FK_MaDonHang_pk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CHITIETDONHANG] DROP CONSTRAINT [FK_MaDonHang_pk];
GO
IF OBJECT_ID(N'[dbo].[FK_MaSanPham_pk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CHITIETDONHANG] DROP CONSTRAINT [FK_MaSanPham_pk];
GO
IF OBJECT_ID(N'[dbo].[FK_TaiKhoan_id_pk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DONHANG] DROP CONSTRAINT [FK_TaiKhoan_id_pk];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CHITIETDONHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CHITIETDONHANG];
GO
IF OBJECT_ID(N'[dbo].[DANHMUC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DANHMUC];
GO
IF OBJECT_ID(N'[dbo].[DONHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DONHANG];
GO
IF OBJECT_ID(N'[dbo].[SANPHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[TAIKHOAN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TAIKHOAN];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CHITIETDONHANG'
CREATE TABLE [dbo].[CHITIETDONHANG] (
    [MaDonHang] int  NOT NULL,
    [MaSanPham] int  NOT NULL,
    [SoLuong] int  NOT NULL,
    [GiaBan] decimal(18,0)  NOT NULL,
    [TongTien] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'DANHMUC'
CREATE TABLE [dbo].[DANHMUC] (
    [MaDanhMuc] int IDENTITY(1,1) NOT NULL,
    [TenDanhMuc] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'DONHANG'
CREATE TABLE [dbo].[DONHANG] (
    [MaDonHang] int IDENTITY(1,1) NOT NULL,
    [MaKhachHang] int  NOT NULL,
    [ThanhToan] nvarchar(255)  NULL,
    [NgayDatHang] datetime  NULL,
    [NgayNhanHang] datetime  NULL,
    [TrangThai] nvarchar(100)  NULL,
    [TenKhachHang] nvarchar(50)  NULL,
    [DiaChi] varchar(max)  NULL,
    [SoDienThoai] varchar(15)  NULL
);
GO

-- Creating table 'SANPHAM'
CREATE TABLE [dbo].[SANPHAM] (
    [MaSanPham] int IDENTITY(1,1) NOT NULL,
    [MaDanhMuc] int  NOT NULL,
    [Mau] nvarchar(20)  NULL,
    [TenSanPham] nvarchar(255)  NOT NULL,
    [Anh] varchar(max)  NOT NULL,
    [MieuTa] varchar(max)  NOT NULL,
    [Gia] decimal(18,0)  NOT NULL,
    [SoLuongTrongKho] int  NOT NULL,
    [HanSuDung] datetime  NULL,
    [NgayThem] datetime  NULL
);
GO

-- Creating table 'TAIKHOAN'
CREATE TABLE [dbo].[TAIKHOAN] (
    [MaTaiKhoan] int IDENTITY(1,1) NOT NULL,
    [TenTaiKhoan] nvarchar(100)  NOT NULL,
    [MatKhau] nvarchar(255)  NOT NULL,
    [Ten] nvarchar(100)  NOT NULL,
    [DiaChi] varchar(max)  NOT NULL,
    [SoDienThoai] varchar(15)  NOT NULL,
    [Check_admin] int  NULL,
    [NgayTao] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaDonHang], [MaSanPham] in table 'CHITIETDONHANG'
ALTER TABLE [dbo].[CHITIETDONHANG]
ADD CONSTRAINT [PK_CHITIETDONHANG]
    PRIMARY KEY CLUSTERED ([MaDonHang], [MaSanPham] ASC);
GO

-- Creating primary key on [MaDanhMuc] in table 'DANHMUC'
ALTER TABLE [dbo].[DANHMUC]
ADD CONSTRAINT [PK_DANHMUC]
    PRIMARY KEY CLUSTERED ([MaDanhMuc] ASC);
GO

-- Creating primary key on [MaDonHang] in table 'DONHANG'
ALTER TABLE [dbo].[DONHANG]
ADD CONSTRAINT [PK_DONHANG]
    PRIMARY KEY CLUSTERED ([MaDonHang] ASC);
GO

-- Creating primary key on [MaSanPham] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [PK_SANPHAM]
    PRIMARY KEY CLUSTERED ([MaSanPham] ASC);
GO

-- Creating primary key on [MaTaiKhoan] in table 'TAIKHOAN'
ALTER TABLE [dbo].[TAIKHOAN]
ADD CONSTRAINT [PK_TAIKHOAN]
    PRIMARY KEY CLUSTERED ([MaTaiKhoan] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaDonHang] in table 'CHITIETDONHANG'
ALTER TABLE [dbo].[CHITIETDONHANG]
ADD CONSTRAINT [FK_MaDonHang_pk]
    FOREIGN KEY ([MaDonHang])
    REFERENCES [dbo].[DONHANG]
        ([MaDonHang])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaSanPham] in table 'CHITIETDONHANG'
ALTER TABLE [dbo].[CHITIETDONHANG]
ADD CONSTRAINT [FK_MaSanPham_pk]
    FOREIGN KEY ([MaSanPham])
    REFERENCES [dbo].[SANPHAM]
        ([MaSanPham])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaSanPham_pk'
CREATE INDEX [IX_FK_MaSanPham_pk]
ON [dbo].[CHITIETDONHANG]
    ([MaSanPham]);
GO

-- Creating foreign key on [MaDanhMuc] in table 'SANPHAM'
ALTER TABLE [dbo].[SANPHAM]
ADD CONSTRAINT [FK_DanhMuc_id_pk]
    FOREIGN KEY ([MaDanhMuc])
    REFERENCES [dbo].[DANHMUC]
        ([MaDanhMuc])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DanhMuc_id_pk'
CREATE INDEX [IX_FK_DanhMuc_id_pk]
ON [dbo].[SANPHAM]
    ([MaDanhMuc]);
GO

-- Creating foreign key on [MaKhachHang] in table 'DONHANG'
ALTER TABLE [dbo].[DONHANG]
ADD CONSTRAINT [FK_TaiKhoan_id_pk]
    FOREIGN KEY ([MaKhachHang])
    REFERENCES [dbo].[TAIKHOAN]
        ([MaTaiKhoan])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaiKhoan_id_pk'
CREATE INDEX [IX_FK_TaiKhoan_id_pk]
ON [dbo].[DONHANG]
    ([MaKhachHang]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------