create database Examen
use Examen

Create table Cat_Proveedores
(
Id_Proveedores int primary key identity (1,1),
NombreProveedor varchar (100),
RFC varchar (20)
)

Create table Cat_TipoProducto
(
Id_Producto int primary key identity (1,1),
NombreTipoProducto varchar (50)
)

Create table Productos
(
IdProductos int primary key identity (1,1),
NombreProducto varchar(15),
IdProveedores int foreign key references Cat_Proveedores(Id_Proveedores),
IdTipo int foreign key references Cat_TipoProducto(Id_Producto),
Cantidad int,
Fecha datetime,
Modelo varchar(20),
Marca varchar(20)
)

Alter table Productos add Default GetDate() for Fecha
---------------------------------------------------
Insert into Cat_Proveedores (NombreProveedor,RFC) values ('HP','22222'),('NESCAFE', '11111')
Select *from Cat_Proveedores

Insert into Cat_TipoProducto (NombreTipoProducto) values ('Electronica'),('Alimentos')
Select *from Cat_TipoProducto
---------------------------------------------------
--Alter (Por si me equivoco xd)
Create procedure TraeProveedores
as
begin
Select *from Cat_Proveedores
end
Exec TraeProveedores
----------------------------------------------------
Create procedure TraeProducto
as
begin
Select *from Cat_TipoProducto
end
Exec TraeProducto
---------------------------------------------------


Alter procedure insertaProducto

@NombreProducto varchar(20),
@IdProveedores int,
@IdTipo int,
@Cantidad int,
@Modelo varchar(20),
@Marca varchar (20)
as
begin
Insert into Productos(NombreProducto,IdProveedores,IdTipo,Cantidad,Modelo,Marca) 
values (@NombreProducto,@IdProveedores,@IdTipo,@Cantidad,@Modelo,@Marca)
end

Select *from Productos


----------------------------------------------------
alter procedure Reporte
as
begin
select pr.*,
catpro.NombreProveedor as NombreProveedor,
catip.NombreTipoProducto as NombreTipoProducto
from Productos pr
full join Cat_TipoProducto catip on pr.IdProductos = catip.Id_Producto
left join Cat_Proveedores catpro on pr.IdProveedores = catpro.Id_Proveedores
end

Exec Reporte


select *from Cat_TipoProducto
select *from Productos

------------------------------------------------------------
alter procedure Actualizar
@IdProducto int,
@NombreProducto varchar(20),
@IdProveedores int,
@IdTipo int,
@Cantidad int,
@Modelo varchar(20),
@Marca varchar (20)
as
begin
update Productos set 
NombreProducto=@NombreProducto
,IdProveedores=@IdProveedores
,IdTipo=@IdTipo
,Cantidad=@Cantidad
,Modelo=@Modelo
,Marca=@Marca
where IdProductos=@IdProducto
end