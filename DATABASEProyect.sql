use SoreLibrary
drop table if exists clientes
create table clientes(
IDcliente int identity(1,1) primary key,
nombre varchar(30) not null,
apellido varchar(30) not null,
direccion varchar(100) not null,
telefono varchar(30),
correo varchar(30) not null,
estado char(1) not null
)
drop table if exists empleados
create table empleados(
IDempleado int identity(1,1) primary key,
nombre varchar(30) not null,
apellido varchar(30) not null,
puesto varchar(30) not null
)
drop table if exists proveedores
create table proveedores(
idproveedor int identity (1,1) primary key,
nombre varchar(30) not null,
telefono varchar(30) not null,
correo varchar(30) not null
)
drop table if exists libros
create table libros(
IDlibro int identity(1,1) primary key,
autor varchar(30) not null,
titulo varchar(30) not null,
idproveedor int,
stock int

FOREIGN KEY (idproveedor) REFERENCES proveedores(idproveedor)

)

insert into proveedores(nombre,telefono,correo) values ('ElRubius','777-777-7777','elrubiusomg@gmail.com')
insert into libros(autor,titulo,stock) values ('El Rubius OMG','El libro trol',5)
insert into empleados(nombre,apellido,puesto) values ('SoreNine','Cat','administrador')
insert into clientes(nombre,apellido,correo,direccion,telefono,estado) values ('Rose','Ovalles','catnin@gmail.com','peru','555-444-3333','p')
select * from libros;
select * from proveedores;

TRUNCATE TABLE libros;
TRUNCATE TABLE proveedores;
TRUNCATE TABLE clientes;
