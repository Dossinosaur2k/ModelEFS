create database QL_dienthoai
go
use QL_dienthoai
go
CREATE TABLE PhanQuyen(
	IDQuyen int identity(1,1) primary key,
	TenQuyen nvarchar(20)
	)
CREATE TABLE Nguoidung(
	MaNguoiDung int identity(1,1) primary key,
	Hoten nvarchar(50),
	Email nvarchar(50) ,
	Dienthoai nchar(10) ,
	Matkhau varchar(50) ,
	IDQuyen int null foreign key references PhanQuyen,
	Diachi nvarchar(100) NULL
	)
	delete from Nguoidung
CREATE TABLE Hedieuhanh(
	Mahdh int identity(1,1) primary key,
	Tenhdh nvarchar(20),
	)
CREATE TABLE Hangsanxuat(
	Mahang int identity(1,1) primary key,
	Tenhang nvarchar(10) NULL
	)
CREATE TABLE Donhang(
	Madon int identity(1,1) primary key ,
	Ngaydat datetime NULL,
	Tinhtrang int NULL,
	MaNguoidung int foreign key references Nguoidung,
)
CREATE TABLE Sanpham(
	Masp int identity(1,1) primary key, 
	Tensp nvarchar(50) NULL,
	Giatien decimal(18, 0) NULL,
	Soluong int NULL,
	Mota ntext NULL,
	Thesim int NULL,
	Bonhotrong int NULL,
	Sanphammoi bit NULL,
	Ram int NULL,
	Anhbia nvarchar(10) NULL,
	Mahang int  foreign key references Hangsanxuat,
	Mahdh int foreign key references Hedieuhanh
	)
CREATE TABLE Chitietdonhang(
	
	Madon int  foreign key references Donhang,
	Masp  int  foreign key references Sanpham ,
	Soluong int NULL,
	Dongia decimal(18, 0) NULL,
	primary key (Madon,Masp)
)
create table Dangnhap
(
 users char(15) primary key,
 passwords char(15) null
)



