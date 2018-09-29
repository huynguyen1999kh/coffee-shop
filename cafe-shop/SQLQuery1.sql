create database coffeeshop
go
use coffeeshop

select * from dbo.Account
-- food
-- table
-- foodcategory
-- account
-- bill
-- billinfo

create table TableFood
(
id int identity primary key,
name nvarchar(100) not null default N'bàn chưa có tên',
status nvarchar(100) not null default N'trống', 
)
go

create table Account
(
DisplayName nvarchar(100) not null default N'chưa có tên',
UserName nvarchar(100) primary key not null,
Password nvarchar(1000) not null default 1,
type int not null default 0, --staff
)
go

create table FoodCatetory
(
id int identity primary key,
name nvarchar(100) not null default N'chưa có tên',
)
go

create table Food
(
id int identity primary key,
name nvarchar(100) not null default 'chưa đặt tên',
idCatetory int not null,
price float not null default 0,

foreign key (idCatetory) references dbo.FoodCatetory(id),
)
go

create table Bill
(
id int identity primary key,
dateCheckIn date not null default getdate(),
dateCheckOut date,
idTable int not null,
status int not null default 0,

foreign key (idTable) references dbo.TableFood(id),
)
go

create table BillInfo
(
id int identity primary key,
idBill int not null,
idFood int not null,
count int not null default 0,

foreign key (idBill) references dbo.Bill(id),
foreign key (idFood) references dbo.Food(id),
)
go



--data

use coffeeshop
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'HuyUIT' , -- UserName - nvarchar(100)
          N'Nguyễn Quang Huy' , -- DisplayName - nvarchar(100)
          N'astroboy19' , -- PassWord - nvarchar(1000)
          1  -- Type - int -admin
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'tubede' , -- UserName - nvarchar(100)
          N'Dương Thanh Tú' , -- DisplayName - nvarchar(100)
          N'123456' , -- PassWord - nvarchar(1000)
          0  -- Type - int - staff
        )
GO

--create a function
create proc USP_GetAccountByUserName
@userName nvarchar(100)
as
begin
select count(*) from dbo.Account where userName = @userName
end
--use that function
exec dbo.USP_GetAccountByUserName @userName = N'HuyUIT' 

--login
select * from dbo.Account where UserName = N'HuyUIT' and Password = N'astroboy19'
go

create proc USP_GetAccountByUserNameAndPassword
@userName nvarchar(100) , @password nvarchar(100)
as
begin
select count(*) from dbo.Account where userName = @userName and Password = @password
end
go

--use that function
exec dbo.USP_GetAccountByUserNameAndPassword @userName = N'HuyUIT' , @password = N'astroboy193'
go

-- create table list
declare @i int =11
while @i <= 16
begin
insert dbo.TableFood (name)values (N'Bàn ' + cast(@i as nvarchar(100)))
set @i = @i+1
end

delete from dbo.TableFood where name = N'Bàn 0'

declare @j int =1
while @j <=10
begin
update dbo.TableFood set id = @j
set @j = @j + 1
end

set identity_insert dbo.TableFood OFF


select * from dbo.TableFood

--reset identity
DBCC CHECKIDENT ('TableFood', RESEED, 4)

--load table
create proc USP_GetTableFood
as select * from dbo.TableFood
go

exec USP_GetTableFood

--bill
select * from dbo.Bill
select * from dbo.BillInfo
select * from dbo.TableFood
select * from dbo.FoodCatetory
select * from dbo.Food

--add caterory
insert dbo.FoodCatetory (name) values (N'Hải Sản') -- name -- nvarchar(100)
insert dbo.FoodCatetory (name) values (N'Nông Sản') -- name -- nvarchar(100)
insert dbo.FoodCatetory (name) values (N'Lâm Sản') -- name -- nvarchar(100)
insert dbo.FoodCatetory (name) values (N'Nước') -- name -- nvarchar(100)
go
--add food
insert dbo.Food(name,idCatetory,price) values (N'gà chiên mắm',2,30000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'đậu nhồi thịt',2,25000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'ếch xào xả ớt',2,55000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'lẩu cá kèo',1,150000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'mực nướng xa tế',1,70000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'thịt dê',2,100000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'cơm chiên',2,30000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'thịt heo rừng muối ớt',3,140000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'nước cam',4,25000) -- name -- nvarchar(100)
insert dbo.Food(name,idCatetory,price) values (N'cà phê', 4,15000) -- name -- nvarchar(100)
--addbill
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          3 , -- idTable - int
          0  -- status - int
        )
        
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          4, -- idTable - int
          0  -- status - int
        )
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          GETDATE() , -- DateCheckOut - date
          5 , -- idTable - int
          1  -- status - int
        )
		go
		--add bill info
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          6, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          5, -- idFood - int
          2  -- count - int
          )         
          
GO

use coffeeshop
select * from dbo.TableFood as tf,dbo.Bill as b where tf.id= b.id

select * from dbo.FoodCatetory

select * from dbo.Bill where idTable= 3 and status = 0
select * from dbo.Food where idCatetory = 2
select * from dbo.BillInfo where idBill=1

select f.name, f.price , bi.count from dbo.Food as f, dbo.Bill as b, dbo.BillInfo as bi where f.id = bi.idFood and bi.idBill = b.id and b.status=0 and b.idTable = 3

alter proc USP_InsertBill
@idTable int
as
begin 
insert dbo.Bill
(dateCheckIn,dateCheckOut,idTable,status,discount)
values
(GETDATE(),null,@idTable,0,0)
end


alter proc USP_InsertBillInfo
@idBill int,
@idFood int,
@count int
as
begin
declare @isExitsBillInfo int
declare @oldcount int
select @oldcount = b.count from dbo.BillInfo as b where idBill=@idBill and idFood = @idFood
select @isExitsBillInfo = count(*) from dbo.BillInfo where idBill=@idBill and idFood = @idFood
if (@isExitsBillInfo > 0)
begin
declare @newcount int 
set @newcount = @oldcount + @count
if (@newcount > 0)
update dbo.BillInfo set count = @oldcount + @count where idBill= @idBill and idFood = @idFood
else
delete dbo.BillInfo where idBill=@idBill and idFood = @idFood
end
else
begin
if (@count>0)
insert dbo.BillInfo
(idBill,idFood,count)
values
(@idBill,@idFood,@count)
end
end

alter trigger UTG_UpdateBillInfo
on dbo.BillInfo for insert,update
as
begin

declare @idBill int
select @idBill = idBill from inserted
declare @idTable int
select @idTable = idTable from dbo.Bill where id = @idBill and status = 0

declare @countBill int
select @countBill = count(*) from dbo.BillInfo as bi,dbo.Bill as b where  b.id = bi.idBill and b.id = @idBill and status = 0
if (@countBill = 0)
begin
update dbo.TableFood set status = N'trống' where id = @idtable
end
else
begin
update dbo.TableFood set status = N'có người' where id = @idtable
end
end
go

alter trigger UTG_UpdateBill
on dbo.Bill for Update,insert
as
begin
declare @idBill int
select @idBill = id from inserted
declare @idTable int 
select @idTable = idTable from dbo.Bill where id = @idBill
declare @count int
select @count = count(*) from dbo.Bill where idTable = @idTable and status = 0
if (@count > 0)
update dbo.TableFood set status = N'có người' where id = @idTable
else
update dbo.TableFood set status = N'trống' where id = @idTable
end

alter table dbo.Bill add discount INT
update Bill set discount = 0

--
alter proc USP_SwitchTable_A
@idTable1 int , @idTable2 int
as begin

	declare @idFirstBill int
	declare @idSecondBill int
	select @idFirstBill = id from dbo.Bill where idTable =  @idTable1 and status = 0
	select @idSecondBill = id from dbo.Bill where idTable = @idTable2 and status = 0
	if (@idFirstBill is null and @idSecondBill is null)
	begin
		return
	end
	else
	begin
	    if (@idSecondBill is null)
		begin
		update dbo.TableFood set status = N'trống' where id = @idTable1
		end
		if (@idFirstBill is null)
		begin
		    update dbo.TableFood set status = N'trống' where id = @idTable2
			declare @idBillTemp int
			select @idBillTemp = @idFirstBill
			select @idFirstBill =@idSecondBill
			select @idSecondBill = @idBillTemp
		end
	--select id into BillTableTemp from Bill where idTable = @idTable1 and status = 0
	--update Bill set idTable = @idTable1 where idTable = @idTable2 and status = 0
	--update Bill set idTable = @idTable2 where id in (select id from BillTableTemp)
	--drop table BillTableTemp
	if (@idFirstBill is not null and @idSecondBill is not null)
		begin
		update Bill set idTable = @idTable1 where id = @idSecondBill and status = 0
		update Bill set idTable = @idTable2 where id = @idFirstBill and status = 0
		end
	else
		begin
	    update Bill set idTable = @idTable2 where id = @idFirstBill and status = 0
		end
	end

	--if (@idFirstBill is not null and @idSecondBill is not null)
	--begin
		--SELECT id into IDBillInfoTable from BillInfo where idBill = @idSecondBill
		--update BillInfo set idBill = @idSecondBill where idBill = @idFirstBill
		--update BillInfo set idBill = @idFirstBill where id in (select id from IDBillInfoTable)

		--drop table IDBillInfoTable
		--update Bill set idTable = @idTable1 where idTable = @idTable2
		--update Bill set idTable = @idTable2 where idTable = @idTable1
		--return
	--end
end
go

select * from dbo.TableFood where id = 9
select * from dbo.Bill where idTable = 9 and status = 0
select * from dbo.Bill where id = 83
select * from dbo.BillInfo where idBill = 83

select idTable into BillTableTemp from Bill where idTable = 3 and status = 0
select * from BillTableTemp
	select Bill where idTable = 4 and status = 0
	update Bill set idTable = 4 where idTable in (select idTable from BillTableTemp)
	drop table BillTableTemp

	--update bill
	alter table bill add default 0 for totalPrice
	update bill set totalPrice = sum(price) from dbo.Food,dbo.BillInfo,dbo.Bill where Bill.id = BillInfo.idBill and BillInfo.idFood = Food.id

-- get list bill follow by day
select t.name, b.dateCheckIn, b.dateCheckOut, b.discount, b.totalPrice from 
dbo.Bill as b,dbo.TableFood as t,dbo.BillInfo as bi, dbo.Food as f
where b.idTable = t.id and b.status = 1
and b.dateCheckIn >= '20180904' and b.dateCheckOut <= '20180907'
and bi.idFood = f.id and bi.idBill = b.id

alter proc USP_GetListBillByDay
@checkIn date, @checkOut date
as
begin
select t.name as [tên bàn], b.dateCheckIn as [ngày vào], b.dateCheckOut as [ngày ra], b.discount as [giảm giá], b.totalPrice as [tổng tiền] from 
dbo.Bill as b,dbo.TableFood as t,dbo.BillInfo as bi, dbo.Food as f
where b.idTable = t.id and b.status = 1
and b.dateCheckIn >= @checkIn and b.dateCheckOut <= @checkOut
and bi.idFood = f.id and bi.idBill = b.id
end
go

create proc USP_UpdateAccount
@userName nvarchar(100), @displayName nvarchar(100), @password nvarchar(100), @newPassword nvarchar(100)
as
begin
declare @isRightAccount int = 0
select @isRightAccount = count(*) from dbo.Account where Password = @password and UserName = @userName
if (@isRightAccount = 1)
begin
	if (@newPassword = '' or @newPassword = null)
	begin
		update dbo.Account set DisplayName = @displayName where UserName = @userName
	end
	else
	begin
		update dbo.Account set DisplayName = @displayName, Password = @newPassword where UserName = @userName
	end
end 
end 

select f.id as [ID],f.name as [tên món], fc.name as [loại], price as [đơn giá]  from dbo.Food as f,dbo.FoodCatetory as fc where idCatetory = fc.id

select * from dbo.FoodCatetory
select * from dbo.food
insert dbo.Food(name,idCatetory,price) values (N'thịt kho tàu',2,28000)
delete dbo.Food where id =12
update dbo.Food set name = N'thịt kho tàu', idCatetory = 2, price = 29000 where id = 13 

create trigger UTG_DeleteBillInfo
on dbo.BillInfo for delete
as
begin

declare @idBillInfo int
select @idBillInfo = id from deleted
declare @idBill int
select @idBill = idBill from deleted
declare @idTable int
select @idTable = idTable from dbo.Bill where id = @idBill

declare @countBill int
select @countBill = count(*) from dbo.Bill as b,dbo.BillInfo as bi where b.id = bi.idBill and b.id = @idBill and status = 0
if (@countBill = 0)
begin
update dbo.TableFood set status = N'trống' where id = @idtable
end
else
begin
update dbo.TableFood set status = N'có người' where id = @idtable
end
end
go

select * from dbo.Food where dbo.fuConvertToUnsign1(name) like N'%'+ dbo.fuConvertToUnsign1(N'dau') +'%'
select f.id as [ID], f.name as [tên món], fc.name as [loại], price as [đơn giá] from dbo.Food as f,dbo.FoodCatetory as fc where f.idCatetory = fc.id and f.name like N'%%'

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

select f.id as [ID], f.name as [tên món], fc.name as [loại], price as [đơn giá] from dbo.Food as f,dbo.FoodCatetory as fc where f.idCatetory = fc.id and dbo.fuConvertToUnsign1(f.name) like N'%'+ dbo.fuConvertToUnsign1(N'dau') +'%'

create table Accounttype
(
id int identity primary key,
name nvarchar(100) not null default N'nhân viên',
)
go

INSERT INTO dbo.Accounttype
(name)
values
(N'admin')

select * from dbo.Accounttype,Account where type = Accounttype.id

update dbo.Account set type = 1 where type = 3
select * from Account

alter table dbo.Account  add foreign key (type) references dbo.Accounttype(id)

