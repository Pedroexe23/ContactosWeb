create Database DBContactos
go
use DBContactos





create table CONTACTOS(
IDContacto int Identity(1,1) PRIMARY KEY,
NOMBRE NVARCHAR(25),
TELEFONO int not null,
EMAIL NVARCHAR(50),
DIRECCION NVARCHAR(30)

) 

